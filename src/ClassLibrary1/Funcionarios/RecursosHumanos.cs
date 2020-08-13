using _2_ByteBank.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2_ByteBank.Funcionarios
{ 
    /// <summary>
    /// Funcionario do Recursos Humanos do banco
    /// </summary>
    public class RecursosHumanos : Funcionario, IControleFuncionario
    {
        /// <summary>
        ///Contrutor do RH 
        /// </summary>
        /// <param name="cpf">CPF do RH</param>
        /// <param name="nome">Nome do RH</param>
        /// <param name="senha">Senha de login do RH</param>
        public RecursosHumanos(string cpf, string nome, string senha) 
            : base(cpf, nome, 3000, senha, 0.12)
        {
        }
        /// <summary>
        /// Controtor default
        /// </summary>
        public RecursosHumanos()
        {

        }

        /// <summary>
        /// Realiza o cadastratamento do funcionario no sistema
        /// </summary>
        /// <param name="funcionarioContratado">Novo funcionario</param>
        /// <exception cref="NullReferenceException">No parametro: <paramref name="funcionarioContratado"/>, referência não definida</exception>  
        public void ContratrarFuncionario(Funcionario funcionarioContratado)
        {
            ValidarFuncionario(funcionarioContratado);
            OrganizadorFuncionarios.Funcionarios.Add(funcionarioContratado);
        }
        /// <summary>
        /// Realiza a exlusão do funcionario no sistema
        /// </summary>
        /// <param name="funcionarioDemitido">Funcionario Demitido</param>
        /// <exception cref="NullReferenceException">No parametro: <paramref name="funcionarioDemitido"/>, referência não definida</exception>  
        public void DemitirFuncionario(Funcionario funcionarioDemitido)
        {
            ValidarFuncionario(funcionarioDemitido);
            OrganizadorFuncionarios.Funcionarios.Remove(funcionarioDemitido);
        }

        /// <summary>
        /// Procura um funcionario no sistema
        /// </summary>
        /// <param name="cpfFuncionarioProcurado">CPF do funcionario procurado</param>
        /// <returns>Retorna o funcionario, se encontrado</returns>
        /// <exception cref="ArgumentException">No parametrp: <paramref name="cpfFuncionarioProcurado"/>, string nula ou vazia</exception>
        public Funcionario ProcurarFuncionario(string cpfFuncionarioProcurado)
        {
            if (String.IsNullOrEmpty(cpfFuncionarioProcurado))
            {
                throw new ArgumentException("Referencia não definida para cpf", nameof(cpfFuncionarioProcurado));
            }

            return OrganizadorFuncionarios.Funcionarios.Where(f =>
                                                        f.CPF.Equals(cpfFuncionarioProcurado)
                                                        ).FirstOrDefault();
        }

        /// <summary>
        /// Dados do funcionario do RH
        /// </summary>
        /// <returns>Retorna uma string com os dados do RH</returns>
        public override string ToString()
        {
            return $"\nNome: {this.Nome}" +
                   $"\nCPF: {this.CPF}";
        }
        /// <summary>
        /// Realiza a compração entre dois objetos de tipo RecursosHumanos
        /// </summary>
        /// <param name="obj">Funcionario do RH a ser comparado</param>
        /// <returns>Retorna o valor logico da comparação</returns>
        public override bool Equals(object obj)
        {
            RecursosHumanos RH = obj as RecursosHumanos;

            if (RH == null)
            {
                return false;
            }

            return this.CPF == RH.CPF;
        }

        private void ValidarFuncionario(Funcionario funcionario)
        {
            if (funcionario == null)
            {
                throw new NullReferenceException("Referencia não definida para funcionario");
            }
        }
    }
}

