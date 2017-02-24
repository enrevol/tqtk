using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
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

        public static string CreateServerUrlAddress(int serverId) {
            return String.Format("http://app.slg.vn/tamquoctruyenky/slg?server={0}", serverId);
        }

        public static string GetSource(string urlAddress, CookieContainer cookie) {
            var request = (HttpWebRequest) WebRequest.Create(urlAddress);
            request.CookieContainer = cookie;
            return GetSource(request, cookie);
        }

        public static string GetSource(HttpWebRequest request, CookieContainer cookie) {
            string htmlCode = null;
            using (var response = (HttpWebResponse) request.GetResponse()) {
                htmlCode = GetSource(response, cookie);
            }
            return htmlCode;
        }

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

        public static int RemainingMilliseconds(this DateTime dateTime) {
            return Math.Max(0, (int) (dateTime - DateTime.Now).TotalMilliseconds);
        }

        public static void Raise<T>(this EventHandler<T> handler, object sender, T arg) {
            handler?.Invoke(sender, arg);
        }

        // http://stackoverflow.com/questions/8535102/inconsistent-results-with-richtextbox-scrolltocaret
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        private const int WM_VSCROLL = 277;
        private const int SB_PAGEBOTTOM = 7;

        public static void ScrollToBottom(RichTextBox box) {
            SendMessage(box.Handle, WM_VSCROLL, (IntPtr) SB_PAGEBOTTOM, IntPtr.Zero);
        }

        // http://stackoverflow.com/questions/5143599/detecting-whether-on-ui-thread-in-wpf-and-winforms
        public static bool CurrentlyOnUiThread(Control control) {
            return !control.InvokeRequired;
        }

        // http://stackoverflow.com/questions/2652460/how-to-get-the-name-of-the-current-method-from-code
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetMyMethodName() {
            var st = new StackTrace(new StackFrame(1));
            return st.GetFrame(0).GetMethod().Name;
        }
    }
}
