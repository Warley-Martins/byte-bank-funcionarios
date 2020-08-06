using _2_ByteBank.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2_ByteBank.Interfaces
{
    public interface IControleFuncionario
    {
        public void ContratrarFuncionario(Funcionario FuncionarioContratado);
        public void DemitirFuncionario(Funcionario funcionarioDemitido);
        public Funcionario ProcurarFuncionario(string cpfFuncionarioProcurado);

    }
}
