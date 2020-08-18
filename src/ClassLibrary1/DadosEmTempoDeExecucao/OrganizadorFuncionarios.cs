using _2_ByteBank.Interfaces;
using Dll_Byte_Bank.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2_ByteBank.Funcionarios
{
    /// <summary>
    /// Salva os dados dos funcionarios da empresa
    /// </summary>
    public static class OrganizadorFuncionarios
    {
        private static List<Funcionario> Funcionarios = new List<Funcionario>()
                                                    {
                                                        new RecursosHumanos("12345678922", "Bruno", "123"),
                                                        new Diretor("12345678911", "Lucas", "123")
                                                    };

        private static bool Logar(Funcionario f)
        {
            var diretor = f as Diretor;
            var rh = f as RecursosHumanos;
            if (diretor == null & rh == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Realiza a admissão de um funcionário
        /// </summary>
        /// <param name="funcionarioContratante">Funcionario que realiza o contrato</param>
        /// <param name="funcionarioContratado">Novo funcionario</param>
        /// <exception cref="NullReferenceException">No parametro: <paramref name="funcionarioContratado"/>, referencia não definida </exception>       
        /// <exception cref="NullReferenceException">No parametro: <paramref name="funcionarioContratante"/>, referencia não definida </exception>
        /// <returns>Retorna o resultado da contratação</returns>
        /// <exception cref="FuncionarioInvalidoException">Caso o funcionario não possua acesso para a operação</exception>
        public static string Adicionar(Funcionario funcionarioContratante, Funcionario funcionarioContratado)
        {
            if(funcionarioContratado == null)
            {
                throw new NullReferenceException("Referencia não definida para o novo funcionario");
            }
            if (funcionarioContratante == null)
            {
                throw new NullReferenceException("Referencia não definida para o funcionario Diretor/RH");
            }
            if (Logar(funcionarioContratante))
            {
                Funcionarios.Add(funcionarioContratado);
                return "Funcionario Adicionado";
            }
            throw new FuncionarioInvalidoException("Login Invalido para operação solicitada");

        }
        /// <summary>
        /// Realiza a admissão de um funcionário
        /// </summary>
        /// <param name="funcionario">Funcionario que realiza a demissão</param>
        /// <param name="funcionarioDemitido">Funcionario Demitido</param>
        /// <exception cref="NullReferenceException">No parametro: <paramref name="funcionario"/>, referencia não definida </exception>       
        /// <exception cref="NullReferenceException">No parametro: <paramref name="funcionarioDemitido"/>, referencia não definida </exception>
        /// <returns>Retorna o resultado da contratação</returns>
        /// <exception cref="FuncionarioInvalidoException">Caso o funcionario não possua acesso para a operação</exception>
        public static string Remover(Funcionario funcionario, Funcionario funcionarioDemitido)
        {
            if (funcionarioDemitido == null)
            {
                throw new NullReferenceException("Referencia não definida para o novo funcionario");
            }
            if (funcionario == null)
            {
                throw new NullReferenceException("Referencia não definida para o funcionario Diretor/RH");
            }
            if (Logar(funcionario))
            {
                Funcionarios.Remove(funcionarioDemitido);
                return "Funcionario Removido Do Sistema";
            }
            throw new FuncionarioInvalidoException("Login Invalido para operação solicitada");

        }
        /// <summary>
        /// Procura um funcionario no sistema
        /// </summary>
        /// <param name="funcionario">Funcionario que realiza a operação</param>
        /// <param name="cpfFuncionarioProcurado">CPF do funcionario procurado</param>
        /// <returns>Retorna o funcionario, se encontrado</returns>
        /// <exception cref="ArgumentException">No parametrp: <paramref name="cpfFuncionarioProcurado"/>, string nula ou vazia</exception>
        /// <exception cref="FuncionarioInvalidoException">Caso o funcionario não possua acesso para a operação</exception>
        public static Funcionario ProcurarFuncionario(Funcionario funcionario, string cpfFuncionarioProcurado)
        {
            if (String.IsNullOrEmpty(cpfFuncionarioProcurado))
            {
                throw new ArgumentException("Referencia não definida para cpf", nameof(cpfFuncionarioProcurado));
            }
            if (funcionario == null)
            {
                throw new NullReferenceException("Referencia não definida para o funcionario");
            }
            if (Logar(funcionario))
            {
                return Funcionarios.Where(f =>
                                          f.CPF.Equals(cpfFuncionarioProcurado)
                                          ).FirstOrDefault();
            }
            throw new FuncionarioInvalidoException("Login Invalido para operação solicitada");

        }
    }
}
