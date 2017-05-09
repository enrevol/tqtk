using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Diagnostics;
using MoreLinq;

namespace k8asd {
    public partial class DailyTaskView : UserControl, IDailyTaskView {
        private List<IDailyTask> models;
        private IPacketWriter packetWriter;
        private IInfoModel infoModel;
        private IMcuModel mcuModel;
        private ISystemLog messageModel;

        private bool timerLocking;
        private bool asyncLocking;

        public List<IDailyTask> Models {
            get { return models; }
            set {
                if (models != null) {
                    foreach (var model in models) {

                    }
                }
                models = value;
                if (models != null) {
                    foreach (var model in models) {

                    }
                }
            }
        }

        public DailyTaskView() {
            InitializeComponent();

            timerLocking = false;
            asyncLocking = false;

            taskTimer.Start();
        }

        public void SetPacketWriter(IPacketWriter writer) {
            if (packetWriter != null) {
                packetWriter.PacketReceived -= OnPacketReceived;
            }
            packetWriter = writer;
            packetWriter.PacketReceived += OnPacketReceived;
        }

        public void SetInfoModel(IInfoModel model) {
            infoModel = model;
        }

        public void SetMcuModel(IMcuModel model) {
            mcuModel = model;
        }

        public void SetMessageModel(ISystemLog model) {
            messageModel = model;
        }

        private void OnPacketReceived(object sender, Packet packet) {
            //
        }

        public void EnableAutoQuest() {
            dailyTaskCheck.Checked = true;
        }

        public void DisableAutoQuest() {
            dailyTaskCheck.Checked = false;
        }

        private void chkQuest_CheckedChanged(object sender, EventArgs e) {

        }

        public async Task<List<TaskDetail>> RefreshTaskDetails(TaskBoard board) {
            var taskDetails = new List<TaskDetail>();
            foreach (var task in board.Tasks) {
                var detail = await packetWriter.RefreshTaskAsync(task.Id);
                if (detail == null) {
                    return null;
                }
                taskDetails.Add(detail);
            }
            return taskDetails;
        }

