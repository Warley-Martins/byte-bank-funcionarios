using System;
using System.Collections.Generic;
using System.Text;

namespace Dll_Byte_Bank.Excecoes
{
    class FuncionarioInvalidoException : Exception
    {

        public FuncionarioInvalidoException()
        {

        }
        public FuncionarioInvalidoException(string mensagem)
            : base(mensagem)
        {

        }
        public FuncionarioInvalidoException(string mensagem, Exception innerException)
            : base(mensagem, innerException)
        {

        }


    }
}
