﻿using System;
using Gradual.OMS.Library;
using Gradual.Intranet.Contratos.Dados.Enumeradores;

namespace Gradual.Intranet.Contratos.Dados.Relatorios.Monitoramento
{
    public class ClientePosicaoDeOpcaoRelInfo : ICodigoEntidade
    {
        #region | Propriedades consulta

        public string ConsultaCodigoAssessor { get; set; }

        public int? ConsultaCodigoCarteira { get; set; }

        public int? ConsultarStrike { get; set; }

        public OpcoesBuscarPor ConsultaClienteTipo { get; set; }

        public string ConsultaClienteParametro { get; set; } 

        public string ConsultaPapel { get; set; }

        public string ConsultaSerie { get; set; }

        public Nullable<DateTime> ConsultaDtVencimento { get; set; }

        public int? ConsultaSentidoCompradoLancado { get; set; }

        #endregion

        #region Propriedades de apresentação

        public int CdCliente { get; set; }

        public string NmCliente { get; set; }

        public int CdAssessor { get; set; }

        public string DsPapel { get; set; }

        public int QtQuantidade { get; set; }

        public int QtQuantidadeAbertura { get; set; }

        public int QtQunatidadeAtual { get; set; }

        public int QtQuandidadeD1 { get; set; }

        public DateTime DtVencimento { get; set; }

        public DateTime DtStrike { get; set; }

        public int IdCarteira { get; set; }

        public string NomeAssessor { get; set; }

        public decimal PrecoExercicio { get; set; }

        #endregion

        #region | Implementação do contrato

        public string ReceberCodigo()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
