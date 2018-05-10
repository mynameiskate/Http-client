using System;
using System.IO;
using System.Net;
using System.Text;

namespace HttpProtocol
{
    class RequestConstructor
    {
        public RequestConstructor(string method, string uri, string data = "")
        {
            _method = method;
            _uri = uri;
            _data = data;
        }

        public WebRequest Request
        {
            get
            {
                return CreateRequest();
            }
        }

        private static int _timeOutLimit = 10000;
        private string _method;
        private string _uri;
        private string _data;

        public enum MethodType
        {
            GET,
            POST,
            HEAD
        }

        private WebRequest CreateRequest()
        {
            string result = String.Empty;
            WebRequest request = WebRequest.Create(_uri);
            request.Method = _method;
            request.Timeout = _timeOutLimit;

            if (!String.IsNullOrEmpty(_data))
            {
                byte[] postData = Encoding.UTF8.GetBytes(_data);
                using (Stream sendStream = request.GetRequestStream())
                {
                    sendStream.Write(postData, 0, postData.Length);
                }
            }
            return request;
        }
    }
}
