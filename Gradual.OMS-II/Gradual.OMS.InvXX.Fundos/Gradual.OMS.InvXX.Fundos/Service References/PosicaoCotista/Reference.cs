﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gradual.OMS.InvXX.Fundos.PosicaoCotista {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PosicaoCotista.PosicaoCotistaWSSoap")]
    public interface PosicaoCotistaWSSoap {
        
        // CODEGEN: Generating message contract since message ExportaRequest has headers
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Exporta", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(esPosicaoCotista))]
        Gradual.OMS.InvXX.Fundos.PosicaoCotista.ExportaResponse Exporta(Gradual.OMS.InvXX.Fundos.PosicaoCotista.ExportaRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ValidateLogin : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string usernameField;
        
        private string passwordField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Username {
            get {
                return this.usernameField;
            }
            set {
                this.usernameField = value;
                this.RaisePropertyChanged("Username");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
                this.RaisePropertyChanged("Password");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr {
            get {
                return this.anyAttrField;
            }
            set {
                this.anyAttrField = value;
                this.RaisePropertyChanged("AnyAttr");
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
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PosicaoCotista))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public abstract partial class esPosicaoCotista : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.Nullable<int> idPosicaoField;
        
        private System.Nullable<int> idOperacaoField;
        
        private System.Nullable<int> idCotistaField;
        
        private System.Nullable<int> idCarteiraField;
        
        private System.Nullable<decimal> valorAplicacaoField;
        
        private System.Nullable<System.DateTime> dataAplicacaoField;
        
        private System.Nullable<System.DateTime> dataConversaoField;
        
        private System.Nullable<decimal> cotaAplicacaoField;
        
        private System.Nullable<decimal> cotaDiaField;
        
        private System.Nullable<decimal> valorBrutoField;
        
        private System.Nullable<decimal> valorLiquidoField;
        
        private System.Nullable<decimal> quantidadeInicialField;
        
        private System.Nullable<decimal> quantidadeField;
        
        private System.Nullable<decimal> quantidadeBloqueadaField;
        
        private System.Nullable<System.DateTime> dataUltimaCobrancaIRField;
        
        private System.Nullable<decimal> valorIRField;
        
        private System.Nullable<decimal> valorIOFField;
        
        private System.Nullable<decimal> valorPerformanceField;
        
        private System.Nullable<decimal> valorIOFVirtualField;
        
        private System.Nullable<decimal> quantidadeAntesCortesField;
        
        private System.Nullable<decimal> valorRendimentoField;
        
        private System.Nullable<System.DateTime> dataUltimoCortePfeeField;
        
        private string posicaoIncorporadaField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
        public System.Nullable<int> IdPosicao {
            get {
                return this.idPosicaoField;
            }
            set {
                this.idPosicaoField = value;
                this.RaisePropertyChanged("IdPosicao");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=1)]
        public System.Nullable<int> IdOperacao {
            get {
                return this.idOperacaoField;
            }
            set {
                this.idOperacaoField = value;
                this.RaisePropertyChanged("IdOperacao");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=2)]
        public System.Nullable<int> IdCotista {
            get {
                return this.idCotistaField;
            }
            set {
                this.idCotistaField = value;
                this.RaisePropertyChanged("IdCotista");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=3)]
        public System.Nullable<int> IdCarteira {
            get {
                return this.idCarteiraField;
            }
            set {
                this.idCarteiraField = value;
                this.RaisePropertyChanged("IdCarteira");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=4)]
        public System.Nullable<decimal> ValorAplicacao {
            get {
                return this.valorAplicacaoField;
            }
            set {
                this.valorAplicacaoField = value;
                this.RaisePropertyChanged("ValorAplicacao");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=5)]
        public System.Nullable<System.DateTime> DataAplicacao {
            get {
                return this.dataAplicacaoField;
            }
            set {
                this.dataAplicacaoField = value;
                this.RaisePropertyChanged("DataAplicacao");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=6)]
        public System.Nullable<System.DateTime> DataConversao {
            get {
                return this.dataConversaoField;
            }
            set {
                this.dataConversaoField = value;
                this.RaisePropertyChanged("DataConversao");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=7)]
        public System.Nullable<decimal> CotaAplicacao {
            get {
                return this.cotaAplicacaoField;
            }
            set {
                this.cotaAplicacaoField = value;
                this.RaisePropertyChanged("CotaAplicacao");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=8)]
        public System.Nullable<decimal> CotaDia {
            get {
                return this.cotaDiaField;
            }
            set {
                this.cotaDiaField = value;
                this.RaisePropertyChanged("CotaDia");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=9)]
        public System.Nullable<decimal> ValorBruto {
            get {
                return this.valorBrutoField;
            }
            set {
                this.valorBrutoField = value;
                this.RaisePropertyChanged("ValorBruto");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=10)]
        public System.Nullable<decimal> ValorLiquido {
            get {
                return this.valorLiquidoField;
            }
            set {
                this.valorLiquidoField = value;
                this.RaisePropertyChanged("ValorLiquido");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=11)]
        public System.Nullable<decimal> QuantidadeInicial {
            get {
                return this.quantidadeInicialField;
            }
            set {
                this.quantidadeInicialField = value;
                this.RaisePropertyChanged("QuantidadeInicial");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=12)]
        public System.Nullable<decimal> Quantidade {
            get {
                return this.quantidadeField;
            }
            set {
                this.quantidadeField = value;
                this.RaisePropertyChanged("Quantidade");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=13)]
        public System.Nullable<decimal> QuantidadeBloqueada {
            get {
                return this.quantidadeBloqueadaField;
            }
            set {
                this.quantidadeBloqueadaField = value;
                this.RaisePropertyChanged("QuantidadeBloqueada");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=14)]
        public System.Nullable<System.DateTime> DataUltimaCobrancaIR {
            get {
                return this.dataUltimaCobrancaIRField;
            }
            set {
                this.dataUltimaCobrancaIRField = value;
                this.RaisePropertyChanged("DataUltimaCobrancaIR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=15)]
        public System.Nullable<decimal> ValorIR {
            get {
                return this.valorIRField;
            }
            set {
                this.valorIRField = value;
                this.RaisePropertyChanged("ValorIR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=16)]
        public System.Nullable<decimal> ValorIOF {
            get {
                return this.valorIOFField;
            }
            set {
                this.valorIOFField = value;
                this.RaisePropertyChanged("ValorIOF");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=17)]
        public System.Nullable<decimal> ValorPerformance {
            get {
                return this.valorPerformanceField;
            }
            set {
                this.valorPerformanceField = value;
                this.RaisePropertyChanged("ValorPerformance");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=18)]
        public System.Nullable<decimal> ValorIOFVirtual {
            get {
                return this.valorIOFVirtualField;
            }
            set {
                this.valorIOFVirtualField = value;
                this.RaisePropertyChanged("ValorIOFVirtual");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=19)]
        public System.Nullable<decimal> QuantidadeAntesCortes {
            get {
                return this.quantidadeAntesCortesField;
            }
            set {
                this.quantidadeAntesCortesField = value;
                this.RaisePropertyChanged("QuantidadeAntesCortes");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=20)]
        public System.Nullable<decimal> ValorRendimento {
            get {
                return this.valorRendimentoField;
            }
            set {
                this.valorRendimentoField = value;
                this.RaisePropertyChanged("ValorRendimento");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=21)]
        public System.Nullable<System.DateTime> DataUltimoCortePfee {
            get {
                return this.dataUltimoCortePfeeField;
            }
            set {
                this.dataUltimoCortePfeeField = value;
                this.RaisePropertyChanged("DataUltimoCortePfee");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
        public string PosicaoIncorporada {
            get {
                return this.posicaoIncorporadaField;
            }
            set {
                this.posicaoIncorporadaField = value;
                this.RaisePropertyChanged("PosicaoIncorporada");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class PosicaoCotista : esPosicaoCotista {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Exporta", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ExportaRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public Gradual.OMS.InvXX.Fundos.PosicaoCotista.ValidateLogin ValidateLogin;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> IdPosicao;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> IdCotista;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> IdCarteira;
        
        public ExportaRequest() {
        }
        
        public ExportaRequest(Gradual.OMS.InvXX.Fundos.PosicaoCotista.ValidateLogin ValidateLogin, System.Nullable<int> IdPosicao, System.Nullable<int> IdCotista, System.Nullable<int> IdCarteira) {
            this.ValidateLogin = ValidateLogin;
            this.IdPosicao = IdPosicao;
            this.IdCotista = IdCotista;
            this.IdCarteira = IdCarteira;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ExportaResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ExportaResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public Gradual.OMS.InvXX.Fundos.PosicaoCotista.PosicaoCotista[] ExportaResult;
        
        public ExportaResponse() {
        }
        
        public ExportaResponse(Gradual.OMS.InvXX.Fundos.PosicaoCotista.PosicaoCotista[] ExportaResult) {
            this.ExportaResult = ExportaResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface PosicaoCotistaWSSoapChannel : Gradual.OMS.InvXX.Fundos.PosicaoCotista.PosicaoCotistaWSSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PosicaoCotistaWSSoapClient : System.ServiceModel.ClientBase<Gradual.OMS.InvXX.Fundos.PosicaoCotista.PosicaoCotistaWSSoap>, Gradual.OMS.InvXX.Fundos.PosicaoCotista.PosicaoCotistaWSSoap {
        
        public PosicaoCotistaWSSoapClient() {
        }
        
        public PosicaoCotistaWSSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PosicaoCotistaWSSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PosicaoCotistaWSSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PosicaoCotistaWSSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Gradual.OMS.InvXX.Fundos.PosicaoCotista.ExportaResponse Gradual.OMS.InvXX.Fundos.PosicaoCotista.PosicaoCotistaWSSoap.Exporta(Gradual.OMS.InvXX.Fundos.PosicaoCotista.ExportaRequest request) {
            return base.Channel.Exporta(request);
        }
        
        public Gradual.OMS.InvXX.Fundos.PosicaoCotista.PosicaoCotista[] Exporta(Gradual.OMS.InvXX.Fundos.PosicaoCotista.ValidateLogin ValidateLogin, System.Nullable<int> IdPosicao, System.Nullable<int> IdCotista, System.Nullable<int> IdCarteira) {
            Gradual.OMS.InvXX.Fundos.PosicaoCotista.ExportaRequest inValue = new Gradual.OMS.InvXX.Fundos.PosicaoCotista.ExportaRequest();
            inValue.ValidateLogin = ValidateLogin;
            inValue.IdPosicao = IdPosicao;
            inValue.IdCotista = IdCotista;
            inValue.IdCarteira = IdCarteira;
            Gradual.OMS.InvXX.Fundos.PosicaoCotista.ExportaResponse retVal = ((Gradual.OMS.InvXX.Fundos.PosicaoCotista.PosicaoCotistaWSSoap)(this)).Exporta(inValue);
            return retVal.ExportaResult;
        }
    }
}