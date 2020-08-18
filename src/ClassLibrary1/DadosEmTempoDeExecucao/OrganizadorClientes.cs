using _2_ByteBank.Funcionarios;
using _2_ByteBank.Interfaces;
using Dll_Byte_Bank.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2_ByteBank.BancoDeDados
{
    /// <summary>
    /// 
    /// </summary>
    public static class OrganizadorClientes
    {
        internal static List<Cliente> Clientes = new List<Cliente>()
                                        {
                                            new Cliente("Pedro", "12345678900", "12345678"),
                                            new Cliente("Joao", "78945612300", "12345678")
                                        };


        private static bool Logar(Funcionario f)
        {
            var gerenteDeConta = f as GerenteDeConta;
            var diretor = f as Diretor;
            if (gerenteDeConta == null && diretor == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Realiza o cadastratamento de um novo cliente no sistema
        /// </summary>
        /// <param name="novoCliente">Novo cliente</param>
        /// <param name="funcionario">Funcionario que realiza o cadastro</param>
        /// <exception cref="NullReferenceException">No parametro: <paramref name="novoCliente"/>, referência não definida</exception>  
        /// <exception cref="FuncionarioInvalidoException">Caso o funcionario não possua acesso para a operação</exception>
        public static bool CadastrarCliente(Funcionario funcionario, Cliente novoCliente)
        {
            if (novoCliente == null)
            {
                throw new NullReferenceException("Referencia não definida para Cliente");
            }
            if (funcionario== null)
            {
                throw new NullReferenceException("Referencia não definida para o funcionario Diretor/GerenteDeConta");
            }
            if (Logar(funcionario))
            {
                Clientes.Add(novoCliente);
                return true;
            }
            throw new FuncionarioInvalidoException("Login Invalido para operação solicitada");
        }

        /// <summary>
        /// Realiza o cadastro de uma conta Conrrente no sistema
        /// </summary>
        /// <param name="funcionario">Funcionario que realiza o cadastro</param>
        /// <param name="cpfCliente">CPF do cliente titular da conta</param>
        /// <param name="novaContaCorrente">Nova conta corrente</param>
        /// <exception cref="ArgumentException">O parametro: <paramref name="cpfCliente"/>, não pode ser nulo ou vazio</exception>  
        /// <exception cref="NullReferenceException">No parametro: <paramref name="funcionario"/>, referência não definida</exception>  
        /// <exception cref="NullReferenceException">No parametro: <paramref name="novaContaCorrente"/>, referência não definida</exception>
        /// <exception cref="FuncionarioInvalidoException">Caso o funcionario não possua acesso para a operação</exception>
        public static bool CadastrarContaCorrente(Funcionario funcionario, string cpfCliente, ContaCorrente novaContaCorrente)
        {
            if (String.IsNullOrEmpty(cpfCliente))
            {
                throw new ArgumentException("O cpf do cliente não pode ser nulo ou vazio");
            }
            if (novaContaCorrente == null)
            {
                throw new NullReferenceException("Referencia não definida para Conta Corrente");
            }
            if (funcionario == null)
            {
                throw new NullReferenceException("Referencia não definida para o funcionario Diretor/GerenteDeConta");
            }

            if (Logar(funcionario))
            {
                Cliente cliente = Clientes.Where(x => x.CPF == cpfCliente).FirstOrDefault();
                if(cliente == null)
                {
                    throw new ClienteIndefindoException("Não há cliente com o cpf informado");
                }
                cliente.contaCorrente = novaContaCorrente;
                novaContaCorrente.Titular = cliente;
                return true;
            }
            throw new FuncionarioInvalidoException("Login Invalido para operação solicitada");
        }
        /// <summary>
        /// Procura uma conta no sistema
        /// </summary>
        /// <param name="funcionario">Funcionario que realiza o cadastro</param>
        /// <param name="numeroAgenciaProcurado">Numero da agencia procurada</param>
        /// <param name="numeroContaProcurado">Numero da canta procurada</param>
        /// <param name="cpfTitularProcurado">CPF do titular da conta procurada</param>
        /// <returns>Retorna uma conta corrente, se encontrado</returns>
        /// <exception cref="ArgumentException">No parametro: <paramref name="numeroAgenciaProcurado"/>, string nula ou vazia</exception>
        /// <exception cref="ArgumentException">No parametro: <paramref name="numeroContaProcurado"/>, string nula ou vazia</exception>
        /// <exception cref="NullReferenceException">No parametro: <paramref name="funcionario"/>, referência não definida</exception>  
        /// <exception cref="ArgumentException">O parametro: <paramref name="cpfTitularProcurado"/>, nãopode ser nulo ou vazio</exception>
        /// <exception cref="FuncionarioInvalidoException">Caso o funcionario não possua acesso para a operação</exception>
        public static ContaCorrente ProcurarConta(Funcionario funcionario, int numeroAgenciaProcurado, int numeroContaProcurado, string cpfTitularProcurado)
        {
            if (numeroAgenciaProcurado <= 0)
            {
                throw new ArgumentException("Numero da agencia não pode ser menor ou igual a 0(zero)", nameof(numeroAgenciaProcurado));
            }
            if (numeroContaProcurado <= 0)
            {
                throw new ArgumentException("Numero da agencia não pode ser menor ou igual a 0(zero)", nameof(numeroContaProcurado));
            }
            if (String.IsNullOrEmpty(cpfTitularProcurado))
            {
                throw new ArgumentException("O cpf nao pode ser nulo ou vazio");
            }
            if (funcionario == null)
            {
                throw new NullReferenceException("Referencia não definida para o funcionario Diretor/GerenteDeConta");
            }
            if (Logar(funcionario))
            {
                var y = Clientes.Where(x =>
                                      (x.CPF == cpfTitularProcurado) &&
                                      (x.contaCorrente.Agencia == numeroAgenciaProcurado) &&
                                      (x.contaCorrente.Conta == numeroAgenciaProcurado)
                                      ).FirstOrDefault();
                return y.contaCorrente;
            }
            throw new FuncionarioInvalidoException("Login Invalido para operação solicitada");
        }
    }
}
