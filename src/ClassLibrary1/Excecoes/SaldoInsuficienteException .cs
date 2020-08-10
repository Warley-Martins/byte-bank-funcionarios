using System;
using System.Collections.Generic;
using System.Text;

namespace _2_ByteBank.Excecoes
{
    public class SaldoInsuficienteException : Exception
    {

        private double ValorSaldo;
        private double ValorSaque;

        public SaldoInsuficienteException()
        {

        }
        public SaldoInsuficienteException(double valorSaldo, double valorSaque)
            : this("O valor R$" + valorSaque + "não pode ser sacado.\nSaldo disponivel: R$"+ valorSaldo)
        {
            this.ValorSaldo = valorSaldo;
            this.ValorSaque = valorSaque;
        }
        public SaldoInsuficienteException(string mensagem, Exception innerException)
            : base(mensagem, innerException)
        {

        }
        public SaldoInsuficienteException(string mensagem)
            : base(mensagem)
        {

        }



    }
}
