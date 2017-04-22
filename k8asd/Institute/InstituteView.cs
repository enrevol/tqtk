using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace k8asd {
    public partial class InstituteView : UserControl {
        private InstituteInfo instituteInfo;

        private IPacketWriter packetWriter;
        private IMessageLogModel messageLogModel;
        private IInfoModel infoModel;

        private bool asyncLock;
        private bool timerLock;
        private bool newValueChecked;

        public InstituteView() {
            InitializeComponent();

            asyncLock = false;
            timerLock = false;
            newValueChecked = false;
            instituteInfo = null;

            nameColumn.AspectGetter = obj => {
                return instituteInfo.Techs.Find(tech => tech.Id == (int) obj).Name;
            };
            levelColumn.AspectGetter = obj => {
                return instituteInfo.Techs.Find(tech => tech.Id == (int) obj).Level;
            };
            extraColumn.AspectGetter = obj => {
                var tech = instituteInfo.Techs.Find(item => item.Id == (int) obj);
                return String.Format("+{0}{1}", tech.Extra, tech.ValueUnit);
            };
            valueColumn.AspectGetter = obj => {
                var tech = instituteInfo.Techs.Find(item => item.Id == (int) obj);
                return String.Format("+{0}{1}", tech.Value, tech.ValueUnit);
            };
        }

        public void SetPacketWriter(IPacketWriter writer) {
            packetWriter = writer;
        }

        public void SetMessageLogModel(IMessageLogModel model) {
            messageLogModel = model;
        }

        public void SetInfoModel(IInfoModel model) {
            infoModel = model;
        }

        private async Task<bool> RefreshInstitute() {
            if (asyncLock) {
                return false;
            }
            try {
                asyncLock = true;
                instituteInfo = await packetWriter.RefreshInstituteAsync();
                if (instituteInfo == null) {
                    return false;
                }
                var techIds = new List<int>();
                foreach (var tech in instituteInfo.Techs) {
                    techIds.Add(tech.Id);
                }
                techList.SetObjects(techIds, true);
                return true;
            } finally {
                asyncLock = false;
            }
        }

        private async Task<bool> ImproveTech(int techId) {
            if (asyncLock) {
                return false;
            }
            try {
                asyncLock = true;
                var p = await packetWriter.ImproveInstituteTechAsync(techId, InstituteImproveType.PhoThong);
                if (p == null || p.HasError) {
                    return false;
                }
                return true;
            } finally {
                asyncLock = false;
            }
        }

        private async Task<bool> ChangeBetterStats(int techId) {
            if (asyncLock) {
                return false;
            }
            try {
                asyncLock = true;
                if (instituteInfo == null) {
                    return false;
                }
                var tech = instituteInfo.Techs.Find(item => item.Id == techId);
                if (tech.NewValue == 0) {
                    return true;
                }
                if (tech.NewValue <= tech.Value) {
                    return true;
                }
                messageLogModel.LogInfo(String.Format("[SNC] {0}: {1} +{2}{3} => +{4}{5}",
                    tech.Name, tech.Desc, tech.Value, tech.ValueUnit, tech.NewValue, tech.ValueUnit));
                var p = await packetWriter.ChangeInstituteTechAsync(techId);
                if (p == null || p.HasError) {
                    return false;
                }
                return true;
            } finally {
                asyncLock = false;
            }
        }

        private async void refreshButton_Click(object sender, EventArgs e) {
            await RefreshInstitute();
        }

        private void techList_SelectedIndexChanged(object sender, EventArgs e) {
            var selectedItem = techList.SelectedItem;
            if (selectedItem == null) {
                return;
            }
            var id = (int) selectedItem.RowObject;
            var tech = instituteInfo.Techs.Find(item => item.Id == id);
            infoBox.Text = String.Format("{0} - Cấp {1}", tech.Name, tech.Level);
        }

        private async void improveTimer_Tick(object sender, EventArgs e) {
            if (!autoImproveBox.Checked) {
                return;
            }
            if (timerLock) {
                return;
            }

            try {
                timerLock = true;
                var selectedItem = techList.SelectedItem;
                if (selectedItem == null) {
                    return;
                }
                var id = (int) selectedItem.RowObject;

                // Kiểm tra xem đã có làm mới từ trước chưa.
                if (!newValueChecked) {
                    newValueChecked = true;
                    if (!await ChangeBetterStats(id)) {
                        autoImproveBox.Checked = false;
                        return;
                    }
                }

                // Làm mới (cải tiến).
                if (!await ImproveTech(id)) {
                    autoImproveBox.Checked = false;
                    return;
                }

                // Làm mới sở nghiên cứu để biết giá trị mới.
                if (!await RefreshInstitute()) {
                    autoImproveBox.Checked = false;
                    return;
                }

                // Kiểm tra để giữ/thay thế.
                if (!await ChangeBetterStats(id)) {
                    autoImproveBox.Checked = false;
                    return;
                }
            } finally {
                timerLock = false;
            }
        }

        private void autoImproveBox_CheckedChanged(object sender, EventArgs e) {
            if (autoImproveBox.Checked) {
                newValueChecked = false;
            }
        }
    }
}
