using System;
using System.Collections.Generic;
using System.Text;

namespace _2_ByteBank.Funcionarios
{
    public abstract class Funcionario
    {
        public Funcionario()
        {

        }
        public Funcionario(string cpf, string nome, double salario, string senha, double bonusSalarial)
        {
            TotalFuncionarios++;
            this.Nome = nome;
            this.CPF = cpf;
            this.Salario = salario;
            this._senha = senha;
            this.BonusSalarial = bonusSalarial;
        }
        public static int TotalFuncionarios { get; private set; }
        public string Nome { get; set; }
        public string CPF { get; } // readonly -> somente leitura
        public double Salario { get; } // readonly -> somente leitura
        public double BonusSalarial { get; } // readonly -> somente leitura

        private string _senha;
        public string GetSenha()
        {
            return _senha;
        }
        public bool SetSenha(string senhaAtual, string novaSenha)
        {
            if (senhaAtual == _senha)
            {
                _senha = novaSenha;
                return true;
            }
            else
                return false;

        }
    }
}
