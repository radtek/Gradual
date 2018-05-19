﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Gradual.OMS.Contratos.Ordens.Mensagens;

namespace Gradual.OMS.Contratos.Ordens.Dados
{
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class SinalizarMensagemInvalidaEventArgs : EventArgs
    {
        public SinalizarMensagemInvalidaRequest SinalizarMensagemInvalidaRequest { get; set; }
    }
}