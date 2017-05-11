using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace k8asd {
    public partial class SystemLogView : UserControl, IClientComponentView<ISystemLog> {
        private List<ISystemLog> models;
        private bool dirty;

        public SystemLogView() {
            InitializeComponent();
            models = null;
            dirty = false;
        }

        public List<ISystemLog> Models {
            get { return models; }
            set {
                UnbindModels();
                models = value;
                BindModels();
            }
        }

        public void BindModels() {
            if (models == null || models.Count == 0) {
                return;
            }
            foreach (var model in models) {
                model.MessagesChanged += OnMessagesChanged;
            }
            dirty = true;
        }

        public void UnbindModels() {
            if (models == null || models.Count == 0) {
                return;
            }
            foreach (var model in models) {
                model.MessagesChanged -= OnMessagesChanged;
            }
            dirty = true;
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
                builder.Append(message.Format());
            }

            logBox.Text = builder.ToString();
        }

        private void TryScrollBox() {
            if (autoScrollBox.Checked) {
                Utils.ScrollToBottom(logBox);
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e) {
            if (dirty) {
                dirty = false;
                UpdateMessages();
                TryScrollBox();
            }
        }
    }
}
