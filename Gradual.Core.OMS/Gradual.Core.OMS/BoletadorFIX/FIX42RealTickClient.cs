﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using QuickFix;
using QuickFix.FIX42;
using System.Configuration;
using Gradual.OMS.RoteadorOrdens.Lib.Dados;
using QuickFix.Fields;
using Cortex.OMS.FixUtilities.Lib;
using System.Threading;

namespace BoletadorFIX
{
    public class FIX42RealTickClient: QuickFix.MessageCracker, QuickFix.Application, IBoletador
    {
        private static readonly log4net.ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Session _session = null;
        private Form1 _mainform;

        public string Password
        {
            get;
            set;
        }

        public string CancelOnDisconnect
        {
            get;
            set;
        }

        public bool ResetOnLogon { get; set; }
        public bool Connected
        {
            get;
            internal set;
        }

        #region IApplication interface overrides

        public FIX42RealTickClient(Form1 mainform)
        {
            _mainform = mainform;
        }

        public void OnCreate(SessionID sessionID)
        {
            _session = Session.LookupSession(sessionID);
        }

        public void OnLogon(SessionID sessionID)
        {
            //_mainform.ButtonClient42.BackColor = Color.Green;
            this.Connected = true;
        }

        public void OnLogout(SessionID sessionID)
        {
            //_mainform.ButtonClient42.BackColor = Color.Red;
            this.Connected = false;
        }

        public void FromAdmin(QuickFix.Message message, SessionID sessionID) { }

        public void ToAdmin(QuickFix.Message message, SessionID sessionID)
        {
            // Faz o processamento
            try
            {

                string msgType = message.Header.GetString(35);
                logger.Debug("ToAdmin: " + msgType);

                if (msgType.Equals(QuickFix.FIX42.Logon.MsgType))
                {
                    Logon message2 = (Logon)message;
                    if (!string.IsNullOrEmpty(this.Password))
                    {
                        message2.Set(new RawData(this.Password));
                        message2.Set(new RawDataLength(this.Password.Length));
                    }
                    //if (!string.IsNullOrEmpty(this.CancelOnDisconnect))
                    //{
                    //    char codtype = this.CancelOnDisconnect[0];
                    //    if (codtype >= '0' && codtype <= '3')
                    //    {
                    //        CharField field35002 = new CharField(35002, codtype);
                    //        message2.SetField(field35002);
                    //    }
                    //    IntField field35003 = new IntField(35003, 10000);
                    //    message2.SetField(field35003);
                    //}
                    message2.Set(new HeartBtInt(30));
                    message2.Set(new EncryptMethod(0));
                    message2.Set(new ResetSeqNumFlag(this.ResetOnLogon));
                }

                logger.Debug("toAdmin(). Session id : " + sessionID + " Msg: " + message.GetType().ToString());
                if (message.Header.GetString(35).Equals(QuickFix.FIX42.Heartbeat.MsgType) == false)
                    Crack(message, sessionID);
            }
            catch (Exception ex)
            {
                logger.Error("toAdmin() Erro: " + ex.Message, ex);
            }
        }

        public void FromApp(QuickFix.Message message, SessionID sessionID)
        {
            logger.Debug("IN:  " + message.ToString());
            try
            {
                Crack(message, sessionID);
            }
            catch (Exception ex)
            {
                logger.Error("==Cracker exception==");
                logger.Error(ex.ToString(), ex);
            }
        }


        public void ToApp(QuickFix.Message message, SessionID sessionID)
        {
            try
            {
                bool possDupFlag = false;
                if (message.Header.IsSetField(QuickFix.Fields.Tags.PossDupFlag))
                {
                    possDupFlag = QuickFix.Fields.Converters.BoolConverter.Convert(
                        message.Header.GetField(QuickFix.Fields.Tags.PossDupFlag)); /// FIXME
                }
                if (possDupFlag)
                    throw new DoNotSend();
            }
            catch (FieldNotFoundException fnfex)
            {
                logger.Error("Erro: " + fnfex.Message, fnfex);

            }
        }
        #endregion


