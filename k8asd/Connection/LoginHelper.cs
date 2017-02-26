using System;
using System.Net;
using System.IO;
using System.Web;
using System.Threading.Tasks;

namespace k8asd {
    /// <summary>
    /// Indicates status for login helper.
    /// </summary>
    public enum LoginStatus {
        NoConnection,
        Succeeded,
        WrongUsernameOrPassword,
        UnknownError
    }

    /// <summary>
    /// A helper class used for logging in SLG account.
    /// </summary>
    public class LoginHelper {
        private const string SLGAddress0 = "http://tamquoctruyenky.vn/auth/login";
        private const string SLGAddress1 = "http://id.slg.vn/auth/login";
        private const string SLGAddress2 = "http://id.slg.vn/oath/authorize";

        private string username;
        private string password;
        private Session session;

        private CookieContainer cookie;

        /// <summary>
        /// Gets the username/email.
        /// </summary>
        public string Username { get { return username; } }

        /// <summary>
        /// Gets the password.
        /// </summary>
        public string Password { get { return password; } }

        /// <summary>
        /// Gets the current session info.
        /// </summary>
        public Session Session { get { return session; } }

        /// <summary>
        /// Constructs a login helper with the specified email and password.
        /// </summary>
        /// <param name="username">The email/username used for logging in.</param>
        /// <param name="password">The password used for logging in.</param>
        public LoginHelper(string username, string password) {
            this.username = username;
            this.password = password;
            session = new Session();
            cookie = new CookieContainer();
        }

        /// <summary>
        /// Parses the referer address from the specified html source code.
        /// </summary>
        private static string ParseReferer(string htmlCode) {
            // Example:
            // <form method="POST" action="http://id.slg.vn/oauth/authorize?redirect_uri=http%3A%2F%2Ftamquoctruyenky.vn%2Fauth%2Fcallback&amp;response_type=code&amp;client_id=4210935674" accept-charset="UTF-8">

            const string prefix = " action=\"";
            var prefixIndex = htmlCode.IndexOf(prefix);
            if (prefixIndex == -1) {
                return null;
            }

            const string suffix = "\" accept-charset";
            var suffixIndex = htmlCode.IndexOf(suffix);

            var beginIndex = prefixIndex + prefix.Length;
            var endIndex = suffixIndex;

            var address = htmlCode.Substring(beginIndex, endIndex - beginIndex);
            var decodedAddress = HttpUtility.HtmlDecode(address);
            return decodedAddress;
        }

        /// <summary>
        /// Parses the login token from the html source code.
        /// </summary>
        private static string ParseLoginToken(string htmlCode) {
            // Example html code:
            // <input type=\"hidden\" name=\"_token\" value=\"dQVExpyORASZp2zJrNcHJQCRorW3AYKWcbhVeVRc\">

            const string prefix = "name=\"_token\" value=\"";
            var index = htmlCode.IndexOf(prefix);
            if (index == -1) {
                // Could not find the prefix string.
                return null;
            }

            index += prefix.Length;

            // Login token has a fixed length of 40.
            const int TokenLength = 40;
            if (htmlCode.Length < index + TokenLength) {
                // Given html code is not long enough.
                return null;
            }

            var token = htmlCode.Substring(index, TokenLength);
            return token;
        }

        /// <summary>
        /// Asynchronously logins to the SLG account with the provided email and password.
        /// </summary>
        public async Task<LoginStatus> LoginAccount() {
            var htmlCode = await Utils.GetSource(SLGAddress0, cookie);
            if (htmlCode == null) {
                // Could not get html code from the login website.
                return LoginStatus.NoConnection;
            }

            var loginToken = ParseLoginToken(htmlCode);
            if (loginToken == null) {
                // Could not find the login token.
                return LoginStatus.UnknownError;
            }

            var referer = ParseReferer(htmlCode);
            if (referer == null) {
                // Could not find the referer address.
                return LoginStatus.UnknownError;
            }

            return await LoginAccount(referer, loginToken);
        }

