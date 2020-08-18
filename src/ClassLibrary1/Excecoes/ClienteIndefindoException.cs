using System;
using System.Collections.Generic;
using System.Text;

namespace Dll_Byte_Bank.Excecoes
{
    class ClienteIndefindoException : Exception
    {

        public ClienteIndefindoException()
        {

        }
        public ClienteIndefindoException(string mensagem)
            : base(mensagem)
        {

        }
        public ClienteIndefindoException(string mensagem, Exception innerException)
            : base(mensagem, innerException)
        {

        }

    }
}
