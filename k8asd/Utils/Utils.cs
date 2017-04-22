using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k8asd {
    public static class Utils {
        [Obsolete]
        public static async Task<Packet> SendCommandAsync(this IPacketWriter writer, string commandId, params string[] parameters) {
            return await writer.SendCommandAsync(Int32.Parse(commandId), parameters);
        }

        /// <summary>
        /// Compute the hash of the specified input string with the specified hasher.
        /// </summary>
        /// <param name="hasher">The hasher used to compute the hash.</param>
        /// <param name="input">The input used to compute the hash.</param>
        /// <returns></returns>
        public static string ComputeHash(HashAlgorithm hasher, string input) {
            var buffer = hasher.ComputeHash(Encoding.UTF8.GetBytes(input));
            // Two hex characters for each input character.
            var builder = new StringBuilder(input.Length * 2);
            foreach (var c in buffer) {
                builder.Append(c.ToString("x2"));
            }
            return builder.ToString();
        }

        public static string EncodeMessage(HashAlgorithm hasher, string userId, string sessionKey,
            string commandId, params string[] parameters) {
            const string what_is_this = "5dcd73d391c90e8769618d42a916ea1b";

            var input = commandId + userId;
            var msg = String.Format("{0}\x1{1}\t{2}\x2", commandId, userId, sessionKey);

            var timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1);
            var millisecondsSinceEpoch = (long) timeSpan.TotalMilliseconds;

            foreach (var parameter in parameters) {
                input += parameter;
                msg += parameter + '\t';
            }

            input += what_is_this;

            if (parameters.Length > 0) {
                msg = msg.Remove(msg.Length - 1);
            }

            var checksum = ComputeHash(hasher, input);
            msg += String.Format("\x3{0}\x4{1}\x5\0", checksum, millisecondsSinceEpoch);
            return msg;
        }

        /// <summary>
        /// Creates an address to the website that contains the game flash object.
        /// </summary>
        public static string CreateServerUrlAddress(int serverId) {
            return String.Format("http://app.slg.vn/tamquoctruyenky/slg?server={0}", serverId);
        }

        /// <summary>
        /// Asynchronously gets the source from the specified address with the specified cookie.
        /// </summary>
        public static async Task<string> GetSource(string urlAddress, CookieContainer cookie) {
            var request = (HttpWebRequest) WebRequest.Create(urlAddress);
            request.CookieContainer = cookie;
            return await GetSource(request, cookie);
        }

        /// <summary>
        /// Asynchronously gets the source from the specified request with the specified cookie.
        /// </summary>
        public static async Task<string> GetSource(HttpWebRequest request, CookieContainer cookie) {
            string htmlCode = null;
            using (var response = (HttpWebResponse) await request.GetResponseAsync()) {
                htmlCode = GetSource(response, cookie);
            }
            return htmlCode;
        }

        /// <summary>
        /// Gets the source from the specified response with the specified cookie.
        /// </summary>
        public static string GetSource(HttpWebResponse response, CookieContainer cookie) {
            string htmlCode = null;
            if (response.StatusCode == HttpStatusCode.OK) {
                cookie.Add(response.Cookies);
                using (var receivedStream = response.GetResponseStream()) {
                    if (response.CharacterSet == null) {
                        using (var reader = new StreamReader(receivedStream)) {
                            htmlCode = reader.ReadToEnd();
                        }
                    } else {
                        var encoding = Encoding.GetEncoding(response.CharacterSet);
                        using (var reader = new StreamReader(receivedStream, encoding)) {
                            htmlCode = reader.ReadToEnd();
                        }
                    }
                }
            }
            return htmlCode;
        }

        public static string FormatDuration(int milliseconds) {
            var span = TimeSpan.FromMilliseconds(milliseconds);
            return String.Format("{0:00}:{1:00}:{2:00}", span.Hours, span.Minutes, span.Seconds);
        }

        public static string FormatDuration(DateTime dateTime) {
            return String.Format("{0:00}:{1:00}:{2:00}", dateTime.Hour, dateTime.Minute, dateTime.Second);
        }

        public static DateTime ConvertToLocalTime(DateTime serverTime, long time) {
            var offset = serverTime - DateTime.Now;
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).ToLocalTime();
            var result = epoch.AddMilliseconds(time).Add(-offset);
            return result;
        }

        public static string GetMerchantName(this Merchant merchant) {
            switch (merchant) {
            case Merchant.LauLan: return "Lâu Lan";
            case Merchant.TayVuc: return "Tây Vực";
            case Merchant.BaThuc: return "Ba Thục";
            case Merchant.DaiLy: return "Đại Lý";
            case Merchant.ManNam: return "Mẫn Nam";
            case Merchant.LieuDong: return "Liêu Đông";
            case Merchant.QuanDong: return "Quan Đông";
            case Merchant.HoaiNam: return "Hoài Nam";
            case Merchant.KinhSo: return "Kinh Sở";
            case Merchant.NamViet: return "Nam Việt";
            case Merchant.TamDuong: return "Tầm Dương";
            case Merchant.LinhNam: return "Lĩnh Nam";
            }
            Debug.Assert(false);
            return String.Empty;
        }

        public static void Raise<T>(this EventHandler<T> handler, object sender, T arg) {
            handler?.Invoke(sender, arg);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        private const int WM_VSCROLL = 277;
        private const int SB_PAGEBOTTOM = 7;

        /// <summary>
        /// http://stackoverflow.com/questions/8535102/inconsistent-results-with-richtextbox-scrolltocaret
        /// An extension method to scroll the specified rich text box to the bottom.
        /// </summary>
        public static void ScrollToBottom(RichTextBox box) {
            SendMessage(box.Handle, WM_VSCROLL, (IntPtr) SB_PAGEBOTTOM, IntPtr.Zero);
        }

        /// <summary>
        /// http://stackoverflow.com/questions/5143599/detecting-whether-on-ui-thread-in-wpf-and-winforms
        /// Checks whether the current thread is UI Thread.
        /// </summary>
        public static bool CurrentlyOnUiThread(Control control) {
            return !control.InvokeRequired;
        }

        /// <summary>
        /// http://stackoverflow.com/questions/2652460/how-to-get-the-name-of-the-current-method-from-code
        /// Gets the current function's name.
        /// </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetMyMethodName() {
            var st = new StackTrace(new StackFrame(1));
            return st.GetFrame(0).GetMethod().Name;
        }

        /// <summary>
        /// http://stackoverflow.com/questions/22629951/suppressing-warning-cs4014-because-this-call-is-not-awaited-execution-of-the
        /// </summary>
        public static void Forget(this Task task) {
            task.ContinueWith(t => Console.WriteLine(t.Exception), TaskContinuationOptions.OnlyOnFaulted);
        }

        /// <summary>
        /// http://stackoverflow.com/questions/6993295/how-to-determine-if-the-tcp-is-connected-or-not
        /// </summary>
        public static bool IsClientConnected(TcpClient client) {
            try {
                if (client != null && client.Client != null && client.Client.Connected) {
                    /* pear to the documentation on Poll:
                     * When passing SelectMode.SelectRead as a parameter to the Poll method it will return 
                     * -either- true if Socket.Listen(Int32) has been called and a connection is pending;
                     * -or- true if data is available for reading; 
                     * -or- true if the connection has been closed, reset, or terminated; 
                     * otherwise, returns false
                     */

                    // Detect if client disconnected
                    if (client.Client.Poll(0, SelectMode.SelectRead)) {
                        byte[] buff = new byte[1];
                        if (client.Client.Receive(buff, SocketFlags.Peek) == 0) {
                            // Client disconnected
                            return false;
                        } else {
                            return true;
                        }
                    }

                    return true;
                } else {
                    return false;
                }
            } catch {
                return false;
            }
        }
    }
}
