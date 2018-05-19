﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;
using log4net;
using System.Configuration;

namespace Gradual.OMS.Cotacao
{
    public class QueueManager
    {
        private struct SinalStruct
        {
            public string Instrumento { get; set; }
            public string Mensagem { get; set; }
        }

        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static QueueManager _me = null;
        private Thread _thProc = null;
        private bool _bKeepRunning;
        private ConcurrentQueue<SinalStruct> queueSinal = new ConcurrentQueue<SinalStruct>();
        private bool _filtraIndiceCheio = false;

        public ComposicaoIndice ComposicaoIndice { get; set; }
        public IndiceGradual IndiceGradual { get; set; }

        public static QueueManager Instance
        {
            get
            {
                if (_me == null)
                {
                    _me = new QueueManager();
                }
                return _me;
            }
        }

        public QueueManager()
        {
            if (ConfigurationManager.AppSettings["FiltraIndiceCheio"] != null &&
                ConfigurationManager.AppSettings["FiltraIndiceCheio"].ToString().ToUpper().Equals("TRUE"))
            {
                _filtraIndiceCheio = true;
            }
        }

        public void Start()
        {
            logger.Info("Iniciando processador da fila de sinais");

            _bKeepRunning = true;
            _thProc = new Thread(new ThreadStart(procSinal));
            _thProc.Name = "procSinal";
            _thProc.Start();
        }

        public void Stop()
        {
            logger.Info("Finalizando processador da fila de sinais");
            _bKeepRunning = false;

            while (_thProc != null && _thProc.IsAlive)
            {
                Thread.Sleep(100);
            }

            logger.Info("Processador da fila de sinais finalizado");
        }

        public void EnqueueSinal(string instrumento, string mensagem)
        {
            try
            {

                SinalStruct sinal = new SinalStruct();
                sinal.Instrumento = instrumento;
                sinal.Mensagem = mensagem;

                queueSinal.Enqueue(sinal);
            }
            catch (Exception ex)
            {
                logger.Error("EnqueueSinal: " + ex.Message, ex);
            }

        }


        private void procSinal()
        {
            long lastLogTicks = 0;
            while (_bKeepRunning)
            {
                try
                {
                    SinalStruct sinal;

                    if (queueSinal.TryDequeue(out sinal))
                    {
                        MessageBroker(sinal.Instrumento, sinal.Mensagem);

                        if (shouldLog(lastLogTicks))
                        {
                            logger.Info("Fila de sinais a processar: " + queueSinal.Count);
                            lastLogTicks = DateTime.Now.Ticks;
                        }
                        continue;
                    }
                    
                    Thread.Sleep(100);
                }
                catch(Exception ex )
                {
                    logger.Error("procSinal:" + ex.Message, ex);
                }
            }
        }

        public static bool shouldLog(long lastEventTicks)
        {
            if ((DateTime.Now.Ticks - lastEventTicks) > TimeSpan.TicksPerSecond)
                return true;

            return false;
        }

        private void MessageBroker(string Instrumento, string Mensagem)
        {
            try
            {
                logger.Debug("[" + Instrumento + "] [" + Mensagem + "]");

                if (_filtraIndiceCheio)
                {
                    if (Mensagem.Substring(2, 2).Equals("BF")
                        && !Instrumento.Substring(0, 1).Equals("W"))
                    {
                        return;
                    }
                }

                switch (Mensagem.ToString().Substring(0, 2))
                {

                    case ConstantesMDS.Negocio:
                        MemoriaCotacao.LastNegocioPacket = DateTime.Now;
                        MemoriaCotacao.LastNegocioMsg = Mensagem;
                        //MemoriaCotacao.AdicionarLivroNegocios(Instrumento, Mensagem);
                        MemoriaCotacao.AdicionarNegocio(Instrumento, Mensagem);
                        MemoriaCotacao.AdicionarNegocioIndiceGradual(Instrumento, Mensagem);
                        MemoriaCotacao.ProcessaSonda(Instrumento, Mensagem);

                        //ComposicaoIndice.RecalcularIndice(Instrumento, Mensagem);

                        if (Instrumento.Equals(IndiceGradual.INDICE_IBOV))
                            IndiceGradual.AtualizarIndiceGradual(Instrumento, Mensagem);

                        if (MemoriaCotacaoDelay.GetInstance().DelayTickerOn)
                        {
                            MemoriaCotacaoDelay.GetInstance().AdicionarFilaLivroNegocios(Instrumento, Mensagem);
                        }
                        break;
                    case ConstantesMDS.LivroNegocio:
                        MemoriaCotacao.LastLofPacket = DateTime.Now;
                        MemoriaCotacao.LastLofMsg = Mensagem;
                        MemoriaCotacao.AdicionarLivroNegocios(Instrumento, Mensagem);
                        break;
                    case ConstantesMDS.LivroOferta:
                        MemoriaCotacao.LastLofPacket = DateTime.Now;
                        MemoriaCotacao.LastLofMsg = Mensagem;
                        MemoriaCotacao.AdicionarTikerLivroOferta(Instrumento, Mensagem);
                        break;
                    case ConstantesMDS.Destaques:
                        MemoriaCotacao.LastDestaquePacket = DateTime.Now;
                        MemoriaCotacao.LastDestaqueMsg = Mensagem;
                        MemoriaCotacao.AdicionarTikerDestaques(Mensagem);
                        break;
                    case ConstantesMDS.RankCorretora:
                        MemoriaCotacao.LastRankingPacket = DateTime.Now;
                        MemoriaCotacao.LastRankingMsg = Mensagem;
                        MemoriaCotacao.AdicionarTickerRankCorretora(Instrumento, Mensagem);
                        break;
                    case ConstantesMDS.Sonda:
                        logger.Info("Recebeu Sonda: [" + Mensagem + "]");
                        MemoriaCotacao.LastSondaMsg = Mensagem;
                        MemoriaCotacao.ProcessaSonda(Instrumento, Mensagem);
                        break;
                    case ConstantesMDS.LIVRO_AGREGADO:
                        MemoriaCotacao.LastAgregadoPacket = DateTime.Now;
                        MemoriaCotacao.LastAgregadoMsg = Mensagem;
                        MemoriaCotacao.AdicionarTikerLivroAgregado(Instrumento, Mensagem);
                        break;
                }
            }
            catch (Exception ex)
            {
                logger.Error("MessageBroker(): " + ex.Message, ex);

                if (!String.IsNullOrEmpty(Instrumento))
                    logger.Error("Instrumento [" + Instrumento + "]");

                if (!String.IsNullOrEmpty(Mensagem))
                    logger.Error("Mensagem [" + Mensagem + "]");
            }
        }

    }
}