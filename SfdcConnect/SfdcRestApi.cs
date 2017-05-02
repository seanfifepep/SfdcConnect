/****************************************************************************
*
*   File name: SfdcRestApi.cs
*   Author: Sean Fife
*   Create date: 4/20/2016
*   Solution: SfdcConnect
*   Project: SfdcConnect
*   Description: Includes the SfdcRestApi class for Salesforce REST Api Connections
*
****************************************************************************/
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SfdcConnect.SoapObjects;

namespace SfdcConnect
{
    /// <summary>
    /// Salesforce REST Api connection class
    /// </summary>
    public class SfdcRestApi : SfdcConnection
    {
        public SfdcRestApi()
            : base()
        {

            lastStatusCode = HttpStatusCode.OK;
        }
        public SfdcRestApi(string uri)
            : base(uri)
        {

            lastStatusCode = HttpStatusCode.OK;
        }
        public SfdcRestApi(bool isTest, int apiversion)
            : base(isTest, apiversion)
        {
            lastStatusCode = HttpStatusCode.OK;
        }

        string baseUrl = "";
        HttpStatusCode lastStatusCode;
        ApiLimits apiLimits = null;

        /// <summary>
        /// Open a connection to Salesforce.  Requires Usernamd and Password to be filled in.
        /// </summary>
        public override void Open()
        {
            base.Open();

            baseUrl = "https://" + ApiEndPoint.Host;
        }
        /// <summary>
        /// Open a connection to Salesforce asynchronously.  Requires Usernamd and Password to be filled in.
        /// </summary>
        public override void OpenAsync()
        {
            if (state == ConnectionState.Open) return;
            state = ConnectionState.Connecting;

            loginCompleted += ls_restloginCompleted;
            LoginAsync(Username, Password + Token);

            //return default(Task);
        }
        /// <summary>
        /// Open a connection to Salesforce asynchronously.  Requires Usernamd and Password to be filled in.
        /// </summary>
        public override async Task OpenAsync(CancellationToken cancellationToken)
        {
            if (state == ConnectionState.Open) return;
            state = ConnectionState.Connecting;

            loginCompleted += ls_restloginCompleted;
            await LoginAsync(Username, Password + Token, cancellationToken);
        }

        /// <summary>
        /// Callback for OpenAsync calls
        /// </summary>
        /// <param name="sender">should be this object</param>
        /// <param name="e">Event Args holding the login information from Salesforce</param>
        private void ls_restloginCompleted(object sender, loginCompletedEventArgs e)
        {

            LoginTime = DateTime.Now;
            Url = e.Result.serverUrl;
            SessionHeaderValue = new SessionHeader();
            SessionHeaderValue.sessionId = e.Result.sessionId;

            SessionId = e.Result.sessionId;
            ServerUrl = e.Result.serverUrl;

            string[] pieces = ServerUrl.Split('/');

            Version = pieces[pieces.Length - 2];

            ApiEndPoint = new Uri(e.Result.serverUrl);

            baseUrl = "https://" + ApiEndPoint.Host;

            state = ConnectionState.Open;
        }

        public string SendRequest(string uri, string method, string payload = null, bool isJson = false, string[] additionalHeaders = null)
        {
            switch (method)
            {
                case "GET":
                    return DoGet(uri, additionalHeaders);
                case "POST":
                    return DoPost(uri, payload, isJson, additionalHeaders);
                case "DELETE":
                    return DoDelete(uri, payload, additionalHeaders);
                case "PUT":
                    return DoPut(uri, payload, additionalHeaders);
                case "PATCH":
                    return DoPatch(uri, payload, additionalHeaders);
                default:
                    throw new Exception("Invalid web request method: " + method);
            }
        }
        private string DoGet(string uri, string[] additionalHeaders = null)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.AllowReadStreamBuffering = false;
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Headers.Add("Authorization: Bearer " + SessionId);
            if (additionalHeaders != null)
            {
                foreach (string s in additionalHeaders)
                {
                    request.Headers.Add(s);
                }
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                lastStatusCode = response.StatusCode;
                using (StreamReader resp = new StreamReader(response.GetResponseStream()))
                {
                    return resp.ReadToEnd();
                }
            }
        }
        private string DoPost(string uri, string postData, bool isJson = false, string[] additionalHeaders = null)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.Method = "POST";
            if (isJson)
            {
                request.ContentType = "application/json; charset=UTF-8";
                request.Accept = "application/json";
            }
            else
            {
                request.ContentType = "application/x-www-form-urlencoded";//"multipart/form-data"
            }
            request.Headers.Add("Authorization: Bearer " + SessionId);
            if (additionalHeaders != null)
            {
                foreach (string s in additionalHeaders)
                {
                    request.Headers.Add(s);
                }
            }

            byte[] buffer = null;
            buffer = System.Text.Encoding.UTF8.GetBytes(postData);

            Stream postStream = request.GetRequestStream();
            postStream.Write(buffer, 0, buffer.Length);

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    lastStatusCode = response.StatusCode;
                    using (StreamReader resp = new StreamReader(response.GetResponseStream()))
                    {
                        return resp.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                string msg = "";

                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    WebResponse resp = ex.Response;
                    msg = new System.IO.StreamReader(resp.GetResponseStream()).ReadToEnd().Trim();
                }

