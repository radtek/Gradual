﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gradual.OMS.Library;

namespace Gradual.Intranet.Contratos.Dados
{
    public class AtividadeIlicitaInfo : ICodigoEntidade
    {
        public Nullable<Int32> IdAtividadeIlicita { get; set; }
        public string  CdAtividade { get; set; }

        #region ICodigoEntidade Members

        public string ReceberCodigo()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