        #region MessageCracker handlers
        public void OnMessage(QuickFix.FIX42.Logon m, SessionID s)
        {
            logger.Info("Logged:" + s.ToString());
        }

        public void OnMessage(QuickFix.FIX42.Logout m, SessionID s)
        {
            logger.Info("Logged out:" + s.ToString());
        }

        public void OnMessage(QuickFix.FIX42.ExecutionReport m, SessionID s)
        {
            /*
            _mainform._addMsg("Received execution report (4.2)\r\n");

            string msg = "Order Dump Begin =======================\r\n";
            msg += "\r\n";

            msg += "OrdemInfo:\r\n";
            msg += "==========\r\n";
            msg += "Account .........: " + m.Account.getValue() + "\r\n";
            msg += "Numero da ordem .: " + m.ClOrdID.getValue() + "\r\n";
            msg += "Symbol ..........: " + m.Symbol.getValue() + "\r\n";
            msg += "ExchangeNumber ..: " + m.OrderID.getValue() + "\r\n";
            msg += "Status ..........: " + m.OrdStatus.getValue() + "\r\n";
            msg += "Status ..........: " + FixMessageUtilities.TraduzirOrdemStatus(m.OrdStatus.getValue()) + "\r\n";
            msg += "Quantidade ......: " + m.OrderQty.getValue() + "\r\n";
            msg += "Qtde restante ...: " + (m.OrderQty.getValue() - m.CumQty.getValue()) + "\r\n";
            if (m.IsSetLastPx())
                msg += "Preco ...........: " + m.LastPx.getValue() + "\r\n";

            if (m.IsSetText())
                msg += "Text ............: [" + m.Text.getValue() + "]\r\n";

            if (m.IsSetField(5149))
            {
                msg += "Memo5149 ........: " + m.GetString(5149) + "\r\n";
            }

            msg += "\r\n";

            msg += "\r\nOrder Dump End =========================\r\n";

            _mainform._addMsg(msg);
            */
        }

        public void OnMessage(QuickFix.FIX42.OrderCancelReject m, SessionID s)
        {
            _mainform._addMsg("Received order cancel reject\r\n");
        }
        #endregion

        #region IBoletadorMembers

        public bool EnviarOrdem(OrdemInfo info) { return false; }
        public bool AlterarOrdem(OrdemInfo info) { return false; }
        public bool CancelarOrdem(OrdemCancelamentoInfo info) { return false; }
        // public bool EnviarOrdemCross(OrdemCrossInfo info) { return false; }

