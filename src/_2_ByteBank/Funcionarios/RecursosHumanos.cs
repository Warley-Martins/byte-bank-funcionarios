using _2_ByteBank.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2_ByteBank.Funcionarios
{
    public class RecursosHumanos : Funcionario, IControleFuncionario
    {
        public RecursosHumanos(OrganizadorFuncionarios _organizadorFuncionarios, string cpf, string nome, string senha)
            : this(cpf, nome, senha)
        {
            this.organizadorFuncionarios = _organizadorFuncionarios;
        }
        public RecursosHumanos(string cpf, string nome, string senha) 
            : base(cpf, nome, 3000, senha, 0.12)
        {
        }
        public RecursosHumanos()
        {

        }

        private OrganizadorFuncionarios organizadorFuncionarios = new OrganizadorFuncionarios();
        public void ContratrarFuncionario(Funcionario FuncionarioContratado)
        {
            if (FuncionarioContratado == null)
            {
                throw new NullReferenceException("Referencia não definida para funcionario");
            }
            organizadorFuncionarios.funcionarios.Add(FuncionarioContratado);
        }
        public void DemitirFuncionario(Funcionario funcionarioDemitido)
        {
            if (funcionarioDemitido == null)
            {
                throw new NullReferenceException("Referencia não definida para funcionario");
            }
            organizadorFuncionarios.funcionarios.Remove(funcionarioDemitido);
        }
        public Funcionario ProcurarFuncionario(string cpfFuncionarioProcurado)
        {
            if (cpfFuncionarioProcurado == null)
            {
                throw new ArgumentException("Referencia não definida para cpf", nameof(cpfFuncionarioProcurado));
            }

            foreach (var funcionario in organizadorFuncionarios.funcionarios)
                if (funcionario.CPF == cpfFuncionarioProcurado)
                    return funcionario;
            return null;
        }

    }
}