        private async Task<HttpWebRequest> CreateWebRequest(string urlAddress, int timeOut, string content) {
            var request = (HttpWebRequest) WebRequest.Create(urlAddress);
            request.Timeout = timeOut;
            request.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:6.0) Gecko/20100101 Firefox/6.0";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.Headers.Add("Accept-Language", "en-us,en;q=0.5");
            // request.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
            // request.Headers.Add("Accept-Language", "en-us,en;q=0.8");
            request.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.7");
            // request.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.3");
            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentLength = content.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = cookie;

            using (var writer = new StreamWriter(await request.GetRequestStreamAsync())) {
                writer.Write(content);
            }
            return request;
        }

        /// <summary>
        /// Attempts to login SLG account with the provided email and password and the specified login token.
        /// </summary>
        public async Task<LoginStatus> LoginAccount(string address, string loginToken) {
            var content = String.Format("_token={0}&callback=&email={1}&password={2}", loginToken, username, password);
            var request = await CreateWebRequest(address, 2000, content);

            var htmlCode = await Utils.GetSource(request, cookie);
            if (htmlCode == null) {
                return LoginStatus.NoConnection;
            }

            // Wrong Username or Password.
            const string Error = "Wrong Username or Password";
            var index = htmlCode.IndexOf(Error);
            if (index != -1) {
                return LoginStatus.WrongUsernameOrPassword;
            }

            return LoginStatus.Succeeded;
        }

        /// <summary>
        /// Asynchronously logins into TQTK server.
        /// </summary>
        /// <param name="serverId">The server id.</param>
        public async Task<LoginStatus> LoginServer(int serverId) {
            var urlAddress = Utils.CreateServerUrlAddress(serverId);
            return await LoginServer(urlAddress);
        }

        public async Task<LoginStatus> LoginServer(string urlAddress) {
            var htmlCode = await Utils.GetSource(urlAddress, cookie);
            if (htmlCode == null) {
                return LoginStatus.NoConnection;
            }

            // Reset the current session.
            session.Reset();

            // Example html code:
            // <iframe style=\"overflow: hidden;width: 1000px; height: 600px;\" src=\"http://api.tamquoc.slg.vn/login/login?userid=5542014&amp;GameId=18903335&amp;ServerId=1&amp;Sign=e826a4b8445ea4bb6c7602c2b0b3e63e&amp;Time=1479405081&amp;al=1&amp;from=&amp;siteurl=\" frameborder=\"0\" scrolling=\"no\"></iframe>

            const string prefix = "src=\"";
            int index = htmlCode.IndexOf(prefix);
            if (index == -1) {
                // Could not find the prefix string.
                return LoginStatus.UnknownError;
            }

            index += prefix.Length;
            var suffixIndex = htmlCode.IndexOf("\" frameborder", index);
            if (suffixIndex == -1) {
                // Could not find the suffix string.
                return LoginStatus.UnknownError;
            }

            var length = suffixIndex - index;
            var address = htmlCode.Substring(index, length);

            var decodedAddress = HttpUtility.HtmlDecode(address);
            var srcHtmlCode = await Utils.GetSource(decodedAddress, cookie);

            // Example htmlCode.
            //  var flashvars = {\r\n            userID : 5542014,\r\n            ip : 's1.tamquoc.slg.vn',\r\n            ports : '6001',\r\n            sessionKey : \"e2f380ab136ee18d25ada0912c29e8e4\",\r\n            locale:\"vi_VN\",\r\n            version:\"1.01\",\r\n            reportURL:\"http://s1.tamquoc.slg.vn/\",\r\n            customerURL:\"http://s1.tamquoc.slg.vn/sfadm/\",\r\n            gameURL:\"http://s1.tamquoc.slg.vn/\",\r\n            loginURL:\"http://tqtk.slg.vn/\",\r\n            rechargeURL:\"http://pay.slg.vn/topcoin\",\r\n\r\n            fid:\"null\",\r\n            bfid:\"null\",\r\n            rootpath:\"http://tamquoc-cdn-slg.cdn.vccloud.vn/7_0_0_0_27/\"\r\n        };

            // Parse the session.
            var parseSucceeded = session.Parse(srcHtmlCode);
            if (!parseSucceeded) {
                return LoginStatus.UnknownError;
            }

            return LoginStatus.Succeeded;
        }
    }
}
