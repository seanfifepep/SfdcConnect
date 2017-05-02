/****************************************************************************
*
*   File name: SfdcBulkApi.cs
*   Author: Sean Fife
*   Create date: 4/20/2016
*   Solution: SfdcConnect
*   Project: SfdcConnect
*   Description: Includes the SfdcBulkApi class for Salesforce Bulk Api Connections.
*                   Modified from a BulkApiClient implementation found on the net.
*
****************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SfdcConnect
{
    public enum ContentType { None, CSV, XML, ZIP_CSV, ZIP_XML };
    public enum Operations { update, insert, upsert, delete, hardDelete, query };
    public enum ConcurrencyMode { Parallel, Serial };
    public enum WebMethod { GET, POST, HEAD, DELETE };
    public enum JobOperation { Query, Insert, Update, Delete, HardDelete, Upsert }
    public enum JobContentType { CSV, XML }

    /// <summary>
    /// Salesforce Bulk Api connection class
    /// </summary>
    public class SfdcBulkApi : SfdcConnection
    {
        const string jobRequestXMLTemplate = "<?xml version=\"1.0\" encoding=\"UTF-8\"?> <jobInfo xmlns=\"http://www.force.com/2009/06/asyncapi/dataload\"> <operation>{0}</operation> <object>{1}</object> {4} {3} {2} </jobInfo>";

        Semaphore sammy = new Semaphore(0, 1);

        public SfdcBulkApi()
            : base()
        {
        }
        public SfdcBulkApi(string uri)
            : base(uri)
        {
        }
        public SfdcBulkApi(bool isTest, int apiversion)
            : base(isTest, apiversion)
        {
        }

        #region Jobs
        public Job CreateJob(string SfObject, ContentType contentType, Operations operation, ConcurrencyMode mode, string ExternalIdFieldName)
        {
            string jobRequestXML = "";
            String externalField = String.Empty;

            if (String.IsNullOrWhiteSpace(ExternalIdFieldName) == false)
            {
                externalField = "<externalIdFieldName>" + ExternalIdFieldName + "</externalIdFieldName>";
            }
            if (contentType != ContentType.None)
            {
                jobRequestXML = String.Format(jobRequestXMLTemplate,
                                              operation.ToString(),
                                              SfObject,
                                              "<contentType>" + contentType.ToString() + "</contentType>",
                                              externalField,
                                              (operation == Operations.upsert ? "" : "<concurrencyMode>" + mode.ToString() + "</concurrencyMode>"));
            }
            else
            {
                jobRequestXML = String.Format(jobRequestXMLTemplate,
                                              operation.ToString(),
                                              SfObject,
                                              "",
                                              externalField,
                                              (operation == Operations.upsert ? "" : "<concurrencyMode>" + mode.ToString() + "</concurrencyMode>"));
            }

            String createJobUrl = "https://" + ApiEndPoint.Host + "/services/async/" + Version.ToString() + "/job";
            //String createJobUrl = "https://" + +"-api.salesforce.com/services/async/" + api + "/job";

            //jobRequestXML = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><jobInfo xmlns=\"http://www.force.com/2009/06/asyncapi/dataload\">  <operation>query</operation>   <object>Opportunity</object>   <concurrencyMode>Parallel</concurrencyMode>    <contentType>CSV</contentType> </jobInfo>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(jobRequestXML);

            String resultXML = invokeRestAPI(createJobUrl, doc.InnerXml);//, "POST", "application/xml; charset=UTF-8");

            return Job.Create(resultXML);
        }

        public Job CloseJob(Job job)//String jobId)
        {
            String closeJobUrl = buildSpecificJobUrl(job.Id);
            String closeRequestXML =
            @"<?xml version=""1.0"" encoding=""UTF-8""?>" + Environment.NewLine +
            @"<jobInfo xmlns=""http://www.force.com/2009/06/asyncapi/dataload"">" + Environment.NewLine +
             "<state>Closed</state>" + Environment.NewLine +
             "</jobInfo>";

            String resultXML = invokeRestAPI(closeJobUrl, closeRequestXML);

            return Job.Create(resultXML);
        }

        public Job GetJob(Job job)//String jobId)
        {
            String getJobUrl = buildSpecificJobUrl(job.Id);

            String resultXML = invokeRestAPI(getJobUrl);

            return Job.Create(resultXML);
        }
        #endregion

        #region Batches
        public Batch CreateBatch(Job job, string batchContents, string batchContentType, string batchContentHeader)//, CreateBatchRequest createBatchRequest)
        {
            String requestUrl = "https://" + ApiEndPoint.Host + "/services/async/" + Version + "/job/" + job.Id + "/batch";

            String requestXML = batchContents;

            String contentType = batchContentType;// job.ContentType;

            if (batchContentType != "")
            {
                contentType = batchContentHeader;
            }

            String resultXML = invokeRestAPI(requestUrl, requestXML, "Post", contentType, contentType == "xml");

            return Batch.CreateBatch(resultXML);
        }

        public Batch GetBatch(Job job, Batch batch)
        {
            String requestUrl = "https://" + ApiEndPoint.Host + "/services/async/" + Version.ToString() + "/job/" + job.Id + "/batch/" + batch.Id;

            String resultXML = invokeRestAPI(requestUrl);

            return Batch.CreateBatch(resultXML);
        }

        public List<Batch> GetBatches(String jobId)
        {
            String requestUrl = "https://" + ApiEndPoint.Host + "/services/async/" + Version.ToString() + "/job/" + jobId + "/batch/";

            String resultXML = invokeRestAPI(requestUrl);

            return Batch.CreateBatches(resultXML);
        }

        public String GetBatchRequest(String jobId, String batchId)
        {
            String requestUrl = "https://" + ApiEndPoint.Host + "/services/async/" + Version.ToString() + "/job/" + jobId + "/batch/" + batchId + "/request";

            String resultXML = invokeRestAPI(requestUrl);

            return resultXML;
        }

        public String GetBatchResults(Job job, Batch batch)
        {
            String requestUrl = "https://" + ApiEndPoint.Host + "/services/async/" + Version.ToString() + "/job/" + job.Id + "/batch/" + batch.Id + "/result";

            String resultXML = invokeRestAPI(requestUrl);

            return resultXML;
        }
        public bool GetQueryBatchResults(Job job, Batch batch, string filename, bool truncateFile)
        {
            String requestUrl = "https://" + ApiEndPoint.Host + "/services/async/" + Version.ToString() + "/job/" + job.Id + "/batch/" + batch.Id + "/result";

            String resultXML = invokeRestAPI(requestUrl);

            List<String> resultIds = GetResultIds(resultXML);

            if (resultIds.Count > 0)
            {
                FileStream file = null;
                FileInfo fi = new FileInfo(filename);
                if (truncateFile && fi.Exists)
                {
                    file = new FileStream(filename, FileMode.OpenOrCreate | FileMode.Truncate, FileAccess.ReadWrite);
                }
                else
                {
                    file = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                }
                using (StreamWriter output = new StreamWriter(file, System.Text.Encoding.UTF8))
                {
                    foreach (string id in resultIds)
                    {
                        string url = requestUrl + "/" + id;

                        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                        //request.SendChunked = true;
                        //request.TransferEncoding = "UTF-8";
                        request.AllowReadStreamBuffering = false;
                        request.Method = "GET";
                        request.Headers.Add("X-SFDC-Session: " + ApiEndPoint.Host + "/services/async/" + SessionId);

                        using (HttpWebResponse response = (HttpWebResponse)(request.GetResponse()))
                        {
                            Stream data = response.GetResponseStream();

                            byte[] xfer = new byte[16 * 1024];
                            char[] chars = null;
                            int readBytes = 0;
                            while ((readBytes = data.Read(xfer, 0, xfer.Length)) > 0)
                            {
                                chars = System.Text.Encoding.UTF8.GetChars(xfer);

                                output.Write(chars, 0, readBytes);
                            }

                            output.Flush();

                            response.Close();
                        }
                    }
                    output.Close();
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool GetQueryBatchResults(Job job, Batch batch, string filename, bool truncateFile, Action<string, int> callback)
        {
            String requestUrl = "https://" + ApiEndPoint.Host + "/services/async/" + Version.ToString() + "/job/" + job.Id + "/batch/" + batch.Id + "/result";

            String resultXML = invokeRestAPI(requestUrl);

            List<String> resultIds = GetResultIds(resultXML);

            int bytesDownloaded = 0;
            if (resultIds.Count > 0)
            {
                FileStream file = null;
                FileInfo fi = new FileInfo(filename);
                if (truncateFile && fi.Exists)
                {
                    file = new FileStream(filename, FileMode.OpenOrCreate | FileMode.Truncate, FileAccess.ReadWrite);
                }
                else
                {
                    file = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                }
                //FileStream file = new FileStream(filename, FileMode.OpenOrCreate | FileMode.Truncate, FileAccess.ReadWrite);
                StreamWriter output = new StreamWriter(file, System.Text.Encoding.UTF8);
                foreach (string id in resultIds)
                {
                    string url = requestUrl + "/" + id;

                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                    //request.SendChunked = true;
                    //request.TransferEncoding = "UTF-8";
                    request.AllowReadStreamBuffering = false;
                    request.Method = "GET";
                    request.Headers.Add("X-SFDC-Session: " + ApiEndPoint.Host + "/services/async/" + SessionId);

                    using (HttpWebResponse response = (HttpWebResponse)(request.GetResponse()))
                    {
                        Stream data = response.GetResponseStream();

                        byte[] xfer = new byte[16 * 1024];
                        char[] chars = null;
                        int readBytes = 0;
                        while ((readBytes = data.Read(xfer, 0, xfer.Length)) > 0)
                        {
                            chars = System.Text.Encoding.UTF8.GetChars(xfer);

                            output.Write(chars, 0, readBytes);

                            bytesDownloaded += readBytes;
                            callback(string.Format("{0:N0} bytes downloaded", bytesDownloaded), 0);
                        }

                        output.Flush();

                        response.Close();
                    }
                }
                output.Close();
                output.Dispose();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool GetQueryBatchResults(Job job, Batch batch, string filename, bool truncateFile, Action<string, bool> callback)
        {
            String requestUrl = "https://" + ApiEndPoint.Host + "/services/async/" + Version.ToString() + "/job/" + job.Id + "/batch/" + batch.Id + "/result";

            String resultXML = invokeRestAPI(requestUrl);

            List<String> resultIds = GetResultIds(resultXML);

            int bytesDownloaded = 0;
            if (resultIds.Count > 0)
            {
                FileStream file = null;
                FileInfo fi = new FileInfo(filename);
                if (truncateFile && fi.Exists)
                {
                    file = new FileStream(filename, FileMode.OpenOrCreate | FileMode.Truncate, FileAccess.ReadWrite);
                }
                else
                {
                    file = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                }
                //FileStream file = new FileStream(filename, FileMode.OpenOrCreate | FileMode.Truncate, FileAccess.ReadWrite);
                StreamWriter output = new StreamWriter(file, System.Text.Encoding.UTF8);
                foreach (string id in resultIds)
                {
                    string url = requestUrl + "/" + id;

                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                    //request.SendChunked = true;
                    //request.TransferEncoding = "UTF-8";
                    //request.AllowReadStreamBuffering = false;
                    request.Method = "GET";
                    request.Headers.Add("X-SFDC-Session: " + ApiEndPoint.Host + "/services/async/" + SessionId);

                    using (HttpWebResponse response = (HttpWebResponse)(request.GetResponse()))
                    {
                        Stream data = response.GetResponseStream();

                        byte[] xfer = new byte[32 * 1024];
                        char[] chars = null;
                        int readBytes = 0;
                        while ((readBytes = data.Read(xfer, 0, xfer.Length)) > 0)
                        {
                            chars = System.Text.Encoding.UTF8.GetChars(xfer);

                            output.Write(chars, 0, readBytes);

                            bytesDownloaded += readBytes;
                            callback(string.Format("{0:N0} bytes downloaded", bytesDownloaded), true);

                            Array.Clear(xfer, 0, xfer.Length);
                        }

                        output.Flush();

                        response.Close();
                    }
                }
                output.Close();
                output.Dispose();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> GetQueryBatchResultsAsync(Job job, Batch batch, string filename)
        {
            String requestUrl = "https://" + ApiEndPoint.Host + "/services/async/" + Version.ToString() + "/job/" + job.Id + "/batch/" + batch.Id + "/result";

            String resultXML = invokeRestAPI(requestUrl);

            List<String> resultIds = GetResultIds(resultXML);

            if (resultIds.Count > 0)
            {
                FileStream file = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamWriter output = new StreamWriter(file, System.Text.Encoding.UTF8);
                foreach (string id in resultIds)
                {
                    string url = requestUrl + "/" + id;

                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                    //request.SendChunked = true;
                    //request.TransferEncoding = "UTF-8";
                    request.AllowReadStreamBuffering = false;
                    request.Method = "GET";
                    request.Headers.Add("X-SFDC-Session: " + ApiEndPoint.Host + "/services/async/" + SessionId);

                    using (HttpWebResponse response = (HttpWebResponse)(await request.GetResponseAsync()))
                    {
                        Stream data = response.GetResponseStream();

                        byte[] xfer = new byte[16 * 1024];
                        char[] chars = null;
                        int readBytes = 0;
                        while ((readBytes = await data.ReadAsync(xfer, 0, xfer.Length)) > 0)
                        {
                            chars = System.Text.Encoding.UTF8.GetChars(xfer);

                            await output.WriteAsync(chars, 0, readBytes);

                            //await output.WriteAsync(xfer, 0, readBytes);

                        }

                        output.Flush();

                        response.Close();
                    }
                }
                output.Close();
                output.Dispose();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<String> GetResultIds(String queryBatchResultListXML)
        {
            //<result-list xmlns="http://www.force.com/2009/06/asyncapi/dataload"><result>752x000000000F1</result></result-list>

            XDocument doc = XDocument.Parse(queryBatchResultListXML);
            List<String> resultIds = new List<string>();

            XElement resultListElement = doc.Root;

            foreach (XElement resultElement in resultListElement.Elements())
            {
                String resultId = resultElement.Value;
                resultIds.Add(resultId);
            }

            return resultIds;
        }

        public String GetBatchResult(String jobId, String batchId, String resultId)
        {
            String requestUrl = "https://" + ApiEndPoint.Host + "/services/async/" + Version.ToString() + "/job/" + jobId + "/batch/" + batchId + "/result/" + resultId;

            String resultXML = invokeRestAPI(requestUrl);

            return resultXML;
        }
        #endregion

        private String buildSpecificJobUrl(String jobId)
        {
            return "https://" + ApiEndPoint.Host + "/services/async/" + Version.ToString() + "/job/" + jobId;
        }

        private string webRequest(string url, WebMethod method, string data, string contentType)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = method.ToString();
            byte[] buffer = null;
            if (SessionId != "")
            {
                request.ContentType = contentType;
                request.Headers.Add("X-SFDC-Session: " + SessionId);
                buffer = System.Text.Encoding.ASCII.GetBytes(data);
            }
            else
            {
                request.ContentType = "text/xml; charset=utf-8";
                request.Headers.Add("SOAPAction: login");
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(data);
                buffer = System.Text.Encoding.ASCII.GetBytes(doc.InnerXml);
            }
            //"text/csv; charset=UTF-8" or "application/xml; charset=UTF-8"

            Stream postStream = request.GetRequestStream();
            postStream.Write(buffer, 0, buffer.Length);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader resp = new StreamReader(response.GetResponseStream());

            return resp.ReadToEnd();
        }

        private String invokeRestAPI(String endpointURL)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(endpointURL);
            request.AllowReadStreamBuffering = false;
            request.Method = "GET";
            request.Headers.Add("X-SFDC-Session: " + SessionId);
            //WebClient wc = buildWebClient();
            //wc.Headers.Add("X-SFDC-Session: " + sessionId);
            //wc.Headers.Add("Content-Type: text/csv; charset=UTF-8");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader resp = new StreamReader(response.GetResponseStream());

            return resp.ReadToEnd();
            //return wc.DownloadString(endpointURL);
        }
        private String invokeRestAPI(String endpointURL, String postData)
        {
            return invokeRestAPI(endpointURL, postData, "POST", String.Empty);
        }
        private String invokeRestAPI(String endpointURL, String postData, String httpVerb, String contentType, bool isXml = true)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(endpointURL);
            request.Method = httpVerb;

            //WebClient wc = buildWebClient();

            request.Headers.Add("X-SFDC-Session: " + SessionId);
            //wc.Headers.Add("X-SFDC-Session", sessionId);
            //wc.Headers.Add("Content-Type", "application/xml; charset=UTF-8");
            if (String.IsNullOrWhiteSpace(contentType) == false)
            {
                request.ContentType = contentType;
                //request.Headers.Add("Content-Type: " + contentType);
                //wc.Headers.Add("Content-Type: " + contentType);
            }

            try
            {
                byte[] buffer = null;
                if (isXml)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(postData);
                    buffer = System.Text.Encoding.ASCII.GetBytes(doc.InnerXml);
                }
                else
                {
                    buffer = System.Text.Encoding.ASCII.GetBytes(postData);
                }

                Stream postStream = request.GetRequestStream();
                postStream.Write(buffer, 0, buffer.Length);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                StreamReader resp = new StreamReader(response.GetResponseStream());

                return resp.ReadToEnd();
                //return wc.UploadString(endpointURL, httpVerb, postData);
            }
            catch (WebException webEx)
            {
                String error = String.Empty;

                if (webEx.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)webEx.Response)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            error = reader.ReadToEnd();
                        }
                    }
                }

                throw new Exception(error);
            }
            catch (Exception genEx)
            {
                throw new Exception("API Call Failed", genEx);
            }
        }

        private WebClient buildWebClient()
        {
            WebClient wc = new WebClient();
            wc.Encoding = System.Text.Encoding.UTF8;
            //wc.Headers.Add("X-SFDC-Session: " + sessionId);

            return wc;
        }
    }
}
