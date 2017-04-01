using System.Drawing;
using System.Windows.Forms;

namespace k8asd {
    public partial class MessageLogView : UserControl {
        private IMessageLogModel model;

        private enum ChatBoxSize {
            Small,
            Medium,
            Large,
        }

        ChatBoxSize chatBoxSize;

        public MessageLogView() {
            InitializeComponent();

            chatBoxSize = ChatBoxSize.Small;
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

            if (autoScrollBox.Checked) {
                Utils.ScrollToBottom(logBox);
            }
        }

        private void changeSizeButton_Click(object sender, System.EventArgs e) {
            const int AdditionalHeight = 200;
            const int AdditionalWidth = 800;

            int deltaWidth = 0;
            int deltaHeight = 0;
            if (chatBoxSize == ChatBoxSize.Small) {
                chatBoxSize = ChatBoxSize.Medium;
                deltaHeight = AdditionalHeight;
                changeSizeButton.Text = "Vừa";
            } else if (chatBoxSize == ChatBoxSize.Medium) {
                chatBoxSize = ChatBoxSize.Large;
                deltaWidth = AdditionalWidth;
                changeSizeButton.Text = "Lớn";
            } else {
                chatBoxSize = ChatBoxSize.Small;
                deltaHeight = -AdditionalHeight;
                deltaWidth = -AdditionalWidth;
                changeSizeButton.Text = "Nhỏ";
            }

            Width += deltaWidth;
            Height += deltaHeight;
            Location = new Point(Location.X, Location.Y - deltaHeight);

            if (autoScrollBox.Checked) {
                Utils.ScrollToBottom(logBox);
            }
        }
    }
}
