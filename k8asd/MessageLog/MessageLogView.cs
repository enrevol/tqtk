using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k8asd {
    public partial class MessageLogView : UserControl {
        private IMessageLogModel model;

        public MessageLogView() {
            InitializeComponent();
        }

        public void SetModel(IMessageLogModel model) {
            this.model = model;
            model.MessageChanged += OnMessageChanged;
        }

        private void OnMessageChanged(object sender, string message) {
            logBox.Text = message;
            logBox.SelectionStart = logBox.TextLength;
            logBox.ScrollToCaret();
        }
    }
}
