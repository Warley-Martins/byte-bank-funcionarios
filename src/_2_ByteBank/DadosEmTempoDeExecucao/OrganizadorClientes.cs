using _2_ByteBank.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2_ByteBank.BancoDeDados
{
    public class OrganizadorClientes : ILogarCliente
    {
        internal List<Cliente> clientes = new List<Cliente>();

        public OrganizadorClientes()
        {

        }
        
        public Cliente Logar(string cpfClienteLogin, string senhaContaCorrente)
        {
            foreach (var cliente in clientes)
                if (cliente.CPF == cpfClienteLogin && cliente.contaCorrente.Senha == senhaContaCorrente)
                    return cliente;
            return null;
        }
    }
}
