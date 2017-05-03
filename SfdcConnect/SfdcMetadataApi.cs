using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SfdcConnect.MetadataObjects;

namespace SfdcConnect
{
    [System.Web.Services.WebServiceBindingAttribute(Name = "MetadataBinding", Namespace = "http://soap.sforce.com/2006/04/metadata")]
    public class SfdcMetadataApi : SfdcConnection
    {
        public SfdcMetadataApi()
            : base()
        {
        }

        public SfdcMetadataApi(string uri)
            : base(uri)
        {
        }

        public SfdcMetadataApi(bool isTest, int apiversion)
            : base(isTest, apiversion)
        {
        }

        public override void Open()
        {
            base.Open();

            if (base.CallOptionsValue != null)
            {
                CallOptions = new SfdcConnect.MetadataObjects.CallOptions();
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
                SessionHeader = new SfdcConnect.MetadataObjects.SessionHeader();
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

            this.Url = MetadataEndPoint.AbsoluteUri;
        }

        #region Sfdc - From wsdl

        public SfdcConnect.MetadataObjects.CallOptions CallOptions { get; set; }
        public SfdcConnect.MetadataObjects.SessionHeader SessionHeader { get; set; }

        private System.Threading.SendOrPostCallback cancelDeployOperationCompleted;
        private System.Threading.SendOrPostCallback checkDeployStatusOperationCompleted;
        private System.Threading.SendOrPostCallback checkRetrieveStatusOperationCompleted;
        private System.Threading.SendOrPostCallback createMetadataOperationCompleted;
        private System.Threading.SendOrPostCallback deleteMetadataOperationCompleted;
        private System.Threading.SendOrPostCallback deployOperationCompleted;
        private System.Threading.SendOrPostCallback describeMetadataOperationCompleted;
        private System.Threading.SendOrPostCallback listMetadataOperationCompleted;
        private System.Threading.SendOrPostCallback readMetadataOperationCompleted;
        private System.Threading.SendOrPostCallback renameMetadataOperationCompleted;
        private System.Threading.SendOrPostCallback retrieveOperationCompleted;
        private System.Threading.SendOrPostCallback updateMetadataOperationCompleted;
        private System.Threading.SendOrPostCallback upsertMetadataOperationCompleted;

        public DebuggingInfo DebuggingInfoValue { get; set; }
        public DebuggingHeader DebuggingHeaderValue { get; set; }
        
        /// <remarks/>
        public event cancelDeployCompletedEventHandler cancelDeployCompleted;
        /// <remarks/>
        public event checkDeployStatusCompletedEventHandler checkDeployStatusCompleted;
        /// <remarks/>
        public event checkRetrieveStatusCompletedEventHandler checkRetrieveStatusCompleted;
        /// <remarks/>
        public event createMetadataCompletedEventHandler createMetadataCompleted;
        /// <remarks/>
        public event deleteMetadataCompletedEventHandler deleteMetadataCompleted;
        /// <remarks/>
        public event deployCompletedEventHandler deployCompleted;
        /// <remarks/>
        public event describeMetadataCompletedEventHandler describeMetadataCompleted;
        /// <remarks/>
        public event listMetadataCompletedEventHandler listMetadataCompleted;
        /// <remarks/>
        public event readMetadataCompletedEventHandler readMetadataCompleted;
        /// <remarks/>
        public event renameMetadataCompletedEventHandler renameMetadataCompleted;
        /// <remarks/>
        public event retrieveCompletedEventHandler retrieveCompleted;
        /// <remarks/>
        public event updateMetadataCompletedEventHandler updateMetadataCompleted;
        /// <remarks/>
        public event upsertMetadataCompletedEventHandler upsertMetadataCompleted;
        
        #endregion

        #region Synchronous Calls

        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SessionHeader")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("CallOptions")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace = "http://soap.sforce.com/2006/04/metadata", ResponseNamespace = "http://soap.sforce.com/2006/04/metadata", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("result")]
        public CancelDeployResult cancelDeploy(string String)
        {
            object[] results = this.Invoke("cancelDeploy", new object[] {
                        String});
            return ((CancelDeployResult)(results[0]));
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SessionHeader")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("DebuggingInfoValue", Direction = System.Web.Services.Protocols.SoapHeaderDirection.Out)]
        [System.Web.Services.Protocols.SoapHeaderAttribute("CallOptions")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace = "http://soap.sforce.com/2006/04/metadata", ResponseNamespace = "http://soap.sforce.com/2006/04/metadata", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("result")]
        public DeployResult checkDeployStatus(string asyncProcessId, bool includeDetails)
        {
            object[] results = this.Invoke("checkDeployStatus", new object[] {
                        asyncProcessId,
                        includeDetails});
            return ((DeployResult)(results[0]));
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SessionHeader")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("CallOptions")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace = "http://soap.sforce.com/2006/04/metadata", ResponseNamespace = "http://soap.sforce.com/2006/04/metadata", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("result")]
        public RetrieveResult checkRetrieveStatus(string asyncProcessId, bool includeZip = false)
        {
            object[] results = this.Invoke("checkRetrieveStatus", new object[] {
                        asyncProcessId,
                        includeZip});
            return ((RetrieveResult)(results[0]));
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SessionHeader")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("CallOptions")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace = "http://soap.sforce.com/2006/04/metadata", ResponseNamespace = "http://soap.sforce.com/2006/04/metadata", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("result")]
        public SaveResult[] createMetadata([System.Xml.Serialization.XmlElementAttribute("metadata")] Metadata[] metadata)
        {
            object[] results = this.Invoke("createMetadata", new object[] {
                        metadata});
            return ((SaveResult[])(results[0]));
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SessionHeader")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("CallOptions")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace = "http://soap.sforce.com/2006/04/metadata", ResponseNamespace = "http://soap.sforce.com/2006/04/metadata", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("result")]
        public DeleteResult[] deleteMetadata(string type, [System.Xml.Serialization.XmlElementAttribute("fullNames")] string[] fullNames)
        {
            object[] results = this.Invoke("deleteMetadata", new object[] {
                        type,
                        fullNames});
            return ((DeleteResult[])(results[0]));
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("DebuggingHeaderValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("SessionHeader")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("CallOptions")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace = "http://soap.sforce.com/2006/04/metadata", ResponseNamespace = "http://soap.sforce.com/2006/04/metadata", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("result")]
        public AsyncResult deploy([System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")] byte[] ZipFile, DeployOptions DeployOptions)
        {
            object[] results = this.Invoke("deploy", new object[] {
                        ZipFile,
                        DeployOptions});
            return ((AsyncResult)(results[0]));
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SessionHeader")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("CallOptions")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace = "http://soap.sforce.com/2006/04/metadata", ResponseNamespace = "http://soap.sforce.com/2006/04/metadata", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("result")]
        public DescribeMetadataResult describeMetadata(double asOfVersion)
        {
            object[] results = this.Invoke("describeMetadata", new object[] { asOfVersion });
            return ((DescribeMetadataResult)(results[0]));
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SessionHeader")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("CallOptions")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace = "http://soap.sforce.com/2006/04/metadata", ResponseNamespace = "http://soap.sforce.com/2006/04/metadata", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("result")]
        public FileProperties[] listMetadata([System.Xml.Serialization.XmlElementAttribute("queries")] ListMetadataQuery[] queries, double asOfVersion)
        {
            object[] results = this.Invoke("listMetadata", new object[] {
                        queries,
                        asOfVersion});
            return ((FileProperties[])(results[0]));
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SessionHeader")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("CallOptions")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace = "http://soap.sforce.com/2006/04/metadata", ResponseNamespace = "http://soap.sforce.com/2006/04/metadata", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute("result")]
        [return: System.Xml.Serialization.XmlArrayItemAttribute("records", IsNullable = false)]
        public Metadata[] readMetadata(string type, [System.Xml.Serialization.XmlElementAttribute("fullNames")] string[] fullNames)
        {
            object[] results = this.Invoke("readMetadata", new object[] {
                        type,
                        fullNames});
            return ((Metadata[])(results[0]));
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SessionHeader")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("CallOptions")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace = "http://soap.sforce.com/2006/04/metadata", ResponseNamespace = "http://soap.sforce.com/2006/04/metadata", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("result")]
        public SaveResult renameMetadata(string type, string oldFullName, string newFullName)
        {
            object[] results = this.Invoke("renameMetadata", new object[] {
                        type,
                        oldFullName,
                        newFullName});
            return ((SaveResult)(results[0]));
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SessionHeader")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("CallOptions")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace = "http://soap.sforce.com/2006/04/metadata", ResponseNamespace = "http://soap.sforce.com/2006/04/metadata", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("result")]
        public AsyncResult retrieve(RetrieveRequest retrieveRequest)
        {
            object[] results = this.Invoke("retrieve", new object[] {
                        retrieveRequest});
            return ((AsyncResult)(results[0]));
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SessionHeader")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("CallOptions")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace = "http://soap.sforce.com/2006/04/metadata", ResponseNamespace = "http://soap.sforce.com/2006/04/metadata", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("result")]
        public SaveResult[] updateMetadata([System.Xml.Serialization.XmlElementAttribute("metadata")] Metadata[] metadata)
        {
            object[] results = this.Invoke("updateMetadata", new object[] {
                        metadata});
            return ((SaveResult[])(results[0]));
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapHeaderAttribute("SessionHeader")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("CallOptions")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace = "http://soap.sforce.com/2006/04/metadata", ResponseNamespace = "http://soap.sforce.com/2006/04/metadata", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("result")]
        public UpsertResult[] upsertMetadata([System.Xml.Serialization.XmlElementAttribute("metadata")] Metadata[] metadata)
        {
            object[] results = this.Invoke("upsertMetadata", new object[] {
                        metadata});
            return ((UpsertResult[])(results[0]));
        }
        #endregion

        #region Asynchronous Calls

        /// <remarks/>
        public void cancelDeployAsync(string String) {
            this.cancelDeployAsync(String, null);
        }
        
        /// <remarks/>
        public void cancelDeployAsync(string String, object userState) {
            if ((this.cancelDeployOperationCompleted == null)) {
                this.cancelDeployOperationCompleted = new System.Threading.SendOrPostCallback(this.OncancelDeployOperationCompleted);
            }
            this.InvokeAsync("cancelDeploy", new object[] {
                        String}, this.cancelDeployOperationCompleted, userState);
        }
        
        private void OncancelDeployOperationCompleted(object arg) {
            if ((this.cancelDeployCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.cancelDeployCompleted(this, new cancelDeployCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        
        /// <remarks/>
        public void checkDeployStatusAsync(string asyncProcessId, bool includeDetails) {
            this.checkDeployStatusAsync(asyncProcessId, includeDetails, null);
        }
        
        /// <remarks/>
        public void checkDeployStatusAsync(string asyncProcessId, bool includeDetails, object userState) {
            if ((this.checkDeployStatusOperationCompleted == null)) {
                this.checkDeployStatusOperationCompleted = new System.Threading.SendOrPostCallback(this.OncheckDeployStatusOperationCompleted);
            }
            this.InvokeAsync("checkDeployStatus", new object[] {
                        asyncProcessId,
                        includeDetails}, this.checkDeployStatusOperationCompleted, userState);
        }
        
        private void OncheckDeployStatusOperationCompleted(object arg) {
            if ((this.checkDeployStatusCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.checkDeployStatusCompleted(this, new checkDeployStatusCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        
        /// <remarks/>
        public void checkRetrieveStatusAsync(string asyncProcessId) {
            this.checkRetrieveStatusAsync(asyncProcessId, null);
        }
        
        /// <remarks/>
        public void checkRetrieveStatusAsync(string asyncProcessId, object userState) {
            if ((this.checkRetrieveStatusOperationCompleted == null)) {
                this.checkRetrieveStatusOperationCompleted = new System.Threading.SendOrPostCallback(this.OncheckRetrieveStatusOperationCompleted);
            }
            this.InvokeAsync("checkRetrieveStatus", new object[] {
                        asyncProcessId}, this.checkRetrieveStatusOperationCompleted, userState);
        }
        
        private void OncheckRetrieveStatusOperationCompleted(object arg) {
            if ((this.checkRetrieveStatusCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.checkRetrieveStatusCompleted(this, new checkRetrieveStatusCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        
        /// <remarks/>
        public void createMetadataAsync(Metadata[] metadata) {
            this.createMetadataAsync(metadata, null);
        }
        
        /// <remarks/>
        public void createMetadataAsync(Metadata[] metadata, object userState) {
            if ((this.createMetadataOperationCompleted == null)) {
                this.createMetadataOperationCompleted = new System.Threading.SendOrPostCallback(this.OncreateMetadataOperationCompleted);
            }
            this.InvokeAsync("createMetadata", new object[] {
                        metadata}, this.createMetadataOperationCompleted, userState);
        }
        
        private void OncreateMetadataOperationCompleted(object arg) {
            if ((this.createMetadataCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.createMetadataCompleted(this, new createMetadataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        
        /// <remarks/>
        public void deleteMetadataAsync(string type, string[] fullNames) {
            this.deleteMetadataAsync(type, fullNames, null);
        }
        
        /// <remarks/>
        public void deleteMetadataAsync(string type, string[] fullNames, object userState) {
            if ((this.deleteMetadataOperationCompleted == null)) {
                this.deleteMetadataOperationCompleted = new System.Threading.SendOrPostCallback(this.OndeleteMetadataOperationCompleted);
            }
            this.InvokeAsync("deleteMetadata", new object[] {
                        type,
                        fullNames}, this.deleteMetadataOperationCompleted, userState);
        }
        
        private void OndeleteMetadataOperationCompleted(object arg) {
            if ((this.deleteMetadataCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.deleteMetadataCompleted(this, new deleteMetadataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        
        /// <remarks/>
        public void deployAsync(byte[] ZipFile, DeployOptions DeployOptions) {
            this.deployAsync(ZipFile, DeployOptions, null);
        }
        
        /// <remarks/>
        public void deployAsync(byte[] ZipFile, DeployOptions DeployOptions, object userState) {
            if ((this.deployOperationCompleted == null)) {
                this.deployOperationCompleted = new System.Threading.SendOrPostCallback(this.OndeployOperationCompleted);
            }
            this.InvokeAsync("deploy", new object[] {
                        ZipFile,
                        DeployOptions}, this.deployOperationCompleted, userState);
        }
        
        private void OndeployOperationCompleted(object arg) {
            if ((this.deployCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.deployCompleted(this, new deployCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        
        /// <remarks/>
        public void describeMetadataAsync(double asOfVersion) {
            this.describeMetadataAsync(asOfVersion, null);
        }
        
        /// <remarks/>
        public void describeMetadataAsync(double asOfVersion, object userState) {
            if ((this.describeMetadataOperationCompleted == null)) {
                this.describeMetadataOperationCompleted = new System.Threading.SendOrPostCallback(this.OndescribeMetadataOperationCompleted);
            }
            this.InvokeAsync("describeMetadata", new object[] {
                        asOfVersion}, this.describeMetadataOperationCompleted, userState);
        }
        
        private void OndescribeMetadataOperationCompleted(object arg) {
            if ((this.describeMetadataCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.describeMetadataCompleted(this, new describeMetadataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        
        /// <remarks/>
        public void listMetadataAsync(ListMetadataQuery[] queries, double asOfVersion) {
            this.listMetadataAsync(queries, asOfVersion, null);
        }
        
        /// <remarks/>
        public void listMetadataAsync(ListMetadataQuery[] queries, double asOfVersion, object userState) {
            if ((this.listMetadataOperationCompleted == null)) {
                this.listMetadataOperationCompleted = new System.Threading.SendOrPostCallback(this.OnlistMetadataOperationCompleted);
            }
            this.InvokeAsync("listMetadata", new object[] {
                        queries,
                        asOfVersion}, this.listMetadataOperationCompleted, userState);
        }
        
        private void OnlistMetadataOperationCompleted(object arg) {
            if ((this.listMetadataCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.listMetadataCompleted(this, new listMetadataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        
        /// <remarks/>
        public void readMetadataAsync(string type, string[] fullNames) {
            this.readMetadataAsync(type, fullNames, null);
        }
        
        /// <remarks/>
        public void readMetadataAsync(string type, string[] fullNames, object userState) {
            if ((this.readMetadataOperationCompleted == null)) {
                this.readMetadataOperationCompleted = new System.Threading.SendOrPostCallback(this.OnreadMetadataOperationCompleted);
            }
            this.InvokeAsync("readMetadata", new object[] {
                        type,
                        fullNames}, this.readMetadataOperationCompleted, userState);
        }
        
        private void OnreadMetadataOperationCompleted(object arg) {
            if ((this.readMetadataCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.readMetadataCompleted(this, new readMetadataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        
        /// <remarks/>
        public void renameMetadataAsync(string type, string oldFullName, string newFullName) {
            this.renameMetadataAsync(type, oldFullName, newFullName, null);
        }
        
        /// <remarks/>
        public void renameMetadataAsync(string type, string oldFullName, string newFullName, object userState) {
            if ((this.renameMetadataOperationCompleted == null)) {
                this.renameMetadataOperationCompleted = new System.Threading.SendOrPostCallback(this.OnrenameMetadataOperationCompleted);
            }
            this.InvokeAsync("renameMetadata", new object[] {
                        type,
                        oldFullName,
                        newFullName}, this.renameMetadataOperationCompleted, userState);
        }
        
        private void OnrenameMetadataOperationCompleted(object arg) {
            if ((this.renameMetadataCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.renameMetadataCompleted(this, new renameMetadataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        
        /// <remarks/>
        public void retrieveAsync(RetrieveRequest retrieveRequest) {
            this.retrieveAsync(retrieveRequest, null);
        }
        
        /// <remarks/>
        public void retrieveAsync(RetrieveRequest retrieveRequest, object userState) {
            if ((this.retrieveOperationCompleted == null)) {
                this.retrieveOperationCompleted = new System.Threading.SendOrPostCallback(this.OnretrieveOperationCompleted);
            }
            this.InvokeAsync("retrieve", new object[] {
                        retrieveRequest}, this.retrieveOperationCompleted, userState);
        }
        
        private void OnretrieveOperationCompleted(object arg) {
            if ((this.retrieveCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.retrieveCompleted(this, new retrieveCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        
        /// <remarks/>
        public void updateMetadataAsync(Metadata[] metadata) {
            this.updateMetadataAsync(metadata, null);
        }
        
        /// <remarks/>
        public void updateMetadataAsync(Metadata[] metadata, object userState) {
            if ((this.updateMetadataOperationCompleted == null)) {
                this.updateMetadataOperationCompleted = new System.Threading.SendOrPostCallback(this.OnupdateMetadataOperationCompleted);
            }
            this.InvokeAsync("updateMetadata", new object[] {
                        metadata}, this.updateMetadataOperationCompleted, userState);
        }
        
        private void OnupdateMetadataOperationCompleted(object arg) {
            if ((this.updateMetadataCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.updateMetadataCompleted(this, new updateMetadataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        
        /// <remarks/>
        public void upsertMetadataAsync(Metadata[] metadata) {
            this.upsertMetadataAsync(metadata, null);
        }
        
        /// <remarks/>
        public void upsertMetadataAsync(Metadata[] metadata, object userState) {
            if ((this.upsertMetadataOperationCompleted == null)) {
                this.upsertMetadataOperationCompleted = new System.Threading.SendOrPostCallback(this.OnupsertMetadataOperationCompleted);
            }
            this.InvokeAsync("upsertMetadata", new object[] {
                        metadata}, this.upsertMetadataOperationCompleted, userState);
        }
        
        private void OnupsertMetadataOperationCompleted(object arg) {
            if ((this.upsertMetadataCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.upsertMetadataCompleted(this, new upsertMetadataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        #endregion
    }
    
}
