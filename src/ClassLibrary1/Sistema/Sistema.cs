using _2_ByteBank;
using _2_ByteBank.BancoDeDados;
using _2_ByteBank.Funcionarios;
using Dll_Byte_Bank.Excecoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll_Byte_Bank.Sistema
{
    /// <summary>
    /// Classe que intermediaria das operações do banco
    /// </summary>
    public class Sistema
    {
        /// <summary>
        /// Realiza a admissão de um funcionário
        /// </summary>
        /// <param name="funcionarioContratante">Funcionario que realiza o contrato</param>
        /// <param name="funcionarioContratado">Novo funcionario</param>
        /// <exception cref="NullReferenceException">No parametro: <paramref name="funcionarioContratado"/>, referencia não definida </exception>       
        /// <exception cref="NullReferenceException">No parametro: <paramref name="funcionarioContratante"/>, referencia não definida </exception>
        /// <returns>Retorna o resultado da contratação</returns>
        /// <exception cref="FuncionarioInvalidoException">Caso o funcionario não possua acesso para a operação</exception>
        public string AdicionarFuncionario(Funcionario funcionarioContratante, Funcionario funcionarioContratado)
        {
            return OrganizadorFuncionarios.Adicionar(funcionarioContratante, funcionarioContratado);
        }
        /// <summary>
        /// Realiza a admissão de um funcionário
        /// </summary>
        /// <param name="funcionario">Funcionario que realiza a demissão</param>
        /// <param name="funcionarioDemitido">Funcionario Demitido</param>
        /// <exception cref="NullReferenceException">No parametro: <paramref name="funcionario"/>, referencia não definida </exception>       
        /// <exception cref="NullReferenceException">No parametro: <paramref name="funcionarioDemitido"/>, referencia não definida </exception>
        /// <returns>Retorna o resultado da contratação</returns>
        /// <exception cref="FuncionarioInvalidoException">Caso o funcionario não possua acesso para a operação</exception>
        public string RemoverFuncionario(Funcionario funcionario, Funcionario funcionarioDemitido)
        {
            return OrganizadorFuncionarios.Remover(funcionario, funcionarioDemitido);
        }
        /// <summary>
        /// Procura um funcionario no sistema
        /// </summary>
        /// <param name="funcionario">Funcionario que realiza a operação</param>
        /// <param name="cpfFuncionarioProcurado">CPF do funcionario procurado</param>
        /// <returns>Retorna o funcionario, se encontrado</returns>
        /// <exception cref="ArgumentException">No parametrp: <paramref name="cpfFuncionarioProcurado"/>, string nula ou vazia</exception>
        /// <exception cref="FuncionarioInvalidoException">Caso o funcionario não possua acesso para a operação</exception>
        public Funcionario ProcurarFuncionario(Funcionario funcionario, string cpfFuncionarioProcurado)
        {
            return OrganizadorFuncionarios.ProcurarFuncionario(funcionario, cpfFuncionarioProcurado);
        }
        /// <summary>
        /// Realiza o cadastratamento de um novo cliente no sistema
        /// </summary>
        /// <param name="novoCliente">Novo cliente</param>
        /// <param name="funcionario">Funcionario que realiza o cadastro</param>
        /// <exception cref="NullReferenceException">No parametro: <paramref name="novoCliente"/>, referência não definida</exception>  
        /// <exception cref="FuncionarioInvalidoException">Caso o funcionario não possua acesso para a operação</exception>
        public bool AdicionarCliente(Funcionario funcionario, Cliente novoCliente)
        {
            return OrganizadorClientes.CadastrarCliente(funcionario, novoCliente);
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
        public bool CadastrarContaCorrente(Funcionario funcionario, Cliente cliente, ContaCorrente novaContaCorrente)
        {
            return OrganizadorClientes.CadastrarContaCorrente(funcionario, cliente, novaContaCorrente);
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
        public ContaCorrente ProcurarContaCorrente(Funcionario funcionario, int numeroAgenciaProcurado, int numeroContaProcurado, Cliente titularProcurado)
        {
            return OrganizadorClientes.ProcurarConta(funcionario, numeroAgenciaProcurado, numeroContaProcurado, titularProcurado);
        }
    }
}
