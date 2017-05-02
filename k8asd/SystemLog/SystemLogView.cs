using System.Drawing;
using System.Windows.Forms;

namespace k8asd {
    public partial class SystemLogView : UserControl, ISystemLogView {
        private ISystemLog systemLog;

        public SystemLogView() {
            InitializeComponent();
        }

        public ISystemLog SystemLog {
            get { return systemLog; }
            set {
                if (systemLog != null) {
                    systemLog.MessageChanged -= OnMessageChanged;
                }
                systemLog = value;
                if (systemLog != null) {
                    UpdateMessage(systemLog.Message);
                    systemLog.MessageChanged += OnMessageChanged;
                }
            }
        }

        private void OnMessageChanged(object sender, string message) {
            UpdateMessage(message);
        }

        private void UpdateMessage(string message) {
            logBox.Text = message;
            logBox.SelectionStart = logBox.TextLength;

            if (autoScrollBox.Checked) {
                Utils.ScrollToBottom(logBox);
            }
        }
    }
}
