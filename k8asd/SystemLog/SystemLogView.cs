using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace k8asd {
    public partial class SystemLogView : UserControl, ISystemLogView {
        private List<ISystemLog> models;

        public SystemLogView() {
            InitializeComponent();
        }

        public List<ISystemLog> Models {
            get { return models; }
            set {
                if (models != null) {
                    foreach (var model in models) {
                        model.MessagesChanged -= OnMessagesChanged;
                    }
                }
                models = value;
                if (models != null) {
                    UpdateMessages();
                    foreach (var model in models) {
                        model.MessagesChanged += OnMessagesChanged;
                    }
                }
            }
        }

        private void OnMessagesChanged(object sender, EventArgs e) {
            UpdateMessages();
        }

        private void UpdateMessages() {
            var messages = models
                .SelectMany(item => item.Messages)
                .OrderBy(item => item.TimeStamp)
                .TakeLast(50)
                .ToList();

            var builder = new StringBuilder();
            foreach (var message in messages) {
                if (builder.Length > 0) {
                    builder.Append(Environment.NewLine);
                }
                builder.Append(String.Format("[{0}] [{1}] {2}: {3}",
                    message.TimeStamp, message.Tag, message.Sender, message.Content));
            }

            logBox.Text = builder.ToString();
            if (autoScrollBox.Checked) {
                Utils.ScrollToBottom(logBox);
            }
        }
    }
}
