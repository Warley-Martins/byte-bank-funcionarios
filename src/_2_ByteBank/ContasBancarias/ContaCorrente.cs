using System;
using System.Collections.Generic;
using System.Text;


namespace _2_ByteBank
{
    public class ContaCorrente
    {
        public ContaCorrente()
        {
        }
        public ContaCorrente(Cliente titular, int agencia, int conta, string senha)
        {

            if (Agencia < 0)
            {
                throw new ArgumentException("A agencia não pode ser negativa", nameof(agencia));
            }
            if(Conta < 0)
            {
                throw new ArgumentException("A conta não pode ser negativa", nameof(conta));
            }

            this.Titular = titular;
            this.Senha = senha;
            this.Agencia = agencia;
            this.Conta = conta;
            this.Saldo = 0;
            QuantidadeContas++;
            Taxa = 30.0 / QuantidadeContas;
        }

        public static double Taxa { get; private set; }
        public static int QuantidadeContas { get; private set; }

        private Cliente _titular = new Cliente();
        public Cliente Titular
        {
            get
            {
                return _titular;
            }
            set
            {
                _titular = value;
            }
        }

        public string Senha { get; set; }
        public double Saldo { get; set; }
        public int Agencia { get; set; }
        public int Conta { get; set; }
        public int ContadorSaquesNaoPermitidos { get; set; }


        Random random = new Random();

        public void PrintarDados()
        {
            Console.WriteLine($"\nByteBank\n" +
                              $"\nTitular da conta: {Titular.Nome}" +
                              $"\nCpf: {Titular.CPF}" +
                              $"\nAgencia: {Agencia}" +
                              $"\nConta: {Conta}" +
                              $"\nSaldo Inicial: {Saldo}");
        }

        public void PrintarDadosTransferencia()
        {
            Console.WriteLine($"\nByteBank" +
                              $"\nTitular da conta: {Titular.Nome}" +
                              $"\nCpf: {Titular.CPF}" +
                              $"\nAgencia: {Agencia}" +
                              $"\nConta: {Conta}");
        }

    }
}
