using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k8asd {
    public static class Utils {
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
    }
}
