using System;
using System.Collections.Generic;
using System.Text;

namespace _2_ByteBank.Funcionarios
{
    /// <summary>
    /// Funcionario do banco
    /// </summary>
    public abstract class Funcionario
    {
        /// <summary>
        /// Construtor default
        /// </summary>
        public Funcionario()
        {

        }

        /// <summary>
        /// Construtor padrão dos funcionarios do banco
        /// </summary>
        /// <param name="cpf">CPF do funcionario</param>
        /// <param name="nome">Nome do funcionario</param>
        /// <param name="salario">Salario do funcionario</param>
        /// <param name="senha">Senha do funcionario</param>
        /// <param name="bonusSalarial">Bonus salarial do funcionario</param>
        /// <exception cref="ArgumentException">O parametro: <paramref name="cpf"/>, não pode ser nulo ou vazio</exception>
        /// <exception cref="ArgumentException">O parametro: <paramref name="nome"/>, não pode ser nulo ou vazio</exception>
        /// <exception cref="ArgumentException">O parametro: <paramref name="salario"/>, não pode ser menor ou igual a 0(zero)</exception>
        /// <exception cref="ArgumentException">O parametro: <paramref name="senha"/>, não pode ser nulo ou vazio</exception>
        /// <exception cref="ArgumentException">O parametro: <paramref name="bonusSalarial"/>, não pode ser menor que 0(zero)</exception>
        public Funcionario(string cpf, string nome, double salario, string senha, double bonusSalarial)
        {
            if (String.IsNullOrEmpty(cpf))
            {
                throw new ArgumentException("O CPF não pode ser nulo ou vazio", nameof(cpf));
            }
            if (String.IsNullOrEmpty(nome))
            {
                throw new ArgumentException("O nome não pode ser nulo ou vazio", nameof(nome));
            }
            if (salario <= 0)
            {
                throw new ArgumentException("O salario não pode ser menor ou igual a 0(zero)", nameof(salario));
            }
            if (String.IsNullOrEmpty(senha))
            {
                throw new ArgumentException("A senha não pode ser nula ou vazia", nameof(senha));
            }
            if (bonusSalarial < 0)
            {
                throw new ArgumentException("A bonificação não pode ser menor que 0(zero)", nameof(bonusSalarial));
            }

            TotalFuncionarios++;
            this.Nome = nome;
            this.CPF = cpf;
            this.Salario = salario;
            this._senha = senha;
            this.BonusSalarial = bonusSalarial;
        }
        /// <summary>
        /// Total de funcionarios no banco
        /// </summary>
        public static int TotalFuncionarios { get; private set; }
        /// <summary>
        /// Nome do funcionario
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// CPF do funcionario
        /// </summary>
        public string CPF { get; } // readonly -> somente leitura
        /// <summary>
        /// Salario do funcionario
        /// </summary>
        public double Salario { get; } // readonly -> somente leitura
        /// <summary>
        /// Bonificação do funcionario
        /// </summary>
        public double BonusSalarial { get; } // readonly -> somente leitura

        private string _senha;
        /// <summary>
        /// Senha do funcionario
        /// </summary>
        /// <returns>Retorna a senha do funcionario </returns>
        internal string GetSenha()
        {
            return _senha;
        }
        /// <summary>
        /// Atualiza a senha do funcionario
        /// </summary>
        /// <param name="senhaAtual">Senha atual do funcionario</param>
        /// <param name="novaSenha">Nova senha do funcionario</param>
        /// <returns>Retorna o resultado lógico da operação</returns>
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
