using System;
using System.Collections.Generic;
using System.Text;

namespace _2_ByteBank.Interfaces
{
    /// <summary>
    /// Define os metodos basicos para o controle de uma conta bancaria
    /// </summary>
    public interface IControleConta
    {
        /// <summary>
        /// Realiza o cadastratamento de um novo cliente no sistema
        /// </summary>
        /// <param name="novoCliente">Novo cliente</param>
        /// <exception cref="NullReferenceException">No parametro: <paramref name="novoCliente"/>, referência não definida</exception>  
        void CadastrarCliente(Cliente novoCliente);
        /// <summary>
        /// Realiza o cadastro de uma conta Conrrente no sistema
        /// </summary>
        /// <param name="cliente">Cliente titular da conta</param>
        /// <param name="novaContaCorrente">Nova conta corrente</param>
        /// <exception cref="NullReferenceException">No parametro: <paramref name="cliente"/>, referência não definida</exception>  
        /// <exception cref="NullReferenceException">No parametro: <paramref name="novaContaCorrente"/>, referência não definida</exception>
        void CadastrarContaCorrente(Cliente cliente, ContaCorrente novaContaCorrente);
        /// <summary>
        /// Procura uma conta no sistema
        /// </summary>
        /// <param name="numeroAgencia">Numero da agencia procurada</param>
        /// <param name="numeroConta">Numero da canta procurada</param>
        /// <param name="titular">Titular da conta procurada</param>
        /// <returns>Retorna uma conta corrente, se encontrado</returns>
        /// <exception cref="ArgumentException">No parametro: <paramref name="numeroAgencia"/>, string nula ou vazia</exception>
        /// <exception cref="ArgumentException">No parametro: <paramref name="numeroConta"/>, string nula ou vazia</exception>
        /// <exception cref="NullReferenceException">No parametro: <paramref name="titular"/>, Referencia não definida</exception>
        ContaCorrente ProcurarConta(int numeroAgencia, int numeroConta, Cliente titular); 
        
    }
}
