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

namespace k8asd {
    public partial class TaskView : UserControl {
        private IPacketWriter packetWriter;

        public TaskView() {
            InitializeComponent();
        }

        public void SetPacketWriter(IPacketWriter writer) {
            if (packetWriter != null) {
                packetWriter.PacketReceived -= OnPacketReceived;
            }
            packetWriter = writer;
            packetWriter.PacketReceived += OnPacketReceived;
        }

        private void OnPacketReceived(object sender, Packet packet) {
            //
        }

        public void EnableAutoQuest() {
            this.chkQuest.Checked = true;
        }

        public void DisableAutoQuest() {
            this.chkQuest.Checked = false;
        }

        private void chkQuest_CheckedChanged(object sender, EventArgs e) {
            if (chkQuest.Checked) {
                timerQuest.Start();
            } else {
                timerQuest.Stop();
            }
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

        public async Task<bool> DoTask(TaskType type, int times) {
            var helpers = new Dictionary<TaskType, ITaskHelper>();
            helpers.Add(TaskType.Food, new FoodTaskHelper());
            helpers.Add(TaskType.Improve, new ImproveTaskHelper());
            helpers.Add(TaskType.Impose, new ImposeTaskHelper());

            if (!helpers.ContainsKey(type)) {
                return false;
            }

            var helper = helpers[type];
            if (!await helper.CanDo(packetWriter, times)) {
                return false;
            }

            if (!await helper.Do(packetWriter, times)) {
                return false;
            }
            return false;
        }

        private async Task<bool> DoAttackNpcTask(int times) {
            // Nguỵ Tục - Lữ Bố.
            const int NpcId = 2214;

            for (int i = 0; i < times; ++i) {
                if (!await DoAttackNpcSubtask(NpcId)) {
                    return false;
                }
            }
            return true;
        }

        private async Task<bool> DoAttackNpcSubtask(int npcId) {
            var p = await packetWriter.AttackNpcAsync(npcId, PartyType.Normal);
            if (p == null) {
                return false;
            }

            if (p.HasError) {
                return false;
            }

            /// FIXME.
            //xu ly chinh chien that bai (chua lam)
            //if (token["battlereport"]["message"].ToString() == "Ngài đã thất bại .....")
            //{
            //    //phai danh lai cho du so sao (chua lam)
            //}
            return true;
        }

        private async Task<bool> DoUpgradeTask(int times) {
            /*
             //lay id vu khi trang dau tien
                        //lay danh sach vu khi
                        packet = await packetWriter.GetListWeaponsAsync();
                        if (packet == null) //gui packet that bai
                        {
                            return;
                        }

                        JToken token = JToken.Parse(packet.Message);
                        JArray arrequip = (JArray)tokenn["equip"];

                        string magic = tokenn["magic"].ToString();
                        string storeid = "";
                        for (int i = 0; i < arrequip.Count; i++)
                        {
                            JObject objCur = (JObject)arrequip[i];
                            if (objCur["quality"].ToString() == "1")
                            {
                                storeid = objCur["storeid"].ToString();
                                break;
                            }
                        }

                        //xu ly neu co vu khi
                        if (storeid != "")
                        {
                            //ha cap trang bi
                            packet = await packetWriter.DownGradeWeaponsAsync(storeid);
                            if (packet == null) //gui packet that bai
                            {
                                return;
                            }

                            //nang cap trang bi
                            for (int i = 0; i < qInfo.listQuest[check].quality;)
                            {
                                //nang cap trang bi
                                packet = await packetWriter.UpGradeWeaponsAsync(storeid, magic);
                                if (packet == null) //gui packet that bai
                                {
                                    return;
                                }


                                token = JToken.Parse(packet.Message);

                                //xu ly khong du bac de nang cap (chua chinh xac)
                                if (token["message"] != null && token["message"].ToString().Contains("đủ"))
                                {
                                    packet = await packetWriter.CancelQuestAsync(qInfo.listQuest[check].id);
                                    removeQuest = check;
                                    return;
                                }

                                if (token["message"] != null && token["message"].ToString() == "Thất bại! Chúc may mắn lần sau!")
                                {
                                    //xu ly nhan nhiem vu khac (chua lam)
                                }
                                else
                                {
                                    i++;
                                }
                            }
                        }
                        else
                        {
                            packet = await packetWriter.CancelQuestAsync(qInfo.listQuest[check].id);
                            removeQuest = check;
                            return;
                        }
                        */
            return true;
        }

        private async Task<bool> DoGoldTask(int times) {
            ////thu thue
            //packet = await packetWriter.IncreaseTaxAsync();
            //if (packet == null) //gui packet that bai
            //{
            //    return;
            //}

            ////xu ly het xu tang cuong, dang le cho nhan nhiem vu khac nhung cho ngung han
            //JToken token = JToken.Parse(packet.Message);
            //if (token["message"] != null && token["message"].ToString() != "")
            //{
            //    this.timerQuest.Stop();
            //    this.chkQuest.Checked = false;
            //    break;
            //}


            /*
            //uy phai ngua lv1
            packet = await packetWriter.CommissionAsync();
            if (packet == null) //gui packet that bai
            {
                return;
            }

            JToken token = JToken.Parse(packet.Message);
            //xu ly khong du bac (chua chinh xac)
            if (token["message"] != null && (token["message"].ToString().Contains("đủ"))) {
                packet = await packetWriter.CancelQuestAsync(qInfo.listQuest[check].id);
                removeQuest = check;
                return;
            }

            //nhan vat pham
            packet = await packetWriter.AcceptCommissionAsync();
            if (packet == null) //gui packet that bai
            {
                return;
            }

            //pha bang
            packet = await packetWriter.BreakIceCommissionAsync();
            if (packet == null) //gui packet that bai
            {
                return;
            }
            //xu ly khong du xu (chua chinh xac)
            if (token["message"] != null && (token["message"].ToString().Contains("đủ"))) {
                packet = await packetWriter.CancelQuestAsync(qInfo.listQuest[check].id);
                removeQuest = check;
                return;
            }
            */
            return true;
        }

        public async Task Auto() {
            var taskBoard = await packetWriter.RefreshTaskBoardAsync();
            if (taskBoard == null) {
                return;
            }

            if (taskBoard.DoneNum == taskBoard.MaxDoneNum) {
                timerQuest.Stop();
                chkQuest.Checked = false;
                return;
            }

            var taskDetails = await RefreshTaskDetails(taskBoard);

            /*
            ???
            if (qInfo.listQuest == null || qInfo.listQuest[qInfo.listQuest.Count - 1].quality == 0) {
                return;
            }
            */

            /*
             * ???
            int check = FindQuest(qInfo.listQuest, qInfo.listQuest[qInfo.listQuest.Count - 1].quality);
            if (check == -2) {
                return;
            }
            */

            var task = FindQuest(taskDetails);
            if (task == null) {
                timerQuest.Stop();
                chkQuest.Checked = false;
                return;
            }

            var taskId = taskBoard.Tasks[taskDetails.IndexOf(task)];

            // Nhận nhiêm vụ.
            var p0 = await packetWriter.AcceptTaskAsync(taskId.Id);
            if (p0 == null) {
                return;
            }



            var p2 = await packetWriter.CompleteTaskAsync(taskId.Id);
            if (p2 == null) {
                /// FIXME.
            }
        }

        private TaskDetail FindQuest(List<TaskDetail> taskDetails) {
            int minQuality = taskDetails.Min(item => item.Quality);
            if (minQuality == 4) {
                return null;
            }

            var reversedList = taskDetails.Reverse<TaskDetail>();
            foreach (var task in reversedList) {
                if (task.Type == TaskType.Food && task.Quality == minQuality) {
                    return task;
                }
            }

            foreach (var task in reversedList) {
                if (task.Type == TaskType.Improve && task.Quality == minQuality) {
                    return task;
                }
            }

            foreach (var task in reversedList) {
                if (task.Type == TaskType.Impose && task.Quality == minQuality) {
                    return task;
                }
            }

            //co the lam them nhiem vu chinh phuc clone
            //co the lam them nhiem vu chinh chien
            //co the lam them nhiem vu nang cap do
            //co the lam them nhiem vu tan cong

            foreach (var task in reversedList) {
                if (task.Type == TaskType.Gold && task.Quality == minQuality) {
                    return task;
                }
            }

            return null;

            /*
            if (listQuest == null || quality == 0) {
                return -2;
            }
            //quality = quality + 1;
            //return FindQuest(listQuest, quality);
            return -1;
            */
        }

        public async void ReportQuest(string username, string name) {
            //lay danh sach nhiem vu hang ngay            
            /*
            var packet = await packetWriter.RefreshListQuestAsync();
            if (packet == null) {
                return;
            }
            JToken tokenn = JToken.Parse(packet.Message);
            if (tokenn["message"] != null && tokenn["message"].ToString() != "") {
                return;
            }
            TaskBoard qInfo = TaskBoard.Parse(JToken.Parse(packet.Message));
            //ghi file bao cao
            string fileName = DateTime.Now.Day + ".txt";
            using (StreamWriter w = new StreamWriter(fileName, true)) {
                w.WriteLine(username + " - " + name + " - " + qInfo.donenum + "/6");
                w.Close();
            }
            */
        }

        private async Task DoTask(TaskDetail task) {

        }

        private async void timerQuest_Tick(object sender, EventArgs e) {
            await Auto();
        }
    }
}
