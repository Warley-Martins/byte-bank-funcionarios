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
        /// <param name="telefone">Telefone do cliente</param>
        /// <exception cref="ArgumentException">O parametro: <paramref name="cpf"/>, não pode ser nulo ou vazio</exception>
        /// <exception cref="ArgumentException">O parametro: <paramref name="nome"/>, não pode ser nulo ou vazio</exception>
        /// <exception cref="ArgumentException">O parametro: <paramref name="telefone"/>, não pode ser nulo ou vazio</exception>
        public Cliente(string nome, string cpf, string telefone)
        {
            if (String.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("O nome não pode ser nulo ou vazio", nameof(nome));
            }
            if (String.IsNullOrEmpty(cpf))
            {
                throw new ArgumentException("O cpf não pode ser nulo ou vazio", nameof(cpf));
            }
            if (String.IsNullOrEmpty(telefone))
            {
                throw new ArgumentException("O telefone não pode ser nulo ou vazio", nameof(telefone));
            }
            this.Nome = nome;
            this.CPF = cpf;
            this.Telefone = telefone;
            this.DataInicializacao = DateTime.Now;
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
        /// Telefone celular do cliente
        /// </summary>
        public string Telefone { get; set; }
        /// <summary>
        /// Data na qual o usuario se tornou cliente
        /// </summary>
        public DateTime DataInicializacao;
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
                   $"\nData de Inicialização: {DataInicializacao.ToString()}" +
                   $"\nConta bancaria:" +
                   $"\nAgencia {this.contaCorrente.Agencia} Conta {this.contaCorrente.Conta}";
        }
        /// <summary>
        /// Ordena dois objetos do tipo Cliente
        /// </summary>
        /// <param name="obj">Cliente a ser comparado</param>
        /// <returns>Retorna o valor padrão</returns>
        /// <exception cref="ArgumentException">O parametro: <paramref name="obj"/>, deve ser um Cliente</exception>
        public virtual int CompareTo(object obj)
        {
            Cliente c = obj as Cliente;
            if (c == null)
            {
                throw new NullReferenceException("Referecia não definida com Funcionario");
            }
            if (this.contaCorrente.Agencia > c.contaCorrente.Agencia)
            {
                return 1;
            }
            else if (this.contaCorrente.Agencia < c.contaCorrente.Agencia)
            {
                return -1;
            }
            else
                return 0;
        }
    }
}
