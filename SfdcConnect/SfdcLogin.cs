/****************************************************************************
*
*   File name: SfdcLogin.cs
*   Author: Sean Fife
*   Create date: 4/20/2016
*   Solution: SfdcConnect
*   Project: SfdcConnect
*   Description: Includes the base class for Salesforce API Connections
*
****************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Services.Protocols;
using SfdcConnect.SoapObjects;
using System.Security.Cryptography;

namespace SfdcConnect
{
    /// <summary>
    /// Base connection class for all of the Salesforce API classes
    /// 
    /// Has login and logout functionality to obtain a session id for use in
    ///   the derived classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "SoapBinding", Namespace = "urn:partner.soap.sforce.com")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ApiFault))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NameObjectValuePair))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SearchLayoutFieldsDisplayed))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SearchLayoutButtonsDisplayed))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(location))]
    public class SfdcConnection : SoapHttpClientProtocol
    {
        public SfdcConnection()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls11;

            state = ConnectionState.Closed;

        }
        public SfdcConnection(string uri)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls11;
            state = ConnectionState.Closed;

            Url = uri;

            if ((this.IsLocalFileSystemWebService(this.Url) == true))
            {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else
            {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        public SfdcConnection(bool isTest, int apiversion)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls11;
            state = ConnectionState.Closed;

            if (isTest)
            {
                Url = string.Format("https://test.salesforce.com/services/Soap/u/{0}.0", apiversion);
            }
            else
            {
                Url = string.Format("https://login.salesforce.com/services/Soap/u/{0}.0", apiversion);
            }

            if ((this.IsLocalFileSystemWebService(this.Url) == true))
            {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else
            {
                this.useDefaultCredentialsSetExplicitly = true;
            }

            Version = apiversion.ToString();
        }

        /// <summary>
        /// Salesforce SessionId, only valid after Opening a connection
        /// </summary>
        public string SessionId { get; protected set; }
        /// <summary>
        /// Salesforce API Endpoint Uri, only valid after opening a connection.
        /// There is also Url which should contain the same value.
        /// </summary>
        protected string ServerUrl;
        /// <summary>
        /// State of the connection.  e.g. closed, open, connecting, etc.
        /// </summary>
        protected ConnectionState state;
        /// <summary>
        /// Date and time of the last Open or OpenAsync call
        /// </summary>
        protected DateTime LoginTime;

        /// <summary>
        /// Username for the connection
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Plain text password for the connection
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Salseforce security token, if necessary
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// API Version, set after opening a connection
        /// </summary>
        public string Version { get; protected set; }

        /// <summary>
        /// The connections current state
        /// </summary>
        public ConnectionState State
        {
            get { return state; }
        }

        /// <summary>
        /// Uri used for the REST API
        /// </summary>
        public Uri ApiEndPoint { get; protected set; }
        /// <summary>
        /// Uri used for the Metadata API
        /// </summary>
        public Uri MetadataEndPoint { get; protected set; }

        /// <summary>
        /// Open a connection to Salesforce.  Requires Usernamd and Password to be filled in.
        /// </summary>
        public virtual void Open()
        {
            if (state == ConnectionState.Open) return;
            state = ConnectionState.Connecting;

            if (!string.IsNullOrEmpty(ServerUrl))
            {
                Url = ServerUrl;
            }

            LoginResult loginResult = login(Username, Password + Token);

            LoginTime = DateTime.Now;
            Url = loginResult.serverUrl;
            SessionHeaderValue = new SessionHeader();
            SessionHeaderValue.sessionId = loginResult.sessionId;

            CallOptionsValue = new CallOptions();

            SessionId = loginResult.sessionId;
            ServerUrl = loginResult.serverUrl;

            string[] pieces = ServerUrl.Split('/');

            Version = pieces[pieces.Length - 2];

            ApiEndPoint = new Uri(loginResult.serverUrl);
            MetadataEndPoint = new Uri(loginResult.metadataServerUrl);

            state = ConnectionState.Open;
        }
        /// <summary>
        /// Open a connection to Salesforce asynchronously.  Requires Usernamd and Password to be filled in.
        /// </summary>
        public virtual void OpenAsync()
        {
            if (state == ConnectionState.Open) return;
            state = ConnectionState.Connecting;

            loginCompleted += ls_loginCompleted;
            LoginAsync(Username, Password + Token);

            //return default(Task);
        }
        /// <summary>
        /// Open a connection to Salesforce asynchronously.  Requires Usernamd and Password to be filled in.
        /// </summary>
        public virtual void OpenAsync(customLoginCompletedEventHandler loginCompleted)
        {
            if (state == ConnectionState.Open) return;
            state = ConnectionState.Connecting;

            customLoginCompleted += loginCompleted;
            loginCompleted += ls_loginCompleted;
            LoginAsync(Username, Password + Token);

            //return default(Task);
        }

        /// <summary>
        /// Open a connection to Salesforce asynchronously.  Requires Usernamd and Password to be filled in.
        /// </summary>
        public virtual async Task OpenAsync(CancellationToken cancellationToken)
        {
            if (state == ConnectionState.Open) return;
            state = ConnectionState.Connecting;

            loginCompleted += ls_loginCompleted;
            await LoginAsync(Username, Password + Token, cancellationToken);
        }

        /// <summary>
        /// Callback for OpenAsync calls
        /// </summary>
        /// <param name="sender">should be this object</param>
        /// <param name="e">Event Args holding the login information from Salesforce</param>
        private void ls_loginCompleted(object sender, loginCompletedEventArgs e)
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

            state = ConnectionState.Open;

            if (customLoginCompleted != null) customLoginCompleted(sender, e);
        }

        /// <summary>
        /// Close the Salesforce connection
        /// </summary>
        public void Close()
        {
            Url = ServerUrl;

            logout();

            state = ConnectionState.Closed;
        }

        /// <summary>
        /// Returns the Limit Info returned with the SOAP login call
        /// </summary>
        public LimitInfo[] LimitInfoFromLogin
        {
            get
            {
                if (LimitInfoHeaderValue == null) return null;
                return LimitInfoHeaderValue.limitInfo;
            }
        }

        /// <summary>
        /// Sets the password from a base 64 encoded, windows encrypted password
        /// </summary>
        /// <param name="base64Encryptedpassword">encrypted, base 64 password</param>
        /// <param name="scope">Data Protection Scope, either Current User or Local Machine</param>
        public void FromEncryptedPassword(string base64Encryptedpassword, DataProtectionScope scope = DataProtectionScope.LocalMachine)
        {
            byte[] pwd = Convert.FromBase64String(base64Encryptedpassword);
            byte[] bytesPwd = ProtectedData.Unprotect(pwd, null, scope);
            Password = System.Text.Encoding.Unicode.GetString(bytesPwd);
        }

        #region SFDC - Originally from auto generated wsdl

        public new string Url
        {
            get
            {
                return base.Url;
            }
            set
            {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true)
                            && (this.useDefaultCredentialsSetExplicitly == false))
                            && (this.IsLocalFileSystemWebService(value) == false)))
                {
                    UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }

        protected bool useDefaultCredentialsSetExplicitly;
        public new bool UseDefaultCredentials
        {
            get
            {
                return base.UseDefaultCredentials;
            }
            set
            {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }

        public LoginScopeHeader LoginScopeHeaderValue { get; set; }
        public CallOptions CallOptionsValue { get; set; }
        public SessionHeader SessionHeaderValue { get; set; }
        public LimitInfoHeader LimitInfoHeaderValue { get; set; }

        public delegate void customLoginCompletedEventHandler(object sender, loginCompletedEventArgs e);
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
        public delegate void loginCompletedEventHandler(object sender, loginCompletedEventArgs e);
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
        public delegate void logoutCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);

        private SendOrPostCallback loginOperationCompleted;
        private SendOrPostCallback logoutOperationCompleted;

        public event loginCompletedEventHandler loginCompleted;
        public event customLoginCompletedEventHandler customLoginCompleted;
        public event logoutCompletedEventHandler logoutCompleted;

        protected bool IsLocalFileSystemWebService(string url)
        {
            if (((url == null)
                        || (url == string.Empty)))
            {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024)
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0)))
            {
                return true;
            }
            return false;
        }

        [SoapHeaderAttribute("LoginScopeHeaderValue")]
        [SoapHeaderAttribute("CallOptionsValue")]
        [SoapDocumentMethodAttribute("", RequestNamespace = "urn:partner.soap.sforce.com", ResponseNamespace = "urn:partner.soap.sforce.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("result")]
        public LoginResult login(string username, string password)
        {
            object[] results = this.Invoke("login", new object[] { username, password });
            return ((LoginResult)(results[0]));
        }

        [SoapHeaderAttribute("SessionHeaderValue")]
        [SoapHeaderAttribute("CallOptionsValue")]
        [SoapHeaderAttribute("LimitInfoHeaderValue", Direction = SoapHeaderDirection.Out)]
        [SoapDocumentMethodAttribute("", RequestNamespace = "urn:partner.soap.sforce.com", ResponseNamespace = "urn:partner.soap.sforce.com", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public void logout()
        {
            this.Invoke("logout", new object[0]);
        }

        /// <remarks/>
        public void LoginAsync(string username, string password)
        {
            this.LoginAsync(username, password, null);
        }
        /// <remarks/>
        public async Task LoginAsync(string username, string password, object userState)
        {
            if ((this.loginOperationCompleted == null))
            {
                this.loginOperationCompleted = new SendOrPostCallback(this.OnloginOperationCompleted);
            }
            await Task.Run(() =>
            {
                base.InvokeAsync("login", new object[] {
                        username,
                        password}, this.loginOperationCompleted, userState);
            });
        }
        private void OnloginOperationCompleted(object arg)
        {
            if ((this.loginCompleted != null))
            {
                InvokeCompletedEventArgs invokeArgs = ((InvokeCompletedEventArgs)(arg));
                this.loginCompleted(this, new loginCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        public void LogoutAsync()
        {
            this.LogoutAsync(null);
        }
        /// <remarks/>
        public void LogoutAsync(object userState)
        {
            if ((this.logoutOperationCompleted == null))
            {
                this.logoutOperationCompleted = new SendOrPostCallback(this.OnlogoutOperationCompleted);
            }
            base.InvokeAsync("logout", new object[0], this.logoutOperationCompleted, userState);
        }
        private void OnlogoutOperationCompleted(object arg)
        {
            if ((this.logoutCompleted != null))
            {
                InvokeCompletedEventArgs invokeArgs = ((InvokeCompletedEventArgs)(arg));
                this.logoutCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        #endregion
    }
}
