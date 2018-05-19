﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gradual.OMS.InvXX.Fundos.DbLib.ANBIMA {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SqlANBIMA {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SqlANBIMA() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Gradual.OMS.InvXX.Fundos.DbLib.ANBIMA.SqlANBIMA", typeof(SqlANBIMA).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select * from fundos where codFundo = {0}.
        /// </summary>
        internal static string ListaFundos {
            get {
                return ResourceManager.GetString("ListaFundos", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to select 
        ///a.codfundo as idCodigoAnbima
        ///,a.fantasia as dsNomeProduto
        ///,cnpj as CPFCNPJ
        ///,classeCVM.opcoes_status as categoria
        ///,tipoInvestidor.opcoes_status as dsClienteAlvo
        ///,c.fantasia as Administrador
        ///,b.fantasia as Gestor
        ///,tributacao.opcoes_status as Tributacao
        ///,a.codtipo as idTipoAmbima
        ///,a.aberto as stPermitirNovasAplicacoes
        ///,focoAtuacao.opcoes_status as FocoAtuacao
        ///,a.dataIni
        ///,a.datafim
        ///,a.datainfo
        ///from DBA.fundos a 
        ///inner join DBA.instituicoes b
        ///on a.gestor = b.codinst 
        ///inner join DBA.inst [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ListaFundosSite {
            get {
                return ResourceManager.GetString("ListaFundosSite", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select * from fundos_status where codFundo = {0}.
        /// </summary>
        internal static string ListaFundoStatus {
            get {
                return ResourceManager.GetString("ListaFundoStatus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select * from fundos_tipo.
        /// </summary>
        internal static string ListaFundoTipo {
            get {
                return ResourceManager.GetString("ListaFundoTipo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select * from indicadores.
        /// </summary>
        internal static string ListaIndicadores {
            get {
                return ResourceManager.GetString("ListaIndicadores", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select * from indic_mes where datahora &gt; &apos;{0}&apos;.
        /// </summary>
        internal static string ListaIndicadoresMes {
            get {
                return ResourceManager.GetString("ListaIndicadoresMes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select * from Instituicoes.
        /// </summary>
        internal static string ListaInstituicao {
            get {
                return ResourceManager.GetString("ListaInstituicao", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select * from fundos_mov_cota where codFundo = {0}.
        /// </summary>
        internal static string ListaMovimentoCota {
            get {
                return ResourceManager.GetString("ListaMovimentoCota", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT        mov.codfundo, mov.data, mov.vlr_min_aplic_ini, mov.vlr_min_aplic_adic, mov.vlr_min_resgate, mov.vlr_min_aplic, mov.identificador, taxa.cobra_taxa_perform, 
        ///                         taxa.taxa_entrada, fundos.prazo_conv_resg, fundos.prazo_pgto_resg, fundos.perfil_cota, rent.pl, taxa.taxa_fixa, mov.DataHora,taxa.taxa_perform
        ///FROM            DBA.fundos_mov_cota mov, DBA.taxa_adm taxa, DBA.fundos fundos, DBA.fundos_dia rent
        ///WHERE        mov.codfundo = taxa.codfundo AND taxa.codfundo = fundos.cod [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ListaMovimentoCotaSite {
            get {
                return ResourceManager.GetString("ListaMovimentoCotaSite", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select * from fundos_dia where codfundo = &apos;{0}&apos; and data &gt;&apos;{1}&apos;.
        /// </summary>
        internal static string ListaRentabilidadeDia {
            get {
                return ResourceManager.GetString("ListaRentabilidadeDia", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select * from fundos_mes where codfundo = &apos;{0}&apos; and datahora &gt; &apos;{1}&apos;.
        /// </summary>
        internal static string ListaRentabilidadeMes {
            get {
                return ResourceManager.GetString("ListaRentabilidadeMes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select * from taxa_adm where codFundo = {0}.
        /// </summary>
        internal static string ListaTaxaAdm {
            get {
                return ResourceManager.GetString("ListaTaxaAdm", resourceCulture);
            }
        }
    }
}