        /// <summary>
        /// Kiểm tra xem có nhiệm vụ nào hoàn thành chưa?
        /// </summary>
        /// <param name="taskBoard">Danh sách nhiệm vụ.</param>
        private async Task<bool> EnsureNoCompletedTask(TaskBoard taskBoard) {
            Debug.Assert(asyncLocking);
            foreach (var task in taskBoard.Tasks) {
                if (task.State == TaskState.Completed) {
                    messageModel.Log(String.Format("[NVHN] Hoàn thành nhiệm vụ ID {0}", task.Id));
                    // Hoàn thành nhiệm vụ.
                    await packetWriter.CompleteTaskAsync(task.Id);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra xem có nhận nhiều nhiệm vụ một lúc không?
        /// </summary>
        private async Task<bool> EnsureNoMultipleAcceptedTask(TaskBoard taskBoard) {
            Debug.Assert(asyncLocking);
            int acceptedTaskCount = 0;
            foreach (var task in taskBoard.Tasks) {
                if (task.State == TaskState.Received) {
                    ++acceptedTaskCount;
                }
            }

            if (acceptedTaskCount > 1) {
                // Huỷ hết.
                messageModel.Log(String.Format("[NVHN] Đang nhận nhiều nhiệm vụ, huỷ tất cả!"));
                foreach (var task in taskBoard.Tasks) {
                    if (task.State == TaskState.Received) {
                        await packetWriter.CancelTaskAsync(task.Id);
                    }
                }
                return true;
            }

            return false;
        }

        private async Task<bool> Process() {
            if (asyncLocking) {
                return false;
            }

            try {
                asyncLocking = true;

                var taskBoard = await packetWriter.RefreshTaskBoardAsync();
                if (taskBoard == null) {
                    return false;
                }

                if (taskBoard.DoneNum == taskBoard.MaxDoneNum) {
                    // Làm hết nhiệm vụ rồi.
                    dailyTaskCheck.Checked = false;
                    messageModel.Log(String.Format("[NVHN] Đã làm hết nhiệm vụ."));
                    return false;
                }

                if (await EnsureNoCompletedTask(taskBoard)) {
                    return true;
                }

                if (await EnsureNoMultipleAcceptedTask(taskBoard)) {
                    return true;
                }

                await Process(taskBoard);
                return true;
            } finally {
                asyncLocking = false;
            }
        }

        private class DailyTask {
            private ITaskHelper helper;
            private TaskInfo info;
            private TaskDetail detail;

            public int Id { get { return info.Id; } }
            public TaskState State { get { return info.State; } }
            public string Name { get { return detail.Name; } }
            public int Quality { get { return detail.Quality; } }
            public int Difficulty { get; private set; }

            public DailyTask(TaskInfo info, TaskDetail detail, ITaskHelper helper) {
                this.info = info;
                this.detail = detail;
                this.helper = helper;

                var times = detail.Quality - detail.DoneNum;
                Debug.Assert(times > 0);
                Difficulty = helper.PredictDifficulty(times);
            }

            public async Task<TaskResult> Do() {
                return await helper.Do(detail.Quality - detail.DoneNum);
            }
        }

        private async Task<TaskResult> Process(TaskBoard taskBoard) {
            Debug.Assert(asyncLocking);
            var tasks = await RefreshTaskDetails(taskBoard);
            if (tasks == null) {
                return TaskResult.LostConnection;
            }
            return await Process(taskBoard, tasks);
        }

        private async Task<TaskResult> Process(TaskBoard taskBoard, List<TaskDetail> tasks) {
            Debug.Assert(asyncLocking);
            var market = await packetWriter.RefreshMarketAsync();
            if (market == null) {
                return TaskResult.LostConnection;
            }

            var impose = await packetWriter.RefreshImposeAsync();
            if (impose == null) {
                return TaskResult.LostConnection;
            }

            const int MaxWeaponCount = 20;
            var upgrade = await packetWriter.RefreshUpgradeAsync(1, 0, MaxWeaponCount);
            if (upgrade == null) {
                return TaskResult.LostConnection;
            }

            var packet = await packetWriter.SendCommandAsync(41100, "1");
            if (packet == null) {
                return TaskResult.LostConnection;
            }
            var barracks = Barracks.Parse(JToken.Parse(packet.Message));

            var helpers = new Dictionary<TaskType, ITaskHelper>();
            helpers.Add(TaskType.Food, new FoodTaskHelper(packetWriter, infoModel, market));
            helpers.Add(TaskType.Improve, new ImproveTaskHelper(packetWriter, infoModel, barracks));
            helpers.Add(TaskType.Impose, new ImposeTaskHelper(packetWriter, infoModel, impose));
            helpers.Add(TaskType.AttackNpc, new AttackNpcTaskHelper(packetWriter, mcuModel));
            helpers.Add(TaskType.Upgrade, new UpgradeTaskHelper(packetWriter, infoModel, upgrade));

            return await Process(taskBoard, tasks, helpers);
        }

        private async Task<TaskResult> Process(TaskBoard taskBoard, List<TaskDetail> tasks, Dictionary<TaskType, ITaskHelper> helpers) {
            Debug.Assert(asyncLocking);
            Debug.Assert(taskBoard.Tasks.Count == tasks.Count);
            var dailyTasks = new List<DailyTask>();
            for (int i = 0; i < tasks.Count; ++i) {
                var detail = tasks[i];
                var type = detail.Type;
                if (!helpers.ContainsKey(type)) {
                    continue;
                }

                var info = taskBoard.Tasks[i];
                var helper = helpers[type];
                dailyTasks.Add(new DailyTask(taskBoard.Tasks[i], tasks[i], helper));
            }
            return await Process(dailyTasks);
        }

        private async Task<TaskResult> Process(List<DailyTask> tasks) {
            if (tasks.Count == 0) {
                return TaskResult.CanNotBeDone;
            }

            // Nhiệm vụ đang làm.
            var doingTask = tasks.FirstOrDefault(item => item.State == TaskState.Received);

            // Số sao ít nhất.
            var minQuality = tasks.Min(item => item.Quality);

            // Xét nhiệm vụ với số sao ít nhất và dễ nhất.
            var task = tasks
                .Where(item => item.Quality == minQuality)
                .MinBy(item => item.Difficulty);

            if (TaskDifficulty.CanDo(task.Difficulty)) {
                return await Process(doingTask, task);
            }


            // Xét nhiệm vụ nhiều sao hơn.
            var harderTasks = tasks.Where(item => item.Quality == minQuality + 1).ToList();
            if (harderTasks.Count > 0) {
                var harderTask = harderTasks.MinBy(item => item.Difficulty);
                return await Process(doingTask, harderTask);
            }

            return TaskResult.CanNotBeDone;
        }

        private async Task<TaskResult> Process(DailyTask acceptedTask, DailyTask bestTask) {
            if (acceptedTask != bestTask) {
                if (acceptedTask != null) {
                    // Khác nhiệm vụ.
                    // Huỷ cái cũ.
                    await packetWriter.CancelTaskAsync(acceptedTask.Id);
                }

                // Nhận cái mới.
                var p0 = await packetWriter.AcceptTaskAsync(bestTask.Id);
                if (p0 == null) {
                    return TaskResult.LostConnection;
                }
            }

            messageModel.Log(String.Format("[NVHN] Tiến hành làm nhiệm vụ {0} [{1} sao]",
                bestTask.Name, bestTask.Quality));

            var result = await bestTask.Do();
            if (result == TaskResult.Done) {
                // Phải làm mới lại danh sách nhiệm vụ thì mới hoàn thành được nhiêm vụ này.
                var p1 = await packetWriter.RefreshTaskBoardAsync();
                if (p1 == null) {
                    return TaskResult.LostConnection;
                }

                var p2 = await packetWriter.CompleteTaskAsync(bestTask.Id);
                if (p2 == null) {
                    return TaskResult.LostConnection;
                }

                if (p2.HasError) {
                    Debug.Assert(false);
                    return TaskResult.CanBeDone;
                }

                messageModel.Log(String.Format("[NVHN] Số nhiệm vu đã hoàn thành {0}/{1}",
                    p1.DoneNum + 1, p1.MaxDoneNum));
                return TaskResult.Done;
            }

            return result;
        }

        public async void ReportQuest(string username, string name) {
            //lay danh sach nhiem vu hang ngay

            var taskBoard = await packetWriter.RefreshTaskBoardAsync();
            if (taskBoard == null) {
                return;
            }

            //ghi file bao cao
            string fileName = DateTime.Now.Day + ".txt";
            using (StreamWriter w = new StreamWriter(fileName, true)) {
                w.WriteLine(username + " - " + name + " - " + taskBoard.DoneNum + "/" + taskBoard.MaxDoneNum);
                w.Close();
            }

        }

        private async void taskTimer_Tick(object sender, EventArgs e) {
            if (!dailyTaskCheck.Checked) {
                return;
            }

            if (timerLocking) {
                return;
            }

            try {
                timerLocking = true;
                await Process();
            } finally {
                timerLocking = false;
            }
        }
    }
}
