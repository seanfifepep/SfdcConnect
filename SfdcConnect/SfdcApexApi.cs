using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SfdcConnect.ApexObjects;

namespace SfdcConnect
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "ApexBinding", Namespace = "http://soap.sforce.com/2006/08/apex")]
    public class SfdcApexApi : SfdcConnection
    {
        /// <remarks/>
        public SfdcApexApi()
        {
        }
        public SfdcApexApi(string uri)
            : base(uri)
        {
        }
        public SfdcApexApi(bool isTest, int apiversion)
            : base(isTest, apiversion)
        {

        }

        public override void Open()
        {
            base.Open();

            if (base.CallOptionsValue != null)
            {
                CallOptions = new CallOptions();
                CallOptions.Actor = base.CallOptionsValue.Actor;
                CallOptions.client = base.CallOptionsValue.client;
                CallOptions.DidUnderstand = base.CallOptionsValue.DidUnderstand;
                CallOptions.EncodedMustUnderstand = base.CallOptionsValue.EncodedMustUnderstand;
                CallOptions.EncodedMustUnderstand12 = base.CallOptionsValue.EncodedMustUnderstand12;
                CallOptions.EncodedRelay = base.CallOptionsValue.EncodedRelay;
                CallOptions.MustUnderstand = base.CallOptionsValue.MustUnderstand;
                CallOptions.Relay = base.CallOptionsValue.Relay;
                CallOptions.Role = base.CallOptionsValue.Role;
            }

            if (base.SessionHeaderValue != null)
            {
                SessionHeader = new SessionHeader();
                SessionHeader.Actor = base.SessionHeaderValue.Actor;
                SessionHeader.sessionId = base.SessionHeaderValue.sessionId;
                SessionHeader.DidUnderstand = base.SessionHeaderValue.DidUnderstand;
                SessionHeader.EncodedMustUnderstand = base.SessionHeaderValue.EncodedMustUnderstand;
                SessionHeader.EncodedMustUnderstand12 = base.SessionHeaderValue.EncodedMustUnderstand12;
                SessionHeader.EncodedRelay = base.SessionHeaderValue.EncodedRelay;
                SessionHeader.MustUnderstand = base.SessionHeaderValue.MustUnderstand;
                SessionHeader.Relay = base.SessionHeaderValue.Relay;
                SessionHeader.Role = base.SessionHeaderValue.Role;
            }

            Uri url = new Uri(ServerUrl);
            this.Url = "https://" + url.Host + "/services/Soap/s/" + Version;

        }

        #region Sfdc - From wsdl
        private SessionHeader sessionHeaderValueField;
        private CallOptions callOptionsValueField;

        private DebuggingHeader debuggingHeaderValueField;
        private PackageVersionHeader packageVersionHeaderValueField;
        private DebuggingInfo debuggingInfoValueField;
        private AllowFieldTruncationHeader allowFieldTruncationHeaderValueField;
        private DisableFeedTrackingHeader disableFeedTrackingHeaderValueField;

        private System.Threading.SendOrPostCallback compileAndTestOperationCompleted;
        private System.Threading.SendOrPostCallback compileClassesOperationCompleted;
        private System.Threading.SendOrPostCallback compileTriggersOperationCompleted;
        private System.Threading.SendOrPostCallback executeAnonymousOperationCompleted;
        private System.Threading.SendOrPostCallback runTestsOperationCompleted;
        private System.Threading.SendOrPostCallback wsdlToApexOperationCompleted;

        public SessionHeader SessionHeader
        {
            get
            {
                return this.sessionHeaderValueField;
            }
            set
            {
                this.sessionHeaderValueField = value;
            }
        }
        public DebuggingHeader DebuggingHeaderValue
        {
            get
            {
                return this.debuggingHeaderValueField;
            }
            set
            {
                this.debuggingHeaderValueField = value;
            }
        }
        public PackageVersionHeader PackageVersionHeaderValue
        {
            get
            {
                return this.packageVersionHeaderValueField;
            }
            set
            {
                this.packageVersionHeaderValueField = value;
            }
        }
        public CallOptions CallOptions
        {
            get
            {
                return this.callOptionsValueField;
            }
            set
            {
                this.callOptionsValueField = value;
            }
        }
        public DebuggingInfo DebuggingInfoValue
        {
            get
            {
                return this.debuggingInfoValueField;
            }
            set
            {
                this.debuggingInfoValueField = value;
            }
        }
        public AllowFieldTruncationHeader AllowFieldTruncationHeaderValue
        {
            get
            {
                return this.allowFieldTruncationHeaderValueField;
            }
            set
            {
                this.allowFieldTruncationHeaderValueField = value;
            }
        }
        public DisableFeedTrackingHeader DisableFeedTrackingHeaderValue
        {
            get
            {
                return this.disableFeedTrackingHeaderValueField;
            }
            set
            {
                this.disableFeedTrackingHeaderValueField = value;
            }
        }

        /// <remarks/>
        public event compileAndTestCompletedEventHandler compileAndTestCompleted;
        /// <remarks/>
        public event compileClassesCompletedEventHandler compileClassesCompleted;
        /// <remarks/>
        public event compileTriggersCompletedEventHandler compileTriggersCompleted;
        /// <remarks/>
        public event executeAnonymousCompletedEventHandler executeAnonymousCompleted;
        /// <remarks/>
        public event runTestsCompletedEventHandler runTestsCompleted;
        /// <remarks/>
        public event wsdlToApexCompletedEventHandler wsdlToApexCompleted;
        #endregion

        #region Synchronous Calls
        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("CallOptionsValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("DebuggingInfoValue", Direction = System.Web.Services.Protocols.SoapHeaderDirection.Out)]
        [System.Web.Services.Protocols.SoapHeaderAttribute("DebuggingHeaderValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("SessionHeaderValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("PackageVersionHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace = "http://soap.sforce.com/2006/08/apex", ResponseNamespace = "http://soap.sforce.com/2006/08/apex", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("result")]
        public CompileAndTestResult compileAndTest(CompileAndTestRequest CompileAndTestRequest)
        {
            object[] results = this.Invoke("compileAndTest", new object[] {
                        CompileAndTestRequest});
            return ((CompileAndTestResult)(results[0]));
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("PackageVersionHeaderValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("SessionHeaderValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("CallOptionsValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace = "http://soap.sforce.com/2006/08/apex", ResponseNamespace = "http://soap.sforce.com/2006/08/apex", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("result")]
        public CompileClassResult[] compileClasses([System.Xml.Serialization.XmlElementAttribute("scripts")] string[] scripts)
        {
            object[] results = this.Invoke("compileClasses", new object[] {
                        scripts});
            return ((CompileClassResult[])(results[0]));
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("PackageVersionHeaderValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("SessionHeaderValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("CallOptionsValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace = "http://soap.sforce.com/2006/08/apex", ResponseNamespace = "http://soap.sforce.com/2006/08/apex", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("result")]
        public CompileTriggerResult[] compileTriggers([System.Xml.Serialization.XmlElementAttribute("scripts")] string[] scripts)
        {
            object[] results = this.Invoke("compileTriggers", new object[] {
                        scripts});
            return ((CompileTriggerResult[])(results[0]));
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SessionHeaderValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("DebuggingHeaderValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("AllowFieldTruncationHeaderValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("CallOptionsValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("DisableFeedTrackingHeaderValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("DebuggingInfoValue", Direction = System.Web.Services.Protocols.SoapHeaderDirection.Out)]
        [System.Web.Services.Protocols.SoapHeaderAttribute("PackageVersionHeaderValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace = "http://soap.sforce.com/2006/08/apex", ResponseNamespace = "http://soap.sforce.com/2006/08/apex", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("result")]
        public ExecuteAnonymousResult executeAnonymous(string String)
        {
            object[] results = this.Invoke("executeAnonymous", new object[] {
                        String});
            return ((ExecuteAnonymousResult)(results[0]));
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("DebuggingInfoValue", Direction = System.Web.Services.Protocols.SoapHeaderDirection.Out)]
        [System.Web.Services.Protocols.SoapHeaderAttribute("DebuggingHeaderValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("SessionHeaderValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("CallOptionsValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace = "http://soap.sforce.com/2006/08/apex", ResponseNamespace = "http://soap.sforce.com/2006/08/apex", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("result")]
        public RunTestsResult runTests(RunTestsRequest RunTestsRequest)
        {
            object[] results = this.Invoke("runTests", new object[] {
                        RunTestsRequest});
            return ((RunTestsResult)(results[0]));
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SessionHeaderValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("CallOptionsValue")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace = "http://soap.sforce.com/2006/08/apex", ResponseNamespace = "http://soap.sforce.com/2006/08/apex", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("result")]
        public WsdlToApexResult wsdlToApex(WsdlToApexInfo info)
        {
            object[] results = this.Invoke("wsdlToApex", new object[] {
                        info});
            return ((WsdlToApexResult)(results[0]));
        }
        #endregion

        #region Asynchronous Calls
        /// <remarks/>
        public void compileAndTestAsync(CompileAndTestRequest CompileAndTestRequest)
        {
            this.compileAndTestAsync(CompileAndTestRequest, null);
        }

        /// <remarks/>
        public void compileAndTestAsync(CompileAndTestRequest CompileAndTestRequest, object userState)
        {
            if ((this.compileAndTestOperationCompleted == null))
            {
                this.compileAndTestOperationCompleted = new System.Threading.SendOrPostCallback(this.OncompileAndTestOperationCompleted);
            }
            this.InvokeAsync("compileAndTest", new object[] {
                        CompileAndTestRequest}, this.compileAndTestOperationCompleted, userState);
        }

        /// <remarks/>
        public void compileClassesAsync(string[] scripts)
        {
            this.compileClassesAsync(scripts, null);
        }

        /// <remarks/>
        public void compileClassesAsync(string[] scripts, object userState)
        {
            if ((this.compileClassesOperationCompleted == null))
            {
                this.compileClassesOperationCompleted = new System.Threading.SendOrPostCallback(this.OncompileClassesOperationCompleted);
            }
            this.InvokeAsync("compileClasses", new object[] {
                        scripts}, this.compileClassesOperationCompleted, userState);
        }

        /// <remarks/>
        public void compileTriggersAsync(string[] scripts)
        {
            this.compileTriggersAsync(scripts, null);
        }

        /// <remarks/>
        public void compileTriggersAsync(string[] scripts, object userState)
        {
            if ((this.compileTriggersOperationCompleted == null))
            {
                this.compileTriggersOperationCompleted = new System.Threading.SendOrPostCallback(this.OncompileTriggersOperationCompleted);
            }
            this.InvokeAsync("compileTriggers", new object[] {
                        scripts}, this.compileTriggersOperationCompleted, userState);
        }

        /// <remarks/>
        public void executeAnonymousAsync(string String)
        {
            this.executeAnonymousAsync(String, null);
        }

        /// <remarks/>
        public void executeAnonymousAsync(string String, object userState)
        {
            if ((this.executeAnonymousOperationCompleted == null))
            {
                this.executeAnonymousOperationCompleted = new System.Threading.SendOrPostCallback(this.OnexecuteAnonymousOperationCompleted);
            }
            this.InvokeAsync("executeAnonymous", new object[] {
                        String}, this.executeAnonymousOperationCompleted, userState);
        }

        /// <remarks/>
        public void runTestsAsync(RunTestsRequest RunTestsRequest)
        {
            this.runTestsAsync(RunTestsRequest, null);
        }

        /// <remarks/>
        public void runTestsAsync(RunTestsRequest RunTestsRequest, object userState)
        {
            if ((this.runTestsOperationCompleted == null))
            {
                this.runTestsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnrunTestsOperationCompleted);
            }
            this.InvokeAsync("runTests", new object[] {
                        RunTestsRequest}, this.runTestsOperationCompleted, userState);
        }

        /// <remarks/>
        public void wsdlToApexAsync(WsdlToApexInfo info)
        {
            this.wsdlToApexAsync(info, null);
        }

        /// <remarks/>
        public void wsdlToApexAsync(WsdlToApexInfo info, object userState)
        {
            if ((this.wsdlToApexOperationCompleted == null))
            {
                this.wsdlToApexOperationCompleted = new System.Threading.SendOrPostCallback(this.OnwsdlToApexOperationCompleted);
            }
            this.InvokeAsync("wsdlToApex", new object[] {
                        info}, this.wsdlToApexOperationCompleted, userState);
        }

        /// <remarks/>
        public new void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }
        #endregion

        #region Callbacks
        private void OncompileAndTestOperationCompleted(object arg)
        {
            if ((this.compileAndTestCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.compileAndTestCompleted(this, new compileAndTestCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        private void OncompileClassesOperationCompleted(object arg)
        {
            if ((this.compileClassesCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.compileClassesCompleted(this, new compileClassesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        private void OncompileTriggersOperationCompleted(object arg)
        {
            if ((this.compileTriggersCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.compileTriggersCompleted(this, new compileTriggersCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        private void OnexecuteAnonymousOperationCompleted(object arg)
        {
            if ((this.executeAnonymousCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.executeAnonymousCompleted(this, new executeAnonymousCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        private void OnrunTestsOperationCompleted(object arg)
        {
            if ((this.runTestsCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.runTestsCompleted(this, new runTestsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        private void OnwsdlToApexOperationCompleted(object arg)
        {
            if ((this.wsdlToApexCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.wsdlToApexCompleted(this, new wsdlToApexCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        #endregion
    }

}
