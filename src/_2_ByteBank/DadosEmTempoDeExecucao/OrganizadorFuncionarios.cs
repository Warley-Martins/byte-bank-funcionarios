using _2_ByteBank.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2_ByteBank.Funcionarios
{
    public class OrganizadorFuncionarios : ILogarFuncionario
    {
        internal List<Funcionario> funcionarios = new List<Funcionario>();

        public OrganizadorFuncionarios()
        {

        }

        public Funcionario Logar(string cpfFuncionarioLogin, string senhaFuncionarioLogin)
        {
            foreach (var funcionario in funcionarios)
                if (funcionario.CPF == cpfFuncionarioLogin && funcionario.GetSenha() == senhaFuncionarioLogin)
                    return funcionario;
            return null;
        }
    }
}
