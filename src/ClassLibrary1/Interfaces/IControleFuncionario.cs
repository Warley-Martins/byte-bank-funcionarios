using _2_ByteBank.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2_ByteBank.Interfaces
{
    /// <summary>
    /// Metodos basicos para controle de conta
    /// </summary>
    public interface IControleFuncionario
    {
        /// <summary>
        /// Realiza o cadastratamento do funcionario no sistema
        /// </summary>
        /// <param name="funcionarioContratado">Novo funcionario</param>
        /// <exception cref="NullReferenceException">No parametro: <paramref name="funcionarioContratado"/>, referência não definida</exception>  
        void ContratrarFuncionario(Funcionario funcionarioContratado);
        /// <summary>
        /// Realiza a exlusão do funcionario no sistema
        /// </summary>
        /// <param name="funcionarioDemitido">Funcionario Demitido</param>
        /// <exception cref="NullReferenceException">No parametro: <paramref name="funcionarioDemitido"/>, referência não definida</exception>  
        void DemitirFuncionario(Funcionario funcionarioDemitido);
        /// <summary>
        /// Procura um funcionario no sistema
        /// </summary>
        /// <param name="cpfFuncionarioProcurado">CPF do funcionario procurado</param>
        /// <returns>Retorna o funcionario, se encontrado</returns>
        /// <exception cref="ArgumentException">No parametrp: <paramref name="cpfFuncionarioProcurado"/>, string nula ou vazia</exception>
        Funcionario ProcurarFuncionario(string cpfFuncionarioProcurado);
    }
}