        public bool EnviarOrdem(OrdemInfo ordem, long ini = 0, long fim = 0, int delay = 0, string mnemonic= "", string tag115 ="", string extraTags = "")
        {
            //Cria a mensagem FIX de NewOrderSingle
            QuickFix.FIX42.NewOrderSingle ordersingle = new QuickFix.FIX42.NewOrderSingle();

            ordersingle.Set(new Account(ordem.Account.ToString()));
            if (!string.IsNullOrEmpty(mnemonic))
                ordersingle.SetField(new Account(mnemonic), true);
            if (!string.IsNullOrEmpty(tag115))
                ordersingle.Header.SetField(new OnBehalfOfCompID(tag115));

            ordersingle.Set(new Symbol(ordem.Symbol));
            ordersingle.Set(new ClOrdID(ordem.ClOrdID));

            // Armazena ClOrdID em Memo (5149) para posterior referência nos tratamentos de retornos
            QuickFix.Fields.StringField field5149 = new QuickFix.Fields.StringField(5149, ordem.ClOrdID);
            ordersingle.SetField(field5149);

            //ordersingle.Set(new IDSource());
            if (ordem.Side == OrdemDirecaoEnum.Venda)
                ordersingle.Set(new Side(Side.SELL));
            else
                ordersingle.Set(new Side(Side.BUY));

            TimeInForce tif = FixMessageUtilities.deOrdemValidadeParaTimeInForce(ordem.TimeInForce);
            if (tif != null)
                ordersingle.Set(tif);

            ordersingle.Set(new OrderQty(ordem.OrderQty));

            if (ordem.TimeInForce == OrdemValidadeEnum.ValidoAteDeterminadaData)
            {
                DateTime expiredate = Convert.ToDateTime(ordem.ExpireDate);
                ordersingle.Set(new ExpireDate(expiredate.ToString("yyyyMMdd")));
            }

            OrdType ordType = FixMessageUtilities.deOrdemTipoParaOrdType(ordem.OrdType);
            if (ordType != null)
                ordersingle.Set(ordType);

            // Para versao 4.2, os novos tipos de OrdType a serem enviados (5, A ou B);
            if (!string.IsNullOrEmpty(ordem.Memo5149))
                ordersingle.SetField(new OrdType(Convert.ToChar(ordem.Memo5149)), true);

            // Verifica envio do preco
            switch (ordem.OrdType)
            {

                case OrdemTipoEnum.Limitada:
                case OrdemTipoEnum.MarketWithLeftOverLimit:
                    ordersingle.Set(new Price(Convert.ToDecimal(ordem.Price)));
                    break;
                case OrdemTipoEnum.StopLimitada:
                case OrdemTipoEnum.StopStart:
                    ordersingle.Set(new Price(Convert.ToDecimal(ordem.Price)));
                    ordersingle.Set(new StopPx(Convert.ToDecimal(ordem.StopPrice)));
                    break;
                case OrdemTipoEnum.Mercado:
                case OrdemTipoEnum.OnClose:
                    ordersingle.Set(new Price(Convert.ToDecimal(ordem.Price)));
                    break;
                default:
                    ordersingle.Set(new Price(Convert.ToDecimal(ordem.Price)));
                    break;
            }

            ordersingle.Set(new TransactTime(DateTime.Now));
            ordersingle.Set(new HandlInst('1'));
            
            ordersingle.Set(new ExecBroker("227"));

            if (ordem.MaxFloor > 0)
                ordersingle.Set(new MaxFloor(Convert.ToDecimal(ordem.MaxFloor)));

            if (ordem.MinQty > 0)
                ordersingle.Set(new MinQty(Convert.ToDecimal(ordem.MinQty)));

            // Tags Customizadas Bloomberg
            if (!string.IsNullOrEmpty(extraTags))
            {
                string[] arr = extraTags.Split(';');
                for (int i =0; i < arr.Length; i++)
                {
                    if (!string.IsNullOrEmpty(arr[i]))
                    {
                        string [] valor = arr[i].Split('=');
                        StringField fld = new StringField(Convert.ToInt32(valor[0]), valor[1]);
                        ordersingle.SetField(fld);
                    }
                }
            }

            QuickFix.FIX42.NewOrderSingle.NoAllocsGroup noAllocsGrp = new QuickFix.FIX42.NewOrderSingle.NoAllocsGroup();
            noAllocsGrp.Set(new AllocAccount("67"));
            ordersingle.AddGroup(noAllocsGrp);
            bool bRet  = false;
            if (ini == 0)
                bRet = Session.SendToTarget(ordersingle, _session.SessionID);
            else
            {
                long times = fim - ini;
                logger.Info("=====================================> INICIO ========> Qtd: " + times);
                for (long i = 0; i < times; i++)
                {
                    ClOrdID xx = new ClOrdID(ini.ToString());
                    ordersingle.ClOrdID = xx;
                    bRet = Session.SendToTarget(ordersingle, _session.SessionID);
                    if (!bRet)
                    {
                        logger.Info("erro");
                        break;
                    }
                    if (0 != delay)
                    {
                        Thread.Sleep(delay);
                    }
                    ini++;
                }
                logger.Info("=====================================> FIM ========> Qtd: " + times);
            }
            return bRet;

        }

