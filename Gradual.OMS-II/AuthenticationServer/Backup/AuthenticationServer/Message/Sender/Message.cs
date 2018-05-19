﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AS.Messages
{
    public class Message
    {
        public byte[] MDSSignIn(MDSSignIn _MDSSignIn){
 
            byte[] Header = this.Header("A2");
            byte[] ByteVector = new byte[Header.Length + _MDSSignIn.Message.Length];

            System.Buffer.BlockCopy(Header, 0, ByteVector, 0, Header.Length);
            System.Buffer.BlockCopy(_MDSSignIn.Message, 0, ByteVector, Header.Length, _MDSSignIn.Message.Length);

            return ByteVector;
        }


        private  byte[]  Header(string tpMessage)
        {
            string TpMensagem = GenericMessage.GetPosition(2, tpMessage, ' ');
            string TpBolsa = GenericMessage.GetPosition(2, "", ' ');
            string DataHota = GenericMessage.GetPosition(18, DateTime.Now.ToString(), ' ');
            string CodigoInstrumento = GenericMessage.GetPosition(20, "", ' ');
       
            System.Text.Encoding enc = System.Text.Encoding.ASCII;
            return enc.GetBytes(TpMensagem + TpBolsa + DataHota + CodigoInstrumento);

        }

    }
}
