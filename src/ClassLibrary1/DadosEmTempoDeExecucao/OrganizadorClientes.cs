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
        private static List<Cliente> Clientes = new List<Cliente>()
                                        {
                                            new Cliente("Pedro", "12345678900"),
                                            new Cliente("Joao", "78945612300")
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
        /// <param name="cliente">Cliente titular da conta</param>
        /// <param name="novaContaCorrente">Nova conta corrente</param>
        /// <exception cref="NullReferenceException">No parametro: <paramref name="cliente"/>, referência não definida</exception>  
        /// <exception cref="NullReferenceException">No parametro: <paramref name="funcionario"/>, referência não definida</exception>  
        /// <exception cref="NullReferenceException">No parametro: <paramref name="novaContaCorrente"/>, referência não definida</exception>
        /// <exception cref="FuncionarioInvalidoException">Caso o funcionario não possua acesso para a operação</exception>
        public static bool CadastrarContaCorrente(Funcionario funcionario, Cliente cliente, ContaCorrente novaContaCorrente)
        {
            if (cliente == null)
            {
                throw new NullReferenceException("Referencia não definida para cliente");
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
                cliente.contaCorrente = novaContaCorrente;
                OrganizadorClientes.Clientes.Sort();
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
        /// <param name="titularProcurado">Titular da conta procurada</param>
        /// <returns>Retorna uma conta corrente, se encontrado</returns>
        /// <exception cref="ArgumentException">No parametro: <paramref name="numeroAgenciaProcurado"/>, string nula ou vazia</exception>
        /// <exception cref="ArgumentException">No parametro: <paramref name="numeroContaProcurado"/>, string nula ou vazia</exception>
        /// <exception cref="NullReferenceException">No parametro: <paramref name="funcionario"/>, referência não definida</exception>  
        /// <exception cref="NullReferenceException">No parametro: <paramref name="titularProcurado"/>, Referencia não definida</exception>
        /// <exception cref="FuncionarioInvalidoException">Caso o funcionario não possua acesso para a operação</exception>
        public static ContaCorrente ProcurarConta(Funcionario funcionario, int numeroAgenciaProcurado, int numeroContaProcurado, Cliente titularProcurado)
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
            if (funcionario == null)
            {
                throw new NullReferenceException("Referencia não definida para o funcionario Diretor/GerenteDeConta");
            }
            if (Logar(funcionario))
            {
                var y = Clientes.Where(x =>
                                      (x.CPF == titularProcurado.CPF) &&
                                      (x.contaCorrente.Agencia == numeroAgenciaProcurado) &&
                                      (x.contaCorrente.Conta == numeroAgenciaProcurado)
                                      ).FirstOrDefault();
                return y.contaCorrente;
            }
            throw new FuncionarioInvalidoException("Login Invalido para operação solicitada");
        }
    }
}
