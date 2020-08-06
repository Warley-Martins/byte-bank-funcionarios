using _2_ByteBank.Excecoes;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace _2_ByteBank
{
    class CaixaEletronico
    {
        public CaixaEletronico()
        {
            contas = new List<ContaCorrente>();
        }

        private List<ContaCorrente> contas;
        public void Cadastrar(Cliente titular, int agencia, int conta, string senha)
        {
            ContaCorrente ContaGenerica = new ContaCorrente(titular, agencia, conta, senha);
            contas.Add(ContaGenerica);
            ContaGenerica.PrintarDados();
        }

        /*   Na junção dos codigos utilizar interface IAutenticar ou ILogar   */
        public ContaCorrente Login(string cpfTestado, string senha)
        {
            foreach (var contacorrente in contas)
                if (contacorrente.Titular.CPF == cpfTestado && contacorrente.Senha == senha)
                    return contacorrente;
            return null;
        } //Organizador

        public void VerSaldo(ContaCorrente usuario)
        {
            Console.WriteLine($"\nConta: {usuario.Agencia} {usuario.Conta}\n" +
                              $"Saldo: R${usuario.Saldo}");
        }

        public void Depositar(ContaCorrente usuario, double valorDeposito)
        {
            usuario.Saldo += valorDeposito;
            Console.WriteLine($"\nConta: {usuario.Agencia} {usuario.Conta}\n" +
                              $"Novo saldo: R${usuario.Saldo}");
        }

        public void Sacar(ContaCorrente usuario, double valorSaque)
        {
            if (valorSaque <= 0)
                throw new ArgumentException("Saque permitido apenas para valores maiores que 0 (zero).", nameof(valorSaque));
            //Lanca Excecao de argumento invalido

            if (usuario.Saldo < valorSaque)
            {
                usuario.ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(usuario.Saldo, valorSaque);
            }

            usuario.Saldo -= valorSaque;
        }

        public ContaCorrente ProcurarDestinatario(int agencia, int conta, string cpfTitularTransferencia)
        {
            foreach (var usuario in contas)
            {
                if (usuario.Agencia == agencia && usuario.Conta == conta && usuario.Titular.CPF == cpfTitularTransferencia)
                {
                    usuario.PrintarDadosTransferencia();
                    return usuario;
                }
            }
            return null;
        }
        public void Transferencia(ContaCorrente origem, ContaCorrente destinatario, double valorTransferencia)
        {
            if (origem.Saldo >= valorTransferencia)
            {
                throw new ArgumentException("Transferencia permitida apenas para valores maiores que 0 (zero).", nameof(valorTransferencia));
                //Lanca Excecao de argumento invalido
            }
            try
            {
                Sacar(origem, valorTransferencia);
            }
            catch (SaldoInsuficienteException e)
            {
                origem.ContadorSaquesNaoPermitidos++;
                throw new Exception("Operação não realizada!", e);
            }

            Sacar(origem, valorTransferencia);
            Depositar(destinatario, valorTransferencia);
            Console.WriteLine($"\nconta: {origem.Agencia} {origem.Conta}\n" +
                              $"Novo saldo: R${origem.Saldo}");
        }
    }
}

