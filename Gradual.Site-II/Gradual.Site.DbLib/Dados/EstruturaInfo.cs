﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gradual.Site.DbLib.Mensagens;

namespace Gradual.Site.DbLib.Dados
{
    [Serializable]
    [DataContract]
    public class EstruturaInfo
    {
        /// <summary>
        /// ID da tabela
        /// </summary>
        [DataMember]
        public int CodigoEstrutura { get; set; }

        /// <summary>
        /// ID da Pagina
        /// </summary>
        [DataMember]
        public int CodigoPagina { get; set; }

        /// <summary>
        /// Nome do Autor
        /// </summary>
        [DataMember]
        public string NomeAutor { get; set; }
        
        [DataMember]
        public string IdentificadorVersao { get; set; }

        /// <summary>
        /// Tipo Usuário
        /// </summary>
        [DataMember]
        public int TipoUsuario { get; set; }

        /// <summary>
        /// Data de Criação
        /// </summary>
        [DataMember]
        public DateTime DtCriacao { get; set; }

        // <summary>
        /// Estrutura em JSON
        /// </summary>
        [DataMember]
        public string EstruturaJson { get; set; }


        // <summary>
        /// Lista de objetos widget
        /// </summary>
        [DataMember]
        public List<WidgetInfo> ListaWidget { get; set; }

    }
}