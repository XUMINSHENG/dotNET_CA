﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseRegistrationSystem.ServiceReference2 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ConfirmClassId", ReplyAction="http://tempuri.org/IService/ConfirmClassIdResponse")]
        CourseRegistrationSystem.ServiceReference2.ConfirmClassIdResponse ConfirmClassId(CourseRegistrationSystem.ServiceReference2.ConfirmClassIdRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ConfirmClassId", ReplyAction="http://tempuri.org/IService/ConfirmClassIdResponse")]
        System.Threading.Tasks.Task<CourseRegistrationSystem.ServiceReference2.ConfirmClassIdResponse> ConfirmClassIdAsync(CourseRegistrationSystem.ServiceReference2.ConfirmClassIdRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ReceiveDecision", ReplyAction="http://tempuri.org/IService/ReceiveDecisionResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="result")]
        bool ReceiveDecision(bool isConfirm, string classId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ReceiveDecision", ReplyAction="http://tempuri.org/IService/ReceiveDecisionResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="result")]
        System.Threading.Tasks.Task<bool> ReceiveDecisionAsync(bool isConfirm, string classId);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ConfirmClassId", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ConfirmClassIdRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string classId;
        
        public ConfirmClassIdRequest() {
        }
        
        public ConfirmClassIdRequest(string classId) {
            this.classId = classId;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ConfirmClassIdResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ConfirmClassIdResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string classId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string reg;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public bool needToAsk;
        
        public ConfirmClassIdResponse() {
        }
        
        public ConfirmClassIdResponse(string classId, string reg, bool needToAsk) {
            this.classId = classId;
            this.reg = reg;
            this.needToAsk = needToAsk;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : CourseRegistrationSystem.ServiceReference2.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<CourseRegistrationSystem.ServiceReference2.IService>, CourseRegistrationSystem.ServiceReference2.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        CourseRegistrationSystem.ServiceReference2.ConfirmClassIdResponse CourseRegistrationSystem.ServiceReference2.IService.ConfirmClassId(CourseRegistrationSystem.ServiceReference2.ConfirmClassIdRequest request) {
            return base.Channel.ConfirmClassId(request);
        }
        
        public string ConfirmClassId(ref string classId, out bool needToAsk) {
            CourseRegistrationSystem.ServiceReference2.ConfirmClassIdRequest inValue = new CourseRegistrationSystem.ServiceReference2.ConfirmClassIdRequest();
            inValue.classId = classId;
            CourseRegistrationSystem.ServiceReference2.ConfirmClassIdResponse retVal = ((CourseRegistrationSystem.ServiceReference2.IService)(this)).ConfirmClassId(inValue);
            classId = retVal.classId;
            needToAsk = retVal.needToAsk;
            return retVal.reg;
        }
        
        public System.Threading.Tasks.Task<CourseRegistrationSystem.ServiceReference2.ConfirmClassIdResponse> ConfirmClassIdAsync(CourseRegistrationSystem.ServiceReference2.ConfirmClassIdRequest request) {
            return base.Channel.ConfirmClassIdAsync(request);
        }
        
        public bool ReceiveDecision(bool isConfirm, string classId) {
            return base.Channel.ReceiveDecision(isConfirm, classId);
        }
        
        public System.Threading.Tasks.Task<bool> ReceiveDecisionAsync(bool isConfirm, string classId) {
            return base.Channel.ReceiveDecisionAsync(isConfirm, classId);
        }
    }
}