                return msg;
                //throw new SalesforceException(msg, ex);
            }
        }
        private string DoDelete(string uri, string additionalData, string[] additionalHeaders = null)
        {
            return default(string);
        }
        private string DoPut(string uri, string additionalData, string[] additionalHeaders = null)
        {
            return default(string);
        }
        private string DoPatch(string uri, string additionalData, string[] additionalHeaders = null)
        {
            return default(string);
        }

        public AvailableResources GetAvilableResources()
        {
            string url = baseUrl + string.Format("/services/data/v{0}.0/", Version);

            return JsonConvert.DeserializeObject<AvailableResources>(SendRequest(url, "GET"));
        }

        public ApiLimits GetLimits(bool refresh = true)
        {
            if (refresh)
            {
                string url = baseUrl + string.Format("/services/data/v{0}/limits/", Version);

                apiLimits = JsonConvert.DeserializeObject<ApiLimits>(SendRequest(url, "GET"));
            }

            return apiLimits;
        }

        //public object GetSObjects()
        //{
        //    string url = baseUrl + string.Format("/services/data/v{0}.0/sobjects/", APIVersion);
        //}

        public object GetSObject(DateTime ifModifiedSince)
        {
            string url = baseUrl + string.Format("/services/data/v{0}/sobjects/", Version);
            string header = "If-Modified-Since: " + ToSalesforceAPIHeaderDateTimeString(ifModifiedSince);//.ToString("ddd, dd MMM yyyy HH:mm:ss z");

            string whatsChanged = SendRequest(url, "GET", string.Empty, false, new string[] { header });

            if (lastStatusCode == HttpStatusCode.NotModified)
            {
                //nothing changed
                return null;
            }
            else
            {
                //something changed
                //deserialize response.
                return JsonConvert.DeserializeObject(whatsChanged);
            }
        }

        public string combine(DedupeRESTPacket packet)
        {
            string dedupeData = JsonConvert.SerializeObject(packet);

            string url = baseUrl + string.Format("/services/apexrest/dedupe/combine/", Version);

            return SendRequest(url, "POST", dedupeData, true);
        }

        //public object GetSObject(string objectApiName)
        //{
        //    string url = baseUrl + string.Format("/services/data/v{0}.0/sobjects/{1}", APIVersion, objectApiName);
        //}

        //public object GetSObject(string objectApiName, DateTime ifModifiedSince)
        //{
        //    string url = baseUrl + string.Format("/services/data/v{0}.0/sobjects/{1}", APIVersion, objectApiName);
        //    string header = "If-Modified-Since: " + ifModifiedSince.ToString("ddd, dd MMM yyyy HH:mm:ss z");
        //}

        //public object GetSObjectMetadata(string objectApiName)
        //{
        //    string url = baseUrl + string.Format("/services/data/v{0}.0/sobjects/{1}/describe", APIVersion, objectApiName);
        //}

        //public object GetSObjectMetadata(string objectApiName, DateTime ifModifiedSince)
        //{
        //    string url = baseUrl + string.Format("/services/data/v{0}.0/sobjects/{1}/describe", APIVersion, objectApiName);
        //    string header = "If-Modified-Since: " + ifModifiedSince.ToString("ddd, dd MMM yyyy HH:mm:ss z");
        //}

        public static string ToSalesforceAPIHeaderDateTimeString(DateTime dt)
        {
            return dt.ToString("ddd, dd MMM yyyy HH:mm:ss z");
        }

        public string StandardAPICall(string endPoint, string method, string package, string contentType, string accept, string[] additionalHeaders = null)
        {
            //should this endPoint just be the entire uri? or perhaps just the location?
            if (endPoint[0] != '/') endPoint = '/' + endPoint;
            string url = baseUrl + string.Format("/services/data/v{0}{1}", Version, endPoint);
            string returnValue = "";

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = method;
            request.ContentType = contentType;
            request.Accept = accept;

            request.Headers.Add("Authorization: Bearer " + SessionId);


            if (additionalHeaders != null)
            {
                foreach (string s in additionalHeaders)
                {
                    request.Headers.Add(s);
                }
            }

            //everything but get can have data to send
            if (method.ToUpper() != "GET" && package.Trim().Length > 0)
            {
                byte[] buffer = null;
                buffer = System.Text.Encoding.UTF8.GetBytes(package);

                Stream postStream = request.GetRequestStream();
                postStream.Write(buffer, 0, buffer.Length);
            }

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    lastStatusCode = response.StatusCode;
                    using (StreamReader resp = new StreamReader(response.GetResponseStream()))
                    {
                        returnValue = resp.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                string msg = "";

                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    WebResponse resp = ex.Response;
                    msg = new System.IO.StreamReader(resp.GetResponseStream()).ReadToEnd().Trim();
                }

                //throw new SalesforceException(msg, ex);
                returnValue = msg;
            }

            return returnValue;
        }
        public string CustomAPICall(string endPoint, string method, string package, string contentType, string accept, string[] additionalHeaders = null)
        {
            string url = baseUrl + string.Format("/services/apexrest/{0}", endPoint);

            return "";
        }
    }
}
