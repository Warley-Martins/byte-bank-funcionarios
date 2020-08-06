using System;
using System.Collections.Generic;
using System.Text;

namespace _2_ByteBank.Interfaces
{
    public interface ILogarCliente
    {
        Cliente Logar(string cpf, string senha);
    }
}
