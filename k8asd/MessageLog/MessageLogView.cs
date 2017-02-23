using System.Windows.Forms;

namespace k8asd {
    public partial class MessageLogView : UserControl {
        private IMessageLogModel model;

        public MessageLogView() {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the model.
        /// </summary>
        /// <param name="model">The message log model</param>
        public void SetModel(IMessageLogModel model) {
            this.model = model;
            UpdateMessage(model.Message);
            model.MessageChanged += OnMessageChanged;
        }

        private void OnMessageChanged(object sender, string message) {
            UpdateMessage(message);
        }

        private void UpdateMessage(string message) {
            logBox.Text = message;
            logBox.SelectionStart = logBox.TextLength;
            logBox.ScrollToCaret();
        }
    }
}
