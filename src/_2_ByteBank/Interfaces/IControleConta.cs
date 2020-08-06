using System;
using System.Collections.Generic;
using System.Text;

namespace _2_ByteBank.Interfaces
{
    public interface IControleConta
    {

        public void CadastrarCliente(Cliente novoCliente);
        public void CadastrarContaCorrente(Cliente cliente, ContaCorrente novaContaCorrente);
        public ContaCorrente ProcurarConta(int numeroAgencia, int numeroConta, Cliente titular); 
        
    }
}
