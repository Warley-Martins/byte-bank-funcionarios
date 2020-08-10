using System;
using System.Collections.Generic;
using System.Text;

namespace _2_ByteBank.Interfaces
{
    /// <summary>
    /// Login do cliente do banco
    /// </summary>
    public interface ILogarCliente
    {
        /// <summary>
        /// Realiza a validação do login
        /// </summary>
        /// <param name="cpf">CPF do cliente</param>
        /// <param name="senha">Senha do cliente</param>
        /// <returns></returns>
        Cliente Logar(string cpf, string senha);
    }
}
