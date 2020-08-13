using _2_ByteBank.BancoDeDados;
using _2_ByteBank.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2_ByteBank.Funcionarios
{
    /// <summary>
    /// Funcionario do tipo GerenteDeConta
    /// </summary>
    public class GerenteDeConta : Funcionario, IControleConta
    {
        /// <summary>
        ///Contrutor do Gerente de Contas
        /// </summary>
        /// <param name="cpf">CPF do Gerente de Contas</param>
        /// <param name="nome">Nome do Gerente de Contas</param>
        /// <param name="senha">Senha de login do Gerente de Contas</param>
        public GerenteDeConta(string cpf, string nome, string senha)
            : base(cpf, nome, 4000, senha, 0.25)
        {
        }
        /// <summary>
        /// Construtor default
        /// </summary>
        public GerenteDeConta()
        {

        }

        /// <summary>
        /// Realiza o cadastratamento de um novo cliente no sistema
        /// </summary>
        /// <param name="novoCliente">Novo cliente</param>
        /// <exception cref="NullReferenceException">No parametro: <paramref name="novoCliente"/>, referência não definida</exception>  
        public void CadastrarCliente(Cliente novoCliente)
        {
            if (novoCliente == null)
            {
                throw new NullReferenceException("Referencia não definida para Cliente");
            }

            OrganizadorClientes.Clientes.Add(novoCliente);
        }

        /// <summary>
        /// Realiza o cadastro de uma conta Conrrente no sistema
        /// </summary>
        /// <param name="cliente">Cliente titular da conta</param>
        /// <param name="novaContaCorrente">Nova conta corrente</param>
        /// <exception cref="NullReferenceException">No parametro: <paramref name="cliente"/>, referência não definida</exception>  
        /// <exception cref="NullReferenceException">No parametro: <paramref name="novaContaCorrente"/>, referência não definida</exception>
        public void CadastrarContaCorrente(Cliente cliente, ContaCorrente novaContaCorrente)
        {
            if (cliente == null)
            {
                throw new NullReferenceException("Referencia não definida para cliente");
            }
            if (novaContaCorrente == null)
            {
                throw new NullReferenceException("Referencia não definida para Conta Corrente");
            }

            cliente.contaCorrente = novaContaCorrente;
        }
        /// <summary>
        /// Procura uma conta no sistema
        /// </summary>
        /// <param name="numeroAgenciaProcurado">Numero da agencia procurada</param>
        /// <param name="numeroContaProcurado">Numero da canta procurada</param>
        /// <param name="titularProcurado">Titular da conta procurada</param>
        /// <returns>Retorna uma conta corrente, se encontrado</returns>
        /// <exception cref="ArgumentException">No parametro: <paramref name="numeroAgenciaProcurado"/>, string nula ou vazia</exception>
        /// <exception cref="ArgumentException">No parametro: <paramref name="numeroContaProcurado"/>, string nula ou vazia</exception>
        /// <exception cref="NullReferenceException">No parametro: <paramref name="titularProcurado"/>, Referencia não definida</exception>
        public ContaCorrente ProcurarConta(int numeroAgenciaProcurado, int numeroContaProcurado, Cliente titularProcurado)
        {
            if (numeroAgenciaProcurado <= 0)
            {
                throw new ArgumentException("Numero da agencia não pode ser menor ou igual a 0(zero)", nameof(numeroAgenciaProcurado));
            }
            if (numeroContaProcurado <= 0)
            {
                throw new ArgumentException("Numero da agencia não pode ser menor ou igual a 0(zero)", nameof(numeroContaProcurado));
            }
            if (titularProcurado == null)
            {
                throw new NullReferenceException("Referencia não definida para Cliente Procurado");
            }

            var y = OrganizadorClientes.Clientes.Where(x =>
                                            (x.CPF == titularProcurado.CPF) && 
                                            (x.contaCorrente.Agencia == numeroAgenciaProcurado) && 
                                            (x.contaCorrente.Conta == numeroAgenciaProcurado)
                                            ).FirstOrDefault();
            return y.contaCorrente;
           
        }

        /// <summary>
        /// Dados do funcionario do RH
        /// </summary>
        /// <returns>Retorna uma string com os dados do RH</returns>
        public override string ToString()
        {
            return $"\nNome: {this.Nome}" +
                   $"\nCPF: {this.CPF}";
        }
        /// <summary>
        /// Realiza a compração entre dois objetos de tipo RecursosHumanos
        /// </summary>
        /// <param name="obj">Funcionario do RH a ser comparado</param>
        /// <returns>Retorna o valor logico da comparação</returns>
        public override bool Equals(object obj)
        {
            RecursosHumanos RH = obj as RecursosHumanos;

            if (RH == null)
            {
                return false;
            }

            return this.CPF == RH.CPF;
        }

    }
}
