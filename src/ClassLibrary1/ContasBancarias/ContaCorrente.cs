using System;
using System.Collections.Generic;
using System.Text;


namespace _2_ByteBank
{
    /// <summary>
    /// Conta corrente do banco ByteBank
    /// </summary>
    public class ContaCorrente
    {
        /// <summary>
        /// Contrutor default
        /// </summary>
        public ContaCorrente()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="agencia"></param>
        /// <param name="conta"></param>
        /// <param name="senha"></param>
        /// <exception cref="NullReferenceException">No parametro: <paramref name="titular"/>, referência não definida</exception>
        /// <exception cref="ArgumentException">O parametro: <paramref name="agencia"/>, não pode ser menor ou igual a 0(zero)</exception>
        /// <exception cref="ArgumentException">O parametro: <paramref name="conta"/>, não pode ser menor ou igual a 0(zero)</exception>
        /// <exception cref="ArgumentException">O parametro: <paramref name="senha"/>, não pode ser nulo ou vazio</exception>
        public ContaCorrente(int agencia, int conta, string senha)
        {
            if (agencia <= 0)
            {
                throw new ArgumentException("A agencia não pode ser menor ou igual a 0(zero)", nameof(agencia));
            }
            if(conta <= 0)
            {
                throw new ArgumentException("A conta não pode ser menor ou igual a 0(zero)", nameof(conta));
            }
            if (String.IsNullOrEmpty(senha))
            {
                throw new ArgumentException("A senha não pode ser nula ou vazia", nameof(senha));
            }

            this.Senha = senha;
            this.Agencia = agencia;
            this.Conta = conta;
            this.Saldo = 0;
            QuantidadeContas++;
            Taxa = 30.0 / QuantidadeContas;
        }
        /// <summary>
        /// Taxa de operções bancarias
        /// </summary>
        public static double Taxa { get; private set; }
        /// <summary>
        /// Quantidade de contas no banco
        /// </summary>
        public static int QuantidadeContas { get; private set; }

        /// <summary>
        /// Titular da conta corrente
        /// </summary>
        public Cliente Titular { get; set; }
        /// <summary>
        /// Senha da conta corrente
        /// </summary>
        public string Senha { get; set; }
        /// <summary>
        /// Saldo da conta corrente
        /// </summary>
        public double Saldo { get; set; }
        /// <summary>
        /// Numero de agência da conta corrente
        /// </summary>
        public int Agencia { get; set; }
        /// <summary>
        /// Numero da conta
        /// </summary>
        public int Conta { get; set; }
        /// <summary>
        /// Numero de tentativas que o usuario tentou realizar uma operação não permitida
        /// </summary>
        public int ContadorSaquesNaoPermitidos { get; set; }

        /// <summary>
        /// Dados da conta bancaria
        /// </summary>
        /// <returns>Retorna uma string com os dados da conta</returns>
        public override string ToString()
        {
            return $"\nByteBank\n" +
                   $"\nTitular da conta: {Titular.Nome}" +
                   $"\nCpf: {Titular.CPF}" +
                   $"\nAgencia: {Agencia}" +
                   $"\nConta: {Conta}";
        }
        /// <summary>
        /// Compara duas contas correntes
        /// </summary>
        /// <param name="obj">Conta corrente a ser comparada</param>
        /// <returns>Retorna o valor logico da comparação</returns>
        public override bool Equals(object obj)
        {
            ContaCorrente conta = obj as ContaCorrente;

            if(conta == null)
            {
                return false;
            }

            return (this.Agencia == conta.Agencia) &&
                   (this.Conta == conta.Conta);
        }
    }
}
