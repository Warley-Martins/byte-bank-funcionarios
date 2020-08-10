using System;
using System.Collections.Generic;
using System.Text;

namespace _2_ByteBank.Excecoes
{
    class OperacaoFinanceiraException : Exception
    {
        public OperacaoFinanceiraException()
        {

        }
        public OperacaoFinanceiraException(string mensagem)
            : base(mensagem)
        {

        }
        public OperacaoFinanceiraException(string mensagem, Exception innerException)
            : base(mensagem, innerException)
        {

        }
    }
}
