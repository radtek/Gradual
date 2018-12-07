﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gradual.OMS.RelatoriosFinanc.Lib.Dados;
using System.Globalization;

namespace Gradual.Site.Www
{
    public class TransporteExtratoNotaDeCorretagem
    {
        private CultureInfo gCultureInfo = new CultureInfo("pt-BR");

        public string NomeBolsa { get; set; }

        public string TipoOperacao { get; set; }

        public string TipoMercado { get; set; }

        public string EspecificacaoTitulo { get; set; }

        public string Observacao { get; set; }

        public string Quantidade { get; set; }

        public string ValorNegocioPosNeg { get; set; }

        public string ValorNegocio { get; set; }

        public string ValorTotalPosNeg { get; set; }

        public string ValorTotal { get; set; }

        public string DC { get; set; }

        public static List<TransporteExtratoNotaDeCorretagem> TraduzirLista(List<NotaDeCorretagemExtratoInfo> pParametros)
        {
            List<TransporteExtratoNotaDeCorretagem> lRetorno = new List<TransporteExtratoNotaDeCorretagem>();
            
            CultureInfo lCultureInfo = new CultureInfo("pt-BR");

            if (pParametros != null)
            {
                foreach (NotaDeCorretagemExtratoInfo nce in pParametros)
                {
                    lRetorno.Add(new TransporteExtratoNotaDeCorretagem()
                                {
                                    NomeBolsa           = nce.NomeBolsa,
                                    TipoOperacao        = nce.TipoOperacao,
                                    DC                  = nce.DC,
                                    EspecificacaoTitulo = string.Concat(nce.CodigoNegocio, " ", nce.NomeEmpresa, " ", nce.EspecificacaoTitulo),
                                    Quantidade          = nce.Quantidade.ToString("N0", lCultureInfo),
                                    Observacao          = string.IsNullOrWhiteSpace(nce.Observacao) ? string.Empty : nce.Observacao.Replace("N", string.Empty),
                                    TipoMercado         = nce.TipoMercado,
                                    ValorNegocio        = nce.ValorNegocio.ToString("N2", lCultureInfo),
                                    ValorNegocioPosNeg  = nce.ValorNegocio >= 0 ? "ValorPositivo" : "ValorNegativo",
                                    ValorTotal          = Math.Abs(nce.ValorTotal).ToString("N2", lCultureInfo),
                                    ValorTotalPosNeg    = nce.ValorTotal >= 0 ? "ValorPositivo" : "ValorNegativo",
                                });
                }
            }

            return lRetorno;
        }
    }
}