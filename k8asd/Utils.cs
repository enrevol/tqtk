using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

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

        public static string FormatDuration(int seconds) {
            var span = TimeSpan.FromSeconds(seconds);
            return String.Format("{0:00}:{1:00}:{2:00}", span.Hours, span.Minutes, span.Seconds);
        }

        public static int ToUnixSeconds(this DateTime date) {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (int) ((date.ToUniversalTime() - epoch).TotalSeconds);
        }
    }
}
