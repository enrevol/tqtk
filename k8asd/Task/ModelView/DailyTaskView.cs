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
        }

        public async void ReportQuest(string username, string name) {
            //lay danh sach nhiem vu hang ngay

            /*
            var taskBoard = await Client.RefreshTaskBoardAsync();
            if (taskBoard == null) {
                return;
            }

            //ghi file bao cao
            string fileName = DateTime.Now.Day + ".txt";
            using (StreamWriter w = new StreamWriter(fileName, true)) {
                w.WriteLine(username + " - " + name + " - " + taskBoard.DoneNum + "/" + taskBoard.MaxDoneNum);
                w.Close();
            }
            */

        }
    }
}
