using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace k8asd {
    public partial class PacketView : UserControl {
        private IPacketWriter packetWriter;

        public PacketView() {
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

        private async void sendButton_Click(object sender, System.EventArgs e) {
            var commandId = commandInput.Text;
            var param1 = param1Input.Text;
            var param2 = param2Input.Text;
            var param3 = param3Input.Text;
            var param4 = param4Input.Text;
            await SendCommand(commandId, param1, param2, param3, param4);
        }

        private async Task SendCommand(string commandId, params string[] parameters) {
            if (commandId.Length == 0) {
                return;
            }
            replyBox.Clear();
            var nonEmptyParameters = parameters.Where(p => p.Length > 0).ToArray();
            var packet = await packetWriter.SendCommandAsync(commandId, nonEmptyParameters);
            if (packet == null) {
                return;
            }
            replyBox.Text = packet.Message;
        }
    }
}
