///////////////////////////////////////////////////////////
//  PermissaoRiscoInfo.cs
//  Implementation of the Class PermissaoRiscoInfo
//  Generated by Enterprise Architect
//  Created on:      26-jul-2010 15:31:55
//  Original author: amiguel
///////////////////////////////////////////////////////////




using Gradual.OMS.Library;
using System;

namespace Gradual.OMS.Risco.RegraLib.Dados
{
    [Serializable]
    public class PermissaoRiscoInfo : ICodigoEntidade
    {

        public BolsaInfo Bolsa { get; set; }

        public int CodigoPermissao { get; set; }

        public string NomePermissao { get; set; }

        public string NameSpace { get; set; }

        public string Metodo { get; set; }


        #region ICodigoEntidade Members

        public string ReceberCodigo()
        {
            return this.CodigoPermissao.ToString();
        }

        #endregion
    }//end PermissaoRiscoInfo

}//end namespace Dados