        public bool AlterarOrdem(OrdemInfo ordem, long ini = 0, long fim = 0, long oriini = 0, long orifim =0, int delay = 0, string mnemonic = "", string tag115 = "", string extraTags="")
        {
            //Cria a mensagem FIX de NewOrderSingle
            QuickFix.FIX42.OrderCancelReplaceRequest ordercrr = new QuickFix.FIX42.OrderCancelReplaceRequest();

            ordercrr.Set(new Account(ordem.Account.ToString()));
            if (!string.IsNullOrEmpty(mnemonic))
                ordercrr.SetField(new Account(mnemonic), true);
            if (!string.IsNullOrEmpty(tag115))
                ordercrr.Header.SetField(new OnBehalfOfCompID(tag115), true);
            ordercrr.Set(new Symbol(ordem.Symbol));
            ordercrr.Set(new ClOrdID(ordem.ClOrdID));
            ordercrr.Set(new OrigClOrdID(ordem.OrigClOrdID));

            if (ordem.ExchangeNumberID != null && ordem.ExchangeNumberID.Length > 0)
                ordercrr.Set(new OrderID(ordem.ExchangeNumberID));

            // Armazena ClOrdID em Memo (5149) para posterior referência nos tratamentos de retornos
            QuickFix.Fields.StringField field5149 = new QuickFix.Fields.StringField(5149, ordem.ClOrdID);
            ordercrr.SetField(field5149);

            //ordersingle.Set(new IDSource());
            if (ordem.Side == OrdemDirecaoEnum.Venda)
                ordercrr.Set(new Side(Side.SELL));
            else
                ordercrr.Set(new Side(Side.BUY));

            TimeInForce tif = FixMessageUtilities.deOrdemValidadeParaTimeInForce(ordem.TimeInForce);
            if (tif != null)
                ordercrr.Set(tif);

            ordercrr.Set(new OrderQty(ordem.OrderQty));

            if (ordem.TimeInForce == OrdemValidadeEnum.ValidoAteDeterminadaData)
            {
                DateTime expiredate = Convert.ToDateTime(ordem.ExpireDate);
                ordercrr.Set(new ExpireDate(expiredate.ToString("yyyyMMdd")));
            }

            OrdType ordType = FixMessageUtilities.deOrdemTipoParaOrdType(ordem.OrdType);
            if (ordType != null)
                ordercrr.Set(ordType);

            // Para versao 4.2, os novos tipos de OrdType a serem enviados (5, A ou B);
            if (!string.IsNullOrEmpty(ordem.Memo5149))
                ordercrr.SetField(new OrdType(Convert.ToChar(ordem.Memo5149)), true);

            // Verifica envio do preco
            switch (ordem.OrdType)
            {

                case OrdemTipoEnum.Limitada:
                case OrdemTipoEnum.MarketWithLeftOverLimit:
                case OrdemTipoEnum.StopLimitada:
                    ordercrr.Set(new Price(Convert.ToDecimal(ordem.Price)));
                    break;
                case OrdemTipoEnum.StopStart:
                    ordercrr.Set(new Price(Convert.ToDecimal(ordem.Price)));
                    ordercrr.Set(new StopPx(Convert.ToDecimal(ordem.StopPrice)));
                    break;
                case OrdemTipoEnum.Mercado:
                case OrdemTipoEnum.OnClose:
                    ordercrr.Set(new Price(Convert.ToDecimal(ordem.Price)));
                    break;
                default:
                    ordercrr.Set(new Price(Convert.ToDecimal(ordem.Price)));
                    break;
            }

            ordercrr.Set(new TransactTime(DateTime.Now));
            ordercrr.Set(new HandlInst('1'));
            ordercrr.Set(new ExecBroker("227"));

            if (ordem.MaxFloor > 0)
                ordercrr.Set(new MaxFloor(Convert.ToDecimal(ordem.MaxFloor)));

            if (ordem.MinQty > 0)
                ordercrr.Set(new MinQty(Convert.ToDecimal(ordem.MinQty)));

            QuickFix.FIX42.OrderCancelReplaceRequest.NoAllocsGroup noAllocsGrp = new QuickFix.FIX42.OrderCancelReplaceRequest.NoAllocsGroup();
            noAllocsGrp.Set(new AllocAccount("67"));
            ordercrr.AddGroup(noAllocsGrp);

            bool bRet = false;
            // Tags Customizadas Bloomberg
            if (!string.IsNullOrEmpty(extraTags))
            {
                string[] arr = extraTags.Split(';');
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!string.IsNullOrEmpty(arr[i]))
                    {
                        string[] valor = arr[i].Split('=');
                        StringField fld = new StringField(Convert.ToInt32(valor[0]), valor[1]);
                        ordercrr.SetField(fld);
                    }
                }
            }

