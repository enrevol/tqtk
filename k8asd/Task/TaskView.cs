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

        public async Task Auto() {
            var taskBoard = await packetWriter.RefreshListQuestAsync();
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

            var taskId = taskBoard.TaskIds[taskDetails.IndexOf(task)];

            // Nhận nhiêm vụ.
            var p0 = await packetWriter.AcceptQuestAsync(taskId);
            if (p0 == null) {
                return;
            }

            if (task.Type == TaskType.Food) {
                for (int i = 0; i < task.Quality; ++i) {
                    var p1 = await packetWriter.SalePaddyAsync();
                    if (p1 == null) {
                        return;
                    }

                    /*
                    JToken token = JToken.Parse(packet.Message);
                    //xu ly mua ban khong thanh cong do da ban het lua
                    if (token["message"] != null && token["message"].ToString() == "Hôm nay không có đủ lượng giao dịch") {
                        //neu da ban het lua thi mua cho den
                        packet = await packetWriter.BuyPaddyInMaketAsync();
                        if (packet == null) //gui packet that bai
                        {
                            return;
                        }
                        //xu ly khong the mua lua cho den (chua co acc test) co the huy nhiem vu nay nhan nhiem vu ke
                        //...
                    }
                    */
                }
            }
            if (task.Type == TaskType.Improve) {
                // Cải tiến.
                // var p2 = await packetWriter.GetListHeroAsync();
                //lay danh sach tuong
                /*
                packet = await packetWriter.GetListHeroAsync();
                if (packet == null) {
                    return;
                }

                Barracks barracks = Barracks.Parse(JToken.Parse(packet.Message));
                //lay id tuong dau tien
                int id = barracks.Heroes[0].Id;

                for (int i = 0; i < qInfo.listQuest[check].quality; i++) {
                    //cai tien tuong
                    packet = await packetWriter.HeroImproveAsync(id);
                    if (packet == null) //gui packet that bai
                    {
                        return;
                    }

                    //xu ly khong du chien tich (chua lam)

                    //cai tien thanh cong xu ly giu chi so
                    packet = await packetWriter.NotUpdateHeroImproveAsync(id);
                }
                */
            }
            if (task.Type == TaskType.Impose) {
                /*
                for (int i = 0; i < qInfo.listQuest[check].quality; i++) {
                    //thu thue
                    packet = await packetWriter.CollectTaxAsync();
                    if (packet == null) //gui packet that bai
                    {
                        return;
                    }
                    JToken token = JToken.Parse(packet.Message);
                    if (token["message"] != null && (token["message"].ToString() == "Không thể tiếp tục tăng cường thu thuế trong hôm nay" || token["message"].ToString() == "Thao tác này đang đóng băng")) {
                        //neu da het so lan thu thue thi tang cuong thue
                        packet = await packetWriter.IncreaseTaxAsync();
                        if (packet == null) //gui packet that bai
                        {
                            return;
                        }
                        //xu ly het xu tang cuong (chua lam)
                        //...
                    }
                }
                */
            }
            if (task.Type == TaskType.Gold) {
                /*
                for (int i = 0; i < qInfo.listQuest[check].quality; i++) {
                    //thu thue
                    packet = await packetWriter.IncreaseTaxAsync();
                    if (packet == null) //gui packet that bai
                    {
                        return;
                    }

                    //xu ly het xu tang cuong
                    JToken token = JToken.Parse(packet.Message);
                    if (token["message"] != null && token["message"].ToString() != "") {
                        this.timerQuest.Stop();
                        this.chkQuest.Checked = false;
                        break;
                    }
                }
                */
            }

            var p2 = await packetWriter.CompleteQuestAsync(taskId);
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
