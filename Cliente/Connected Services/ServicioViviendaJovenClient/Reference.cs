﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cliente.ServicioViviendaJovenClient {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DTOBarrio", Namespace="http://schemas.datacontract.org/2004/07/Servicio")]
    [System.SerializableAttribute()]
    public partial class DTOBarrio : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescripcionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descripcion {
            get {
                return this.DescripcionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescripcionField, value) != true)) {
                    this.DescripcionField = value;
                    this.RaisePropertyChanged("Descripcion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicioViviendaJovenClient.IServicioViviendaJoven")]
    public interface IServicioViviendaJoven {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioViviendaJoven/AltaBarrio", ReplyAction="http://tempuri.org/IServicioViviendaJoven/AltaBarrioResponse")]
        bool AltaBarrio(Cliente.ServicioViviendaJovenClient.DTOBarrio b);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioViviendaJoven/AltaBarrio", ReplyAction="http://tempuri.org/IServicioViviendaJoven/AltaBarrioResponse")]
        System.Threading.Tasks.Task<bool> AltaBarrioAsync(Cliente.ServicioViviendaJovenClient.DTOBarrio b);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicioViviendaJovenChannel : Cliente.ServicioViviendaJovenClient.IServicioViviendaJoven, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicioViviendaJovenClient : System.ServiceModel.ClientBase<Cliente.ServicioViviendaJovenClient.IServicioViviendaJoven>, Cliente.ServicioViviendaJovenClient.IServicioViviendaJoven {
        
        public ServicioViviendaJovenClient() {
        }
        
        public ServicioViviendaJovenClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioViviendaJovenClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioViviendaJovenClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioViviendaJovenClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool AltaBarrio(Cliente.ServicioViviendaJovenClient.DTOBarrio b) {
            return base.Channel.AltaBarrio(b);
        }
        
        public System.Threading.Tasks.Task<bool> AltaBarrioAsync(Cliente.ServicioViviendaJovenClient.DTOBarrio b) {
            return base.Channel.AltaBarrioAsync(b);
        }
    }
}