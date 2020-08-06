using _2_ByteBank.BancoDeDados;
using _2_ByteBank.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2_ByteBank.Funcionarios
{
    public class GerenteDeConta : Funcionario, IControleConta
    {
        public GerenteDeConta(OrganizadorClientes _organizadorClientes, string cpf, string nome, string senha)
            : this(cpf, nome, senha)
        {
            this.organizadorClientes = _organizadorClientes;
        }
        public GerenteDeConta(string cpf, string nome, string senha)
            : base(cpf, nome, 4000, senha, 0.25)
        {
        }
        public GerenteDeConta()
        {

        }

        private OrganizadorClientes organizadorClientes = new OrganizadorClientes();
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

    }
}
