using System;
using System.Collections.Generic;
using System.Text;

namespace _2_ByteBank
{
    /// <summary>
    /// Organiza o salario dos funcionarios
    /// </summary>
    public class OrganizadorBonificacao
    {

        private double Bonificacao;

        /// <summary>
        /// Construtor default
        /// </summary>
        public OrganizadorBonificacao()
        {

        }

        /// <summary>
        /// Atribuição ao montante de bonificações
        /// </summary>
        /// <param name="bonificacao">Bonificação de um funcionario</param>
        public void SetBonificacao(double bonificacao)
        {
            this.Bonificacao += bonificacao;
        }

        /// <summary>
        /// Valor da bonificações
        /// </summary>
        /// <returns>Retorna o montante destinado a bonificação</returns>
        public double GetBonificacao()
        {
            return Bonificacao;
        }


    }
}
