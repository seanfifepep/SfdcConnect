﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    #region Generated From WSDL
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://soap.sforce.com/2006/08/apex")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://soap.sforce.com/2006/08/apex", IsNullable = false)]
    public partial class SessionHeader : System.Web.Services.Protocols.SoapHeader
    {

        private string sessionIdField;

        /// <remarks/>
        public string sessionId
        {
            get
            {
                return this.sessionIdField;
            }
            set
            {
                this.sessionIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://soap.sforce.com/2006/08/apex")]
    public partial class WsdlToApexResult
    {

        private string[] apexScriptsField;

        private string[] errorsField;

        private bool successField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("apexScripts")]
        public string[] apexScripts
        {
            get
            {
                return this.apexScriptsField;
            }
            set
            {
                this.apexScriptsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("errors")]
        public string[] errors
        {
            get
            {
                return this.errorsField;
            }
            set
            {
                this.errorsField = value;
            }
        }

        /// <remarks/>
        public bool success
        {
            get
            {
                return this.successField;
            }
            set
            {
                this.successField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://soap.sforce.com/2006/08/apex")]
    public partial class NamespacePackagePair
    {

        private string namespaceField;

        private string packageNameField;

        /// <remarks/>
        public string @namespace
        {
            get
            {
                return this.namespaceField;
            }
            set
            {
                this.namespaceField = value;
            }
        }

        /// <remarks/>
        public string packageName
        {
            get
            {
                return this.packageNameField;
            }
            set
            {
                this.packageNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://soap.sforce.com/2006/08/apex")]
    public partial class WsdlToApexInfo
    {

        private NamespacePackagePair[] mappingField;

        private string wsdlField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("mapping")]
        public NamespacePackagePair[] mapping
        {
            get
            {
                return this.mappingField;
            }
            set
            {
                this.mappingField = value;
            }
        }

        /// <remarks/>
        public string wsdl
        {
            get
            {
                return this.wsdlField;
            }
            set
            {
                this.wsdlField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://soap.sforce.com/2006/08/apex")]
    public partial class ExecuteAnonymousResult
    {

        private int columnField;

        private string compileProblemField;

        private bool compiledField;

        private string exceptionMessageField;

        private string exceptionStackTraceField;

        private int lineField;

        private bool successField;

        /// <remarks/>
        public int column
        {
            get
            {
                return this.columnField;
            }
            set
            {
                this.columnField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string compileProblem
        {
            get
            {
                return this.compileProblemField;
            }
            set
            {
                this.compileProblemField = value;
            }
        }

        /// <remarks/>
        public bool compiled
        {
            get
            {
                return this.compiledField;
            }
            set
            {
                this.compiledField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string exceptionMessage
        {
            get
            {
                return this.exceptionMessageField;
            }
            set
            {
                this.exceptionMessageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string exceptionStackTrace
        {
            get
            {
                return this.exceptionStackTraceField;
            }
            set
            {
                this.exceptionStackTraceField = value;
            }
        }

        /// <remarks/>
        public int line
        {
            get
            {
                return this.lineField;
            }
            set
            {
                this.lineField = value;
            }
        }

        /// <remarks/>
        public bool success
        {
            get
            {
                return this.successField;
            }
            set
            {
                this.successField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://soap.sforce.com/2006/08/apex")]
    public partial class CompileTriggerResult
    {

        private int bodyCrcField;

        private bool bodyCrcFieldSpecified;

        private int columnField;

        private string idField;

        private int lineField;

        private string nameField;

        private string problemField;

        private CompileIssue[] problemsField;

        private bool successField;

        private CompileIssue[] warningsField;

        /// <remarks/>
        public int bodyCrc
        {
            get
            {
                return this.bodyCrcField;
            }
            set
            {
                this.bodyCrcField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool bodyCrcSpecified
        {
            get
            {
                return this.bodyCrcFieldSpecified;
            }
            set
            {
                this.bodyCrcFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int column
        {
            get
            {
                return this.columnField;
            }
            set
            {
                this.columnField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public int line
        {
            get
            {
                return this.lineField;
            }
            set
            {
                this.lineField = value;
            }
        }

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string problem
        {
            get
            {
                return this.problemField;
            }
            set
            {
                this.problemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("problems", IsNullable = true)]
        public CompileIssue[] problems
        {
            get
            {
                return this.problemsField;
            }
            set
            {
                this.problemsField = value;
            }
        }

        /// <remarks/>
        public bool success
        {
            get
            {
                return this.successField;
            }
            set
            {
                this.successField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("warnings", IsNullable = true)]
        public CompileIssue[] warnings
        {
            get
            {
                return this.warningsField;
            }
            set
            {
                this.warningsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://soap.sforce.com/2006/08/apex")]
    public partial class CompileIssue
    {

        private int columnField;

        private bool columnFieldSpecified;

        private int lineField;

        private bool lineFieldSpecified;

        private string messageField;

        /// <remarks/>
        public int column
        {
            get
            {
                return this.columnField;
            }
            set
            {
                this.columnField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool columnSpecified
        {
            get
            {
                return this.columnFieldSpecified;
            }
            set
            {
                this.columnFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int line
        {
            get
            {
                return this.lineField;
            }
            set
            {
                this.lineField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool lineSpecified
        {
            get
            {
                return this.lineFieldSpecified;
            }
            set
            {
                this.lineFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://soap.sforce.com/2006/08/apex")]
    public partial class RunTestSuccess
    {

        private string idField;

        private string methodNameField;

        private string nameField;

        private string namespaceField;

        private bool seeAllDataField;

        private bool seeAllDataFieldSpecified;

        private double timeField;

        /// <remarks/>
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string methodName
        {
            get
            {
                return this.methodNameField;
            }
            set
            {
                this.methodNameField = value;
            }
        }

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string @namespace
        {
            get
            {
                return this.namespaceField;
            }
            set
            {
                this.namespaceField = value;
            }
        }

        /// <remarks/>
        public bool seeAllData
        {
            get
            {
                return this.seeAllDataField;
            }
            set
            {
                this.seeAllDataField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool seeAllDataSpecified
        {
            get
            {
                return this.seeAllDataFieldSpecified;
            }
            set
            {
                this.seeAllDataFieldSpecified = value;
            }
        }

        /// <remarks/>
        public double time
        {
            get
            {
                return this.timeField;
            }
            set
            {
                this.timeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://soap.sforce.com/2006/08/apex")]
    public partial class RunTestFailure
    {

        private string idField;

        private string messageField;

        private string methodNameField;

        private string nameField;

        private string namespaceField;

        private bool seeAllDataField;

        private bool seeAllDataFieldSpecified;

        private string stackTraceField;

        private double timeField;

        private string typeField;

        /// <remarks/>
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string methodName
        {
            get
            {
                return this.methodNameField;
            }
            set
            {
                this.methodNameField = value;
            }
        }

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string @namespace
        {
            get
            {
                return this.namespaceField;
            }
            set
            {
                this.namespaceField = value;
            }
        }

        /// <remarks/>
        public bool seeAllData
        {
            get
            {
                return this.seeAllDataField;
            }
            set
            {
                this.seeAllDataField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool seeAllDataSpecified
        {
            get
            {
                return this.seeAllDataFieldSpecified;
            }
            set
            {
                this.seeAllDataFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string stackTrace
        {
            get
            {
                return this.stackTraceField;
            }
            set
            {
                this.stackTraceField = value;
            }
        }

        /// <remarks/>
        public double time
        {
            get
            {
                return this.timeField;
            }
            set
            {
                this.timeField = value;
            }
        }

        /// <remarks/>
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://soap.sforce.com/2006/08/apex")]
    public partial class CodeCoverageWarning
    {

        private string idField;

        private string messageField;

        private string nameField;

        private string namespaceField;

        /// <remarks/>
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string message
        {
            get
            {
                return this.messageField;
            }
            set
            {
                this.messageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string @namespace
        {
            get
            {
                return this.namespaceField;
            }
            set
            {
                this.namespaceField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://soap.sforce.com/2006/08/apex")]
    public partial class CodeLocation
    {

        private int columnField;

        private int lineField;

        private int numExecutionsField;

        private double timeField;

        /// <remarks/>
        public int column
        {
            get
            {
                return this.columnField;
            }
            set
            {
                this.columnField = value;
            }
        }

        /// <remarks/>
        public int line
        {
            get
            {
                return this.lineField;
            }
            set
            {
                this.lineField = value;
            }
        }

        /// <remarks/>
        public int numExecutions
        {
            get
            {
                return this.numExecutionsField;
            }
            set
            {
                this.numExecutionsField = value;
            }
        }

        /// <remarks/>
        public double time
        {
            get
            {
                return this.timeField;
            }
            set
            {
                this.timeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://soap.sforce.com/2006/08/apex")]
    public partial class CodeCoverageResult
    {

        private string idField;

        private CodeLocation[] locationsNotCoveredField;

        private string nameField;

        private string namespaceField;

        private int numLocationsField;

        private int numLocationsNotCoveredField;

        private string typeField;

        /// <remarks/>
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("locationsNotCovered")]
        public CodeLocation[] locationsNotCovered
        {
            get
            {
                return this.locationsNotCoveredField;
            }
            set
            {
                this.locationsNotCoveredField = value;
            }
        }

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string @namespace
        {
            get
            {
                return this.namespaceField;
            }
            set
            {
                this.namespaceField = value;
            }
        }

        /// <remarks/>
        public int numLocations
        {
            get
            {
                return this.numLocationsField;
            }
            set
            {
                this.numLocationsField = value;
            }
        }

        /// <remarks/>
        public int numLocationsNotCovered
        {
            get
            {
                return this.numLocationsNotCoveredField;
            }
            set
            {
                this.numLocationsNotCoveredField = value;
            }
        }

        /// <remarks/>
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://soap.sforce.com/2006/08/apex")]
    public partial class RunTestsResult
    {

        private string apexLogIdField;

        private CodeCoverageResult[] codeCoverageField;

        private CodeCoverageWarning[] codeCoverageWarningsField;

        private RunTestFailure[] failuresField;

        private int numFailuresField;

        private int numTestsRunField;

        private RunTestSuccess[] successesField;

        private double totalTimeField;

        /// <remarks/>
        public string apexLogId
        {
            get
            {
                return this.apexLogIdField;
            }
            set
            {
                this.apexLogIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("codeCoverage")]
        public CodeCoverageResult[] codeCoverage
        {
            get
            {
                return this.codeCoverageField;
            }
            set
            {
                this.codeCoverageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("codeCoverageWarnings")]
        public CodeCoverageWarning[] codeCoverageWarnings
        {
            get
            {
                return this.codeCoverageWarningsField;
            }
            set
            {
                this.codeCoverageWarningsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("failures")]
        public RunTestFailure[] failures
        {
            get
            {
                return this.failuresField;
            }
            set
            {
                this.failuresField = value;
            }
        }

        /// <remarks/>
        public int numFailures
        {
            get
            {
                return this.numFailuresField;
            }
            set
            {
                this.numFailuresField = value;
            }
        }

        /// <remarks/>
        public int numTestsRun
        {
            get
            {
                return this.numTestsRunField;
            }
            set
            {
                this.numTestsRunField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("successes")]
        public RunTestSuccess[] successes
        {
            get
            {
                return this.successesField;
            }
            set
            {
                this.successesField = value;
            }
        }

        /// <remarks/>
        public double totalTime
        {
            get
            {
                return this.totalTimeField;
            }
            set
            {
                this.totalTimeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://soap.sforce.com/2006/08/apex")]
    public partial class DeleteApexResult
    {

        private string idField;

        private string problemField;

        private bool successField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string problem
        {
            get
            {
                return this.problemField;
            }
            set
            {
                this.problemField = value;
            }
        }

        /// <remarks/>
        public bool success
        {
            get
            {
                return this.successField;
            }
            set
            {
                this.successField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://soap.sforce.com/2006/08/apex")]
    public partial class CompileClassResult
    {

        private int bodyCrcField;

        private bool bodyCrcFieldSpecified;

        private int columnField;

        private string idField;

        private int lineField;

        private string nameField;

        private string problemField;

        private CompileIssue[] problemsField;

        private bool successField;

        private CompileIssue[] warningsField;

        /// <remarks/>
        public int bodyCrc
        {
            get
            {
                return this.bodyCrcField;
            }
            set
            {
                this.bodyCrcField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool bodyCrcSpecified
        {
            get
            {
                return this.bodyCrcFieldSpecified;
            }
            set
            {
                this.bodyCrcFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int column
        {
            get
            {
                return this.columnField;
            }
            set
            {
                this.columnField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public int line
        {
            get
            {
                return this.lineField;
            }
            set
            {
                this.lineField = value;
            }
        }

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string problem
        {
            get
            {
                return this.problemField;
            }
            set
            {
                this.problemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("problems", IsNullable = true)]
        public CompileIssue[] problems
        {
            get
            {
                return this.problemsField;
            }
            set
            {
                this.problemsField = value;
            }
        }

        /// <remarks/>
        public bool success
        {
            get
            {
                return this.successField;
            }
            set
            {
                this.successField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("warnings", IsNullable = true)]
        public CompileIssue[] warnings
        {
            get
            {
                return this.warningsField;
            }
            set
            {
                this.warningsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://soap.sforce.com/2006/08/apex")]
    public partial class CompileAndTestResult
    {

        private CompileClassResult[] classesField;

        private DeleteApexResult[] deleteClassesField;

        private DeleteApexResult[] deleteTriggersField;

        private RunTestsResult runTestsResultField;

        private bool successField;

        private CompileTriggerResult[] triggersField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("classes")]
        public CompileClassResult[] classes
        {
            get
            {
                return this.classesField;
            }
            set
            {
                this.classesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("deleteClasses")]
        public DeleteApexResult[] deleteClasses
        {
            get
            {
                return this.deleteClassesField;
            }
            set
            {
                this.deleteClassesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("deleteTriggers")]
        public DeleteApexResult[] deleteTriggers
        {
            get
            {
                return this.deleteTriggersField;
            }
            set
            {
                this.deleteTriggersField = value;
            }
        }

        /// <remarks/>
        public RunTestsResult runTestsResult
        {
            get
            {
                return this.runTestsResultField;
            }
            set
            {
                this.runTestsResultField = value;
            }
        }

        /// <remarks/>
        public bool success
        {
            get
            {
                return this.successField;
            }
            set
            {
                this.successField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("triggers")]
        public CompileTriggerResult[] triggers
        {
            get
            {
                return this.triggersField;
            }
            set
            {
                this.triggersField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://soap.sforce.com/2006/08/apex")]
    public partial class RunTestsRequest
    {

        private bool allTestsField;

        private string[] classesField;

        private int maxFailedTestsField;

        private bool maxFailedTestsFieldSpecified;

        private string namespaceField;

        private string[] packagesField;

        /// <remarks/>
        public bool allTests
        {
            get
            {
                return this.allTestsField;
            }
            set
            {
                this.allTestsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("classes")]
        public string[] classes
        {
            get
            {
                return this.classesField;
            }
            set
            {
                this.classesField = value;
            }
        }

        /// <remarks/>
        public int maxFailedTests
        {
            get
            {
                return this.maxFailedTestsField;
            }
            set
            {
                this.maxFailedTestsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool maxFailedTestsSpecified
        {
            get
            {
                return this.maxFailedTestsFieldSpecified;
            }
            set
            {
                this.maxFailedTestsFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string @namespace
        {
            get
            {
                return this.namespaceField;
            }
            set
            {
                this.namespaceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("packages")]
        public string[] packages
        {
            get
            {
                return this.packagesField;
            }
            set
            {
                this.packagesField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://soap.sforce.com/2006/08/apex")]
    public partial class CompileAndTestRequest
    {

        private bool checkOnlyField;

        private string[] classesField;

        private string[] deleteClassesField;

        private string[] deleteTriggersField;

        private RunTestsRequest runTestsRequestField;

        private string[] triggersField;

        /// <remarks/>
        public bool checkOnly
        {
            get
            {
                return this.checkOnlyField;
            }
            set
            {
                this.checkOnlyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("classes")]
        public string[] classes
        {
            get
            {
                return this.classesField;
            }
            set
            {
                this.classesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("deleteClasses")]
        public string[] deleteClasses
        {
            get
            {
                return this.deleteClassesField;
            }
            set
            {
                this.deleteClassesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("deleteTriggers")]
        public string[] deleteTriggers
        {
            get
            {
                return this.deleteTriggersField;
            }
            set
            {
                this.deleteTriggersField = value;
            }
        }

        /// <remarks/>
        public RunTestsRequest runTestsRequest
        {
            get
            {
                return this.runTestsRequestField;
            }
            set
            {
                this.runTestsRequestField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("triggers")]
        public string[] triggers
        {
            get
            {
                return this.triggersField;
            }
            set
            {
                this.triggersField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://soap.sforce.com/2006/08/apex")]
    public partial class PackageVersion
    {

        private int majorNumberField;

        private int minorNumberField;

        private string namespaceField;

        /// <remarks/>
        public int majorNumber
        {
            get
            {
                return this.majorNumberField;
            }
            set
            {
                this.majorNumberField = value;
            }
        }

        /// <remarks/>
        public int minorNumber
        {
            get
            {
                return this.minorNumberField;
            }
            set
            {
                this.minorNumberField = value;
            }
        }

        /// <remarks/>
        public string @namespace
        {
            get
            {
                return this.namespaceField;
            }
            set
            {
                this.namespaceField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://soap.sforce.com/2006/08/apex")]
    public partial class LogInfo
    {

        private LogCategory categoryField;

        private LogCategoryLevel levelField;

        /// <remarks/>
        public LogCategory category
        {
            get
            {
                return this.categoryField;
            }
            set
            {
                this.categoryField = value;
            }
        }

        /// <remarks/>
        public LogCategoryLevel level
        {
            get
            {
                return this.levelField;
            }
            set
            {
                this.levelField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://soap.sforce.com/2006/08/apex")]
    public enum LogCategory
    {

        /// <remarks/>
        Db,

        /// <remarks/>
        Workflow,

        /// <remarks/>
        Validation,

        /// <remarks/>
        Callout,

        /// <remarks/>
        Apex_code,

        /// <remarks/>
        Apex_profiling,

        /// <remarks/>
        Visualforce,

        /// <remarks/>
        System,

        /// <remarks/>
        Wave,

        /// <remarks/>
        All,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://soap.sforce.com/2006/08/apex")]
    public enum LogCategoryLevel
    {

        /// <remarks/>
        None,

        /// <remarks/>
        Finest,

        /// <remarks/>
        Finer,

        /// <remarks/>
        Fine,

        /// <remarks/>
        Debug,

        /// <remarks/>
        Info,

        /// <remarks/>
        Warn,

        /// <remarks/>
        Error,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://soap.sforce.com/2006/08/apex")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://soap.sforce.com/2006/08/apex", IsNullable = false)]
    public partial class DebuggingHeader : System.Web.Services.Protocols.SoapHeader
    {

        private LogInfo[] categoriesField;

        private LogType debugLevelField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("categories")]
        public LogInfo[] categories
        {
            get
            {
                return this.categoriesField;
            }
            set
            {
                this.categoriesField = value;
            }
        }

        /// <remarks/>
        public LogType debugLevel
        {
            get
            {
                return this.debugLevelField;
            }
            set
            {
                this.debugLevelField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://soap.sforce.com/2006/08/apex")]
    public enum LogType
    {

        /// <remarks/>
        None,

        /// <remarks/>
        Debugonly,

        /// <remarks/>
        Db,

        /// <remarks/>
        Profiling,

        /// <remarks/>
        Callout,

        /// <remarks/>
        Detail,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://soap.sforce.com/2006/08/apex")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://soap.sforce.com/2006/08/apex", IsNullable = false)]
    public partial class AllowFieldTruncationHeader : System.Web.Services.Protocols.SoapHeader
    {

        private bool allowFieldTruncationField;

        /// <remarks/>
        public bool allowFieldTruncation
        {
            get
            {
                return this.allowFieldTruncationField;
            }
            set
            {
                this.allowFieldTruncationField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://soap.sforce.com/2006/08/apex")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://soap.sforce.com/2006/08/apex", IsNullable = false)]
    public partial class CallOptions : System.Web.Services.Protocols.SoapHeader
    {

        private string clientField;

        /// <remarks/>
        public string client
        {
            get
            {
                return this.clientField;
            }
            set
            {
                this.clientField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://soap.sforce.com/2006/08/apex")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://soap.sforce.com/2006/08/apex", IsNullable = false)]
    public partial class DisableFeedTrackingHeader : System.Web.Services.Protocols.SoapHeader
    {

        private bool disableFeedTrackingField;

        /// <remarks/>
        public bool disableFeedTracking
        {
            get
            {
                return this.disableFeedTrackingField;
            }
            set
            {
                this.disableFeedTrackingField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://soap.sforce.com/2006/08/apex")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://soap.sforce.com/2006/08/apex", IsNullable = false)]
    public partial class DebuggingInfo : System.Web.Services.Protocols.SoapHeader
    {

        private string debugLogField;

        /// <remarks/>
        public string debugLog
        {
            get
            {
                return this.debugLogField;
            }
            set
            {
                this.debugLogField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://soap.sforce.com/2006/08/apex")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://soap.sforce.com/2006/08/apex", IsNullable = false)]
    public partial class PackageVersionHeader : System.Web.Services.Protocols.SoapHeader
    {

        private PackageVersion[] packageVersionsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("packageVersions")]
        public PackageVersion[] packageVersions
        {
            get
            {
                return this.packageVersionsField;
            }
            set
            {
                this.packageVersionsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void compileAndTestCompletedEventHandler(object sender, compileAndTestCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class compileAndTestCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal compileAndTestCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public CompileAndTestResult Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((CompileAndTestResult)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void compileClassesCompletedEventHandler(object sender, compileClassesCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class compileClassesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal compileClassesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public CompileClassResult[] Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((CompileClassResult[])(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void compileTriggersCompletedEventHandler(object sender, compileTriggersCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class compileTriggersCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal compileTriggersCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public CompileTriggerResult[] Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((CompileTriggerResult[])(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void executeAnonymousCompletedEventHandler(object sender, executeAnonymousCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class executeAnonymousCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal executeAnonymousCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public ExecuteAnonymousResult Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((ExecuteAnonymousResult)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void runTestsCompletedEventHandler(object sender, runTestsCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class runTestsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal runTestsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public RunTestsResult Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((RunTestsResult)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void wsdlToApexCompletedEventHandler(object sender, wsdlToApexCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class wsdlToApexCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal wsdlToApexCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public WsdlToApexResult Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((WsdlToApexResult)(this.results[0]));
            }
        }
    }


    #endregion
}
