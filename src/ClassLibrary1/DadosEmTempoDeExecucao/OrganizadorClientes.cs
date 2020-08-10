using _2_ByteBank.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2_ByteBank.BancoDeDados
{
    /// <summary>
    /// 
    /// </summary>
    public static class OrganizadorClientes 
    {
        internal static  List<Cliente> clientes = new List<Cliente>();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cpfClienteLogin"></param>
        /// <param name="senhaContaCorrente"></param>
        /// <returns></returns>
        public static Cliente Logar(string cpfClienteLogin, string senhaContaCorrente)
        {
            foreach (var cliente in clientes)
                if (cliente.CPF == cpfClienteLogin && cliente.contaCorrente.Senha == senhaContaCorrente)
                    return cliente;
            return null;
        }
    }
}
