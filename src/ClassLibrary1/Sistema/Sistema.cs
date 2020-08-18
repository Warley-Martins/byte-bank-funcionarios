using _2_ByteBank;
using _2_ByteBank.BancoDeDados;
using _2_ByteBank.Funcionarios;
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
        public string AdicionarFuncionario(Funcionario funcionarioContratante, Funcionario funcionarioContratado)
        {
            return OrganizadorFuncionarios.Adicionar(funcionarioContratante, funcionarioContratado);
        }
        public string RemoverFuncionario(Funcionario funcionario, Funcionario funcionarioDemitido)
        {
            return OrganizadorFuncionarios.Remover(funcionario, funcionarioDemitido);
        }
        public Funcionario ProcurarFuncionario(Funcionario funcionario, string cpfFuncionarioProcurado)
        {
            return OrganizadorFuncionarios.ProcurarFuncionario(funcionario, cpfFuncionarioProcurado);
        }
        public bool AdicionarCliente(Funcionario funcionario, Cliente novoCliente)
        {
            return OrganizadorClientes.CadastrarCliente(funcionario, novoCliente);
        }
        public bool CadastrarContaCorrente(Funcionario funcionario, Cliente cliente, ContaCorrente novaContaCorrente)
        {
            return OrganizadorClientes.CadastrarContaCorrente(funcionario, cliente, novaContaCorrente);
        }
        public ContaCorrente ProcurarContaCorrente(Funcionario funcionario, int numeroAgenciaProcurado, int numeroContaProcurado, Cliente titularProcurado)
        {
            return OrganizadorClientes.ProcurarConta(funcionario, numeroAgenciaProcurado, numeroContaProcurado, titularProcurado);
        }
    }
}
