using _2_ByteBank.BancoDeDados;
using _2_ByteBank.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2_ByteBank.Funcionarios
{
    /// <summary>
    /// Funcionario do tipo Diretor
    /// </summary>
    public class Diretor : Funcionario, IControleConta, IControleFuncionario, IReuniao
    {
        /// <summary>
        ///Contrutor do Diretor 
        /// </summary>
        /// <param name="cpf">CPF do Diretor</param>
        /// <param name="nome">Nome do Diretor</param>
        /// <param name="senha">Senha de login do Diretor</param>
        public Diretor(string cpf, string nome, string senha)
            : base(cpf, nome, 5000, senha, 0.50)
        {
        }
        /// <summary>
        /// Construtor Default
        /// </summary>
        public Diretor()
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
            OrganizadorFuncionarios.Funcionarios.Sort();
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
        /// Realiza o cadastratamento de um novo cliente no sistema
        /// </summary>
        /// <param name="novoCliente">Novo cliente</param>
        /// <exception cref="NullReferenceException">No parametro: <paramref name="novoCliente"/>, referência não definida</exception>  
        public void CadastrarCliente(Cliente novoCliente)
        {
            if (novoCliente == null)
            {
                throw new NullReferenceException("Referencia não definida para Cliente");
            }

            OrganizadorClientes.Clientes.Add(novoCliente);
        }

        /// <summary>
        /// Realiza o cadastro de uma conta Conrrente no sistema
        /// </summary>
        /// <param name="cliente">Cliente titular da conta</param>
        /// <param name="novaContaCorrente">Nova conta corrente</param>
        /// <exception cref="NullReferenceException">No parametro: <paramref name="cliente"/>, referência não definida</exception>  
        /// <exception cref="NullReferenceException">No parametro: <paramref name="novaContaCorrente"/>, referência não definida</exception>
        public void CadastrarContaCorrente(Cliente cliente, ContaCorrente novaContaCorrente)
        {
            if (cliente == null)
            {
                throw new NullReferenceException("Referencia não definida para cliente");
            }
            if (novaContaCorrente == null)
            {
                throw new NullReferenceException("Referencia não definida para Conta Corrente");
            }

            cliente.contaCorrente = novaContaCorrente;
            OrganizadorClientes.Clientes.Sort();
        }
        /// <summary>
        /// Procura uma conta no sistema
        /// </summary>
        /// <param name="numeroAgenciaProcurado">Numero da agencia procurada</param>
        /// <param name="numeroContaProcurado">Numero da canta procurada</param>
        /// <param name="titularProcurado">Titular da conta procurada</param>
        /// <returns>Retorna uma conta corrente, se encontrado</returns>
        /// <exception cref="ArgumentException">No parametro: <paramref name="numeroAgenciaProcurado"/>, string nula ou vazia</exception>
        /// <exception cref="ArgumentException">No parametro: <paramref name="numeroContaProcurado"/>, string nula ou vazia</exception>
        /// <exception cref="NullReferenceException">No parametro: <paramref name="titularProcurado"/>, Referencia não definida</exception>
        public ContaCorrente ProcurarConta(int numeroAgenciaProcurado, int numeroContaProcurado, Cliente titularProcurado)
        {
            if (numeroAgenciaProcurado <= 0)
            {
                throw new ArgumentException("Numero da agencia não pode ser menor ou igual a 0(zero)", nameof(numeroAgenciaProcurado));
            }
            if (numeroContaProcurado <= 0)
            {
                throw new ArgumentException("Numero da agencia não pode ser menor ou igual a 0(zero)", nameof(numeroContaProcurado));
            }
            if (titularProcurado == null)
            {
                throw new NullReferenceException("Referencia não definida para Cliente Procurado");
            }

            var y = OrganizadorClientes.Clientes.Where(x =>
                                (x.CPF == titularProcurado.CPF) &&
                                (x.contaCorrente.Agencia == numeroAgenciaProcurado) &&
                                (x.contaCorrente.Conta == numeroAgenciaProcurado)
                                ).FirstOrDefault();
            return y.contaCorrente;
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
        /// <summary>
        /// Agenda uma reuniao entre os funcionarios
        /// </summary>
        public void AgendarReuniao()
        {
        }
        /// <summary>
        /// Printa as contas mensais do banco
        /// </summary>
        public void PrintarContasBancarias()
        {
        }

        private static void ValidarFuncionario(Funcionario funcionario)
        {
            if (funcionario == null)
            {
                throw new NullReferenceException("Referencia não definida para funcionario");
            }
        }
    }
}
