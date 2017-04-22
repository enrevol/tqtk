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
                var detail = await packetWriter.GetStartOfQuestAsync(task.Id);
                if (detail == null) {
                    return null;
                }
                taskDetails.Add(detail);
            }
            return taskDetails;
        }

        public async Task<bool> DoTask(TaskType type, int times) {
            if (type == TaskType.Food) {
                return await DoFoodTask(times);
            }
            return false;
        }

        private async Task<bool> DoFoodTask(int times) {
            for (int i = 0; i < times; ++i) {
                if (!await DoFoodSubtask()) {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Làm nhiệm vụ mua bán lúa 1 lần.
        /// </summary>
        private async Task<bool> DoFoodSubtask() {
            const int amount = 1;
            var p = await packetWriter.SalePaddyAsync(amount);
            if (p == null) {
                return false;
            }
            if (p.HasError) {
                // Hết số lượng giao dịch.
                // Số bạc tràn kho.

                var p0 = await packetWriter.BuyPaddyAsync(amount);
                if (p0 == null) {
                    return false;
                }
                if (p0.HasError) {
                    // Hết số lượng giao dịch.
                    // Lúa tràn kho.

                    var p1 = await packetWriter.BuyPaddyInMaketAsync(amount);
                    if (p1 == null || p1.HasError) {
                        return false;
                    }
                    return true;
                }
                return false;
            }
            return true;
        }

        private async Task<bool> DoImproveTask(int times) {
            var p = await packetWriter.GetListHeroAsync();
            if (p == null) {
                return false;
            }

            var barracks = Barracks.Parse(JToken.Parse(p.Message));

            // Cải tiến tướng đầu tiên.
            var heroId = barracks.Heroes[0].Id;

            // Giữ chỉ số cũ (trường hợp đã cải tiến trước).
            // Tránh lỗi: "Võ tướng có thuộc tính mới chưa thay"
            var p0 = await packetWriter.NotUpdateHeroImproveAsync(heroId);
            if (p0 == null) {
                return false;
            }

            for (int i = 0; i < times; ++i) {
                if (!await DoImproveSubtask(heroId)) {
                    return false;
                }
            }
            return true;
        }

        private async Task<bool> DoImproveSubtask(int heroId) {
            var p1 = await packetWriter.HeroImproveAsync(heroId);
            if (p1 == null) {
                return false;
            }

            if (p1.HasError) {
                // Không đủ chiến tích.
                return false;
            }

            // Giữ chỉ số.
            var p2 = packetWriter.NotUpdateHeroImproveAsync(heroId);
            if (p2 == null) {
                return false;
            }

            return true;
        }

        private async Task<bool> DoAttackNpcTask(int times) {
            for (int i = 0; i < times; ++i) {
                /*
                 //chinh chien nguy tuc - lu bo
                            packet = await packetWriter.BattleNguyTucAsync();
                            if (packet == null) //gui packet that bai
                            {
                                return;
                            }

                            JToken token = JToken.Parse(packet.Message);
                            //if (token["message"] != null && token["message"].ToString() == "Không đủ lượt")
                            //{
                            //    removeQuest = check;
                            //    return;
                            //}
                            if (token["message"] != null)
                            {
                                packet = await packetWriter.CancelQuestAsync(qInfo.listQuest[check].id);
                                removeQuest = check;
                                return;
                            }

                            //xu ly chinh chien that bai (chua lam)
                            //if (token["battlereport"]["message"].ToString() == "Ngài đã thất bại .....")
                            //{
                            //    //phai danh lai cho du so sao (chua lam)
                            //}
                            */
            }
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

        private async Task<bool> DoImposeTask(int times) {

            /*
             * 
             *  //thu thue
                            packet = await packetWriter.CollectTaxAsync();
                            if (packet == null) //gui packet that bai
                            {
                                return;
                            }
                            JToken token = JToken.Parse(packet.Message);
                            if (token["message"] != null && (token["message"].ToString() == "Không thể tiếp tục tăng cường thu thuế trong hôm nay" || token["message"].ToString() == "Thao tác này đang đóng băng"))
                            {
                                //neu da het so lan thu thue thi tang cuong thue
                                packet = await packetWriter.IncreaseTaxAsync();
                                if (packet == null) //gui packet that bai
                                {
                                    return;
                                }
                                //xu ly het xu tang cuong (chua lam)
                                //...
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
