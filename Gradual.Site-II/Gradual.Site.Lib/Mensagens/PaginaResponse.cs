﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gradual.OMS.Library;
using Gradual.Site.Lib.Dados;

namespace Gradual.Site.Lib.Mensagens
{
    [Serializable]
    [DataContract]
    public class PaginaResponse : MensagemResponseBase
    {
        [DataMember]
        public PaginaInfo Pagina { get; set; }

        [DataMember]
        public List<PaginaInfo> ListaPagina { get; set; }
    }
}
