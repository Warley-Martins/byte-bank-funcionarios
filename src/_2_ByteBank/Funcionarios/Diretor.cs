using _2_ByteBank.BancoDeDados;
using _2_ByteBank.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2_ByteBank.Funcionarios
{
    public class Diretor : Funcionario, IControleConta, IControleFuncionario, IReuniao, IDadosBancarios
    {
        public Diretor(OrganizadorClientes _organizadorClientes, OrganizadorFuncionarios _organizadorFuncionarios, string cpf, string nome, string senha)
            : this(cpf, nome, senha)
        {
            this.organizadorClientes = _organizadorClientes;
            this.organizadorFuncionarios = _organizadorFuncionarios;
        }
        public Diretor(string cpf, string nome, string senha)
            : base(cpf, nome, 5000, senha, 0.50)
        {
        }
        public Diretor()
        {

        }

        private OrganizadorClientes organizadorClientes = new OrganizadorClientes();
        private OrganizadorFuncionarios organizadorFuncionarios = new OrganizadorFuncionarios();

        public void ContratrarFuncionario(Funcionario FuncionarioContratado)
        {
            if(FuncionarioContratado == null)
            {
                throw new NullReferenceException("Referencia não definida para funcionario");
            }
            organizadorFuncionarios.funcionarios.Add(FuncionarioContratado);
        }
        public void DemitirFuncionario(Funcionario funcionarioDemitido)
        {
            if (funcionarioDemitido == null)
            {
                throw new NullReferenceException("Referencia não definida para funcionario");
            }
            organizadorFuncionarios.funcionarios.Remove(funcionarioDemitido);
        }
        public Funcionario ProcurarFuncionario(string cpfFuncionarioProcurado)
        {
            if (cpfFuncionarioProcurado == null)
            {
                throw new ArgumentException("Referencia não definida para cpf", nameof(cpfFuncionarioProcurado));
            }

            foreach (var funcionario in organizadorFuncionarios.funcionarios)
                if (funcionario.CPF == cpfFuncionarioProcurado)
                    return funcionario;
            return null;
        }
        public void CadastrarCliente(Cliente novoCliente)
        {
            if (novoCliente == null)
            {
                throw new NullReferenceException("Referencia não definida para Cliente");
            }

            organizadorClientes.clientes.Add(novoCliente);
        }
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
            
            foreach (var Titular in organizadorClientes.clientes)
                if (Titular == titularProcurado &&
                    Titular.contaCorrente.Agencia == numeroAgenciaProcurado &&
                        Titular.contaCorrente.Conta == numeroContaProcurado)
                    return Titular.contaCorrente;
            return null;
        }
        public void AgendarReuniao()
        {
        }
        public void PrintarContasBancarias()
        {
        }
    }
}
