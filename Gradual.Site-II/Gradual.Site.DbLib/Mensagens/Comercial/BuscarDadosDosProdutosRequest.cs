﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gradual.OMS.Library;

namespace Gradual.Site.DbLib.Mensagens
{
    [Serializable]
    [DataContract]
    public class BuscarDadosDosProdutosRequest: MensagemRequestBase
    {
        [DataMember]
        public int? IdProduto { get; set; }

        [DataMember]
        public int? Plano { get; set; }
    }
}
