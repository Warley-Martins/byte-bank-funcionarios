using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace _2_ByteBank 
{ 

    /// <summary>
    ///Cliente do banco ByteBanks
    /// </summary>
    public class Cliente
    {
        /// <summary>
        /// Contrutor default
        /// </summary>
        public Cliente()
        {

        }

        /// <summary>
        /// Construtor do cliente
        /// </summary>
        /// <param name="nome">Nome do cliente</param>
        /// <param name="cpf">CPF do cliente</param>
        /// <exception cref="ArgumentException">O parametro: <paramref name="cpf"/>, não pode ser nulo ou vazio</exception>
        /// <exception cref="ArgumentException">O parametro: <paramref name="nome"/>, não pode ser nulo ou vazio</exception>
        public Cliente(string nome, string cpf)
        {
            if (String.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("O nome não pode ser nulo ou vazio", nameof(nome));
            }
            if (String.IsNullOrEmpty(cpf))
            {
                throw new ArgumentException("O cpf não pode ser nulo ou vazio", nameof(cpf));
            }
            this.Nome = nome;
            this.CPF = cpf;
        }

        /// <summary>
        /// Nome do Clinte
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// CPF do cliente
        /// </summary>
        public string CPF { get; set; }
        /// <summary>
        /// Conta Corrente do cliente
        /// </summary>
        public ContaCorrente contaCorrente = new ContaCorrente();
        /// <summary>
        /// Realiza a comparação entre dois clientes
        /// </summary>
        /// <param name="obj">Recebe um cliente</param>
        /// <returns>Retorna o valor logico da comparação</returns>
        public override bool Equals(object obj)
        {
            Cliente cliente = obj as Cliente;
            if(cliente == null)
            {
                return false;
            }
            return this.CPF == cliente.CPF;
        }
        /// <summary>
        /// Dados do cliente
        /// </summary>
        /// <returns>Retorna uma string com os dados do cliente</returns>
        public override string ToString()
        {
            return $"\nNome: {this.Nome}" +
                   $"\nCPF: {this.CPF}" +
                   $"\nConta bancaria:" +
                   $"\nAgencia {this.contaCorrente.Agencia} Conta {this.contaCorrente.Conta}";
        }

    }
}
