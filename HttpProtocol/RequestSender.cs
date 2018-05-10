using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
 
namespace HttpProtocol
{
    class RequestSender
    {
        public static string Status { get; set; }

        public static void GetHeaders(WebRequest request, HttpWebResponse response)
        {
            if (response == null || request == null) return;
            string message = (int)response.StatusCode + " " + response.StatusDescription + "\n" +
                "URL: " + request.RequestUri + "\nMethod type: " + 
                request.Method + "\nRequest data type: " + response.ContentType + "\nHeaders:";
            WebHeaderCollection whc = response.Headers;
            var headers = Enumerable.Range(0, whc.Count)
                                    .Select(p =>
                                    {
                                        return new
                                        {
                                            Key = whc.GetKey(p),
                                            Names = whc.GetValues(p)
                                        };
                                    });

            foreach (var item in headers)
            {
                message += "\n  " + item.Key + ":";
                foreach (var n in item.Names)
                    message += " " + n;
            }
            Status = message;
        }

        public static async Task<string> SendRequest(string methodType, string uri, string data = "")
        {
            string result = String.Empty;
            var httpRequest = new RequestConstructor(methodType, uri, data);
            result = await ReadResponseAsync(httpRequest.Request);
            return result;
        }

        private static async Task<string> ReadResponseAsync(WebRequest request)
        {
            string result = String.Empty;
            try
            {
                WebResponse response = await Task.Run(() => request.GetResponseAsync()); //request.GetResponseAsync();
                GetHeaders(request, (HttpWebResponse)response);
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        result = sr.ReadToEnd();
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
