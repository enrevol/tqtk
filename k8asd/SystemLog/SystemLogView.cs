using System;
using System.Collections.Generic;
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
                    UpdateMessage();
                    foreach (var model in models) {
                        model.MessagesChanged += OnMessagesChanged;
                    }
                }
            }
        }

        private void OnMessagesChanged(object sender, EventArgs e) {
            UpdateMessage();
        }

        private void UpdateMessage() {
            //logBox.Text = message;
            //logBox.SelectionStart = logBox.TextLength;

            if (autoScrollBox.Checked) {
                Utils.ScrollToBottom(logBox);
            }
        }
    }
}
