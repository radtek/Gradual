﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Gradual.OMS.Risco.RegraLib.Dados;
using Gradual.OMS.Library;


namespace Gradual.OMS.Risco.RegraLib.Mensagens
{
    public class ReceberParametroRiscoResponse : MensagemResponseBase
    {
        public ParametroRiscoInfo ParametroRisco { get; set; }
    }
}