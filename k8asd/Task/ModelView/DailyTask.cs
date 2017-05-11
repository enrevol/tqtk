using MoreLinq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k8asd {
    public class DailyTask : IDailyTask {
        private IClient client;
        private Timer taskTimer;

        private bool processing;
        private bool timerLocking;

        private bool enabled;
        private int attempts;

        public IClient Client {
            get { return client; }
            set {
                client = value;
            }
        }

        public bool Enabled {
            get { return enabled; }
            set {
                enabled = value;
                attempts = 0;
            }
        }

        public DailyTask() {
            processing = false;
            timerLocking = false;

            enabled = false;
            attempts = 0;

            taskTimer = new Timer();
            taskTimer.Tick += OnTaskTimerTick;
            taskTimer.Start();
        }

        private async Task<bool> Process() {
            if (processing) {
                return false;
            }

            try {
                processing = true;

                var taskBoard = await Client.RefreshTaskBoardAsync();
                if (taskBoard == null) {
                    return false;
                }

                if (taskBoard.DoneNum == taskBoard.MaxDoneNum) {
                    // Làm hết nhiệm vụ rồi.
                    // FIXME.
                    client.GetComponent<ISystemLog>().Log("NVHN", "Đã làm hết nhiệm vụ.");
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
                processing = false;
            }
        }

        public async Task<List<TaskDetail>> RefreshTaskDetails(TaskBoard board) {
            var taskDetails = new List<TaskDetail>();
            foreach (var task in board.Tasks) {
                var detail = await Client.RefreshTaskAsync(task.Id);
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
            Debug.Assert(processing);
            foreach (var task in taskBoard.Tasks) {
                if (task.State == TaskState.Completed) {
                    // Hoàn thành nhiệm vụ.
                    var packet = await Client.CompleteTaskAsync(task.Id);
                    if (packet == null) {
                        return false;
                    }
                    Client.GetComponent<ISystemLog>().Log("[NVHN]", String.Format("Hoàn thành nhiệm vụ ID {0}", task.Id));
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra xem có nhận nhiều nhiệm vụ một lúc không?
        /// </summary>
        private async Task<bool> EnsureNoMultipleAcceptedTask(TaskBoard taskBoard) {
            Debug.Assert(processing);
            var acceptedTasks = taskBoard.Tasks.Where(item => item.State == TaskState.Received).ToList();
            if (acceptedTasks.Count <= 1) {
                return false;
            }

            // Huỷ hết.
            Client.GetComponent<ISystemLog>().Log("[NVHN]", "Đang nhận nhiều nhiệm vụ, huỷ tất cả!");
            foreach (var task in acceptedTasks) {
                var packet = await Client.CancelTaskAsync(task.Id);
                if (packet == null) {
                    break;
                }
            }
            return true;
        }

        private class DailyTaskWrapper {
            private ITaskHelper helper;
            private TaskInfo info;
            private TaskDetail detail;

            public int Id { get { return info.Id; } }
            public TaskState State { get { return info.State; } }
            public string Name { get { return detail.Name; } }
            public int Quality { get { return detail.Quality; } }
            public int Difficulty { get; private set; }

            public DailyTaskWrapper(TaskInfo info, TaskDetail detail, ITaskHelper helper) {
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
            Debug.Assert(processing);
            var tasks = await RefreshTaskDetails(taskBoard);
            if (tasks == null) {
                return TaskResult.LostConnection;
            }
            return await Process(taskBoard, tasks);
        }

        private async Task<TaskResult> Process(TaskBoard taskBoard, List<TaskDetail> tasks) {
            Debug.Assert(processing);
            var market = await Client.RefreshMarketAsync();
            if (market == null) {
                return TaskResult.LostConnection;
            }

            var impose = await Client.RefreshImposeAsync();
            if (impose == null) {
                return TaskResult.LostConnection;
            }

            const int MaxWeaponCount = 20;
            var upgrade = await Client.RefreshUpgradeAsync(1, 0, MaxWeaponCount);
            if (upgrade == null) {
                return TaskResult.LostConnection;
            }

            var packet = await Client.SendCommandAsync(41100, "1");
            if (packet == null) {
                return TaskResult.LostConnection;
            }
            var barracks = Barracks.Parse(JToken.Parse(packet.Message));

            var helpers = new Dictionary<TaskType, ITaskHelper>();
            // FIXME.
            //helpers.Add(TaskType.Food, new FoodTaskHelper(Client));
            //helpers.Add(TaskType.Improve, new ImproveTaskHelper(packetWriter, infoModel, barracks));
            //helpers.Add(TaskType.Impose, new ImposeTaskHelper(packetWriter, infoModel, impose));
            //helpers.Add(TaskType.AttackNpc, new AttackNpcTaskHelper(packetWriter, mcuModel));
            //helpers.Add(TaskType.Upgrade, new UpgradeTaskHelper(packetWriter, infoModel, upgrade));

            return await Process(taskBoard, tasks, helpers);
        }

        private async Task<TaskResult> Process(TaskBoard taskBoard, List<TaskDetail> tasks, Dictionary<TaskType, ITaskHelper> helpers) {
            Debug.Assert(processing);
            Debug.Assert(taskBoard.Tasks.Count == tasks.Count);
            var dailyTasks = new List<DailyTaskWrapper>();
            for (int i = 0; i < tasks.Count; ++i) {
                var detail = tasks[i];
                var type = detail.Type;
                if (!helpers.ContainsKey(type)) {
                    continue;
                }

                var info = taskBoard.Tasks[i];
                var helper = helpers[type];
                dailyTasks.Add(new DailyTaskWrapper(taskBoard.Tasks[i], tasks[i], helper));
            }
            return await Process(dailyTasks);
        }

        private async Task<TaskResult> Process(List<DailyTaskWrapper> tasks) {
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

        private async Task<TaskResult> Process(DailyTaskWrapper acceptedTask, DailyTaskWrapper bestTask) {
            if (acceptedTask != bestTask) {
                if (acceptedTask != null) {
                    // Khác nhiệm vụ.
                    // Huỷ cái cũ.
                    await Client.CancelTaskAsync(acceptedTask.Id);
                }

                // Nhận cái mới.
                var p0 = await Client.AcceptTaskAsync(bestTask.Id);
                if (p0 == null) {
                    return TaskResult.LostConnection;
                }
            }

            Client.GetComponent<ISystemLog>().Log("NVHN",
                String.Format("Tiến hành làm nhiệm vụ {0} [{1} sao]",
                bestTask.Name, bestTask.Quality));

            var result = await bestTask.Do();
            if (result == TaskResult.Done) {
                // Phải làm mới lại danh sách nhiệm vụ thì mới hoàn thành được nhiêm vụ này.
                var p1 = await Client.RefreshTaskBoardAsync();
                if (p1 == null) {
                    return TaskResult.LostConnection;
                }

                var p2 = await Client.CompleteTaskAsync(bestTask.Id);
                if (p2 == null) {
                    return TaskResult.LostConnection;
                }

                if (p2.HasError) {
                    Debug.Assert(false);
                    return TaskResult.CanBeDone;
                }

                Client.GetComponent<ISystemLog>().Log("NVHN",
                    String.Format("Số nhiệm vu đã hoàn thành {0}/{1}",
                    p1.DoneNum + 1, p1.MaxDoneNum));
                return TaskResult.Done;
            }

            return result;
        }

        private async void OnTaskTimerTick(object sender, EventArgs e) {
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