            if (oriini != 0 && orifim != 0)
            {
                long times = fim - ini;
                logger.Info("=====================================> INICIO ALTERAR ORDEM========> Qtd: " + times);
                for (long i = 0; i < times; i++)
                {
                    ClOrdID xx = new ClOrdID(ini.ToString());
                    OrigClOrdID xx2 = new OrigClOrdID(oriini.ToString());
                    ordercrr.ClOrdID = xx;
                    ordercrr.OrigClOrdID = xx2;

                    bRet = Session.SendToTarget(ordercrr, _session.SessionID);
                    if (!bRet)
                    {
                        logger.Info("erro");
                        break;
                    }
                    if (0 != delay)
                        Thread.Sleep(delay);
                    ini++;
                    oriini++;
                }
                logger.Info("=====================================> FIM ALTERAR ORDEM========> Qtd: " + times);
            }
            else
                bRet = Session.SendToTarget(ordercrr, _session.SessionID);

            return bRet;
        }

        public bool CancelarOrdem(OrdemCancelamentoInfo ordem, long ini = 0, long fim = 0, long oriini = 0, long orifim = 0, int delay = 0, string mnemonic = "", string tag115 = "", string extraTags = "")
        {
            //Cria a mensagem FIX de NewOrderSingle
            QuickFix.FIX42.OrderCancelRequest ordercrr = new QuickFix.FIX42.OrderCancelRequest();

            ordercrr.Set(new Account(ordem.Account.ToString()));
            if (!string.IsNullOrEmpty(mnemonic))
                ordercrr.SetField(new Account(mnemonic), true);
            if (!string.IsNullOrEmpty(tag115))
                ordercrr.Header.SetField(new OnBehalfOfCompID(tag115), true);

            ordercrr.Set(new Symbol(ordem.Symbol));
            ordercrr.Set(new ClOrdID(ordem.ClOrdID));
            ordercrr.Set(new OrigClOrdID(ordem.OrigClOrdID));

            // Armazena ClOrdID em Memo (5149) para posterior referência nos tratamentos de retornos
            QuickFix.Fields.StringField field5149 = new QuickFix.Fields.StringField(5149, ordem.ClOrdID);
            ordercrr.SetField(field5149);

            //ordersingle.Set(new IDSource());
            if (ordem.Side == OrdemDirecaoEnum.Venda)
                ordercrr.Set(new Side(Side.SELL));
            else
                ordercrr.Set(new Side(Side.BUY));

            //TimeInForce tif = FixMessageUtilities.deOrdemValidadeParaTimeInForce(ordem.TimeInForce);
            //if (tif != null)
            //    ordercrr.Set(tif);

            ordercrr.Set(new OrderQty(ordem.OrderQty));

            ////if (ordem.TimeInForce == OrdemValidadeEnum.ValidoAteDeterminadaData)
            ////{
            ////    DateTime expiredate = Convert.ToDateTime(ordem.ExpireDate);
            ////    ordercrr.Set(new ExpireDate(expiredate.ToString("yyyyMMdd")));
            ////}

            ////OrdType ordType = FixMessageUtilities.deOrdemTipoParaOrdType(ordem.OrdType);
            ////if (ordType != null)
            ////    ordercrr.Set(ordType);

            // Verifica envio do preco
            //switch (ordem.OrdType)
            //{

            //    case OrdemTipoEnum.Limitada:
            //    case OrdemTipoEnum.MarketWithLeftOverLimit:
            //    case OrdemTipoEnum.StopLimitada:
            //        ordercrr.Set(new Price(Convert.ToDecimal(ordem.Price)));
            //        break;
            //    case OrdemTipoEnum.StopStart:
            //        ordercrr.Set(new Price(Convert.ToDecimal(ordem.Price)));
            //        ordercrr.Set(new StopPx(Convert.ToDecimal(ordem.StopPrice)));
            //        break;
            //    case OrdemTipoEnum.Mercado:
            //    case OrdemTipoEnum.OnClose:
            //        ordercrr.Set(new Price(Convert.ToDecimal(ordem.Price)));
            //        break;
            //    default:
            //        ordercrr.Set(new Price(Convert.ToDecimal(ordem.Price)));
            //        break;
            //}

            ordercrr.Set(new TransactTime(DateTime.Now));
            //ordercrr.Set(new HandlInst('1'));
            //ordercrr.Set(new ExecBroker("227"));

            //if (ordem.MaxFloor > 0)
            //    ordercrr.Set(new MaxFloor(Convert.ToDecimal(ordem.MaxFloor)));

            //if (ordem.MinQty > 0)
            //    ordercrr.Set(new MinQty(Convert.ToDecimal(ordem.MinQty)));

            //QuickFix.FIX42.OrderCancelReplaceRequest.NoAllocsGroup noAllocsGrp = new QuickFix.FIX42.OrderCancelReplaceRequest.NoAllocsGroup();
            //noAllocsGrp.Set(new AllocAccount("67"));
            //ordercrr.AddGroup(noAllocsGrp);
            
            bool bRet = false;
            // Tags Customizadas Bloomberg
            if (!string.IsNullOrEmpty(extraTags))
            {
                string[] arr = extraTags.Split(';');
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!string.IsNullOrEmpty(arr[i]))
                    {
                        string[] valor = arr[i].Split('=');
                        StringField fld = new StringField(Convert.ToInt32(valor[0]), valor[1]);
                        ordercrr.SetField(fld);
                    }
                }
            }
            if (oriini !=0 && orifim !=0)
            {
                long times = fim - ini;
                logger.Info("=====================================> INICIO CANCELAR ORDEM========> Qtd: " + times);
                for (long i = 0; i < times; i++)
                {
                    ClOrdID xx = new ClOrdID(ini.ToString());
                    OrigClOrdID xx2 = new OrigClOrdID(oriini.ToString());
                    ordercrr.ClOrdID = xx;
                    ordercrr.OrigClOrdID = xx2;

                    bRet = Session.SendToTarget(ordercrr, _session.SessionID);
                    if (!bRet)
                    {
                        logger.Info("erro");
                        break;
                    }
                    if (0 != delay)
                        Thread.Sleep(delay);
                    ini++;
                    oriini++;
                }
                logger.Info("=====================================> FIM CANCELAR ORDEM========> Qtd: " + times);
            }
            else
                bRet = Session.SendToTarget(ordercrr, _session.SessionID);

            return bRet;
        }

        public bool EnviarOrdemCross(OrdemCrossInfo crossinfo)
        {
            throw new NotImplementedException("EnviarOrdemCross");
        }

        public bool EnviarResend(int iniSeqNum, int endSeqNum)
        {
            try
            {
                QuickFix.FIX42.ResendRequest rr = new QuickFix.FIX42.ResendRequest();
                rr.Set(new BeginSeqNo(iniSeqNum));
                rr.Set(new EndSeqNo(endSeqNum));

                bool bRet = Session.SendToTarget(rr, _session.SessionID);
                return bRet;
            }
            catch
            {
                return false;
            }

        }

        public bool DummyTest()
        {
            try
            {
                QuickFix.FIX42.NewOrderSingle nos42 = new QuickFix.FIX42.NewOrderSingle();
                nos42.SetField(new Account("319400"));
                nos42.SetField(new OrderQty(1M));
                nos42.SetField(new OrdType('1'));
                nos42.SetField(new ClOrdID(DateTime.Now.ToString("hhMMss")));
                nos42.SetField(new Currency("BRL"));
                nos42.SetField(new SecurityID("B7XL5Q9"));
                nos42.SetField(new HandlInst('1'));
                nos42.SetField(new IDSource("2"));
                nos42.SetField(new Side('1'));
                nos42.SetField(new Symbol("OIBR4F"));
                nos42.SetField(new SecurityExchange("BZ"));
                nos42.SetField(new TimeInForce('1'));
                nos42.SetField(new TransactTime(DateTime.Now));

                bool bRet = Session.SendToTarget(nos42, _session.SessionID);
                return bRet;
            }
            catch 
            {
                return false;
            }

        }

        #endregion
    }
}