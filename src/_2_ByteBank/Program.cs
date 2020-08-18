using _2_ByteBank.BancoDeDados;
using _2_ByteBank.Funcionarios;
using Dll_Byte_Bank;
using Dll_Byte_Bank.MetodosDeExtensao;
using Dll_Byte_Bank.Sistema;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_ByteBank
{
    class Program
    {
        static Sistema sistema;
        static void Main(string[] args)
        {
            sistema = new Sistema();
            Console.WriteLine("Curso .NET - C# -> Prtojeto Final" +
                              "\nByteBank - Sistema do Funcionário");

            do // Inicio do loop do programa
            {
                Console.WriteLine("\n\tBem Vindo ao ByteBank Sistema do funcionario");
                Funcionario usuario;
                do
                {
                    usuario = Logar();
                } while (usuario == null);
                Console.WriteLine($"Ola {usuario.Nome}");
                int opcaoMenu;
                do
                {
                    PrintarMenu();
                    opcaoMenu = int.Parse(Console.ReadLine());
                } while (opcaoMenu < 0 || opcaoMenu > 6);

                switch (opcaoMenu)
                {
                    case 1: // Cadastro de Cliente
                        CadastrarCliente(usuario);
                        break;
                    case 2: // Cadastro de conta bancária
                        CadastroContaBancaria(usuario);
                        break;
                    case 3: // Procurar uma conta
                        ProcurarContaCorrente(usuario);
                        break;
                    case 4: // Cadastro de funcionário
                        CadastrarFuncionario(usuario);
                        break;
                    case 5: // Demissão de funcionario
                        DemitirFuncionario(usuario);
                        break;
                    case 6: // Procurar um funcionario
                        ProcurarFuncionario(usuario);
                        break;
                    case 0:
                        Console.WriteLine("\n\tPrograma Encerrado");
                        return;
                }
                // Cadastrar Funcionario
                // Cadastrar Cliente
            } while (true); // Fim do loop do programa
        }

        private static Funcionario Logar()
        {
            Console.Write("\n\tLogin" +
                          "\nDigite seu CPF: ");
            string cpf = Console.ReadLine();
            Console.Write("Digite sua senha : ");
            string senha = Console.ReadLine();
            return sistema.Logar(cpf, senha);
        }
        private static void PrintarMenu()
        {
            Console.Write("Digite a opção desejada" +
                          "\n(1). Cadastro de Cliente" +
                          "\n(2). Cadastro de conta bancária" +
                          "\n(3). Procurar uma conta" +
                          "\n(4). Cadastro de funcionário" +
                          "\n(5). Demissão de funcionario" +
                          "\n(6). Procurar um funcionario" +
                          "\n(0). Encerrar" +
                          "Opção:  ");
        }
        private static void CadastrarCliente(Funcionario usuario)
        {
            Console.Write("\nCadastro de cliente" +
                          "\nDigite o nome do cliente: ");
            var nome = Console.ReadLine();
            Console.Write("Digite o cpf: ");
            var cpf = Console.ReadLine();
            Console.Write("Digite o telefone: ");
            var telefone = Console.ReadLine();
            sistema.AdicionarCliente(usuario, new Cliente(nome, cpf, telefone));
        }
        private static bool CadastroContaBancaria(Funcionario usuario)
        {
            Console.Write("\nCadastro da Conta Corrente" +
                          "\nDigite a agencia: ");
            var agencia = int.Parse(Console.ReadLine());
            Random random = new Random();
            int numeroConta = random.Next(1000, 9999);
            Console.Write("Digite a senha: ");
            string senha = Console.ReadLine();
            Console.Write("Digite o cpf do titular da conta: ");
            var cpf = Console.ReadLine();
            return sistema.CadastrarContaCorrente(usuario, cpf, new ContaCorrente(agencia, numeroConta, senha));
        }
        private static ContaCorrente ProcurarContaCorrente(Funcionario usuario)
        {
            Console.Write("Digite o numero da agencia: ");
            var agencia = int.Parse(Console.ReadLine());
            Console.Write("Digite o numero da conta: ");
            var conta = int.Parse(Console.ReadLine());
            Console.Write("Digite o cpf do cliente: ");
            var cpf = Console.ReadLine();
            return sistema.ProcurarContaCorrente(usuario, agencia, conta, cpf);
        }
        private static string CadastrarFuncionario(Funcionario usuario)
        {
            int opcaoCargo;
            do
            {
                Console.Write("\nDigite o numero do cargo: " +
                              "\n(1). Diretor" +
                              "\n(2). Gerente de contas" +
                              "\n(3). Recursos humanos");
                opcaoCargo = int.Parse(Console.ReadLine());
            } while (opcaoCargo < 1 || opcaoCargo > 3);
            Console.Write("Digite o cpf do funcionario");
            var cpf = Console.ReadLine();
            Console.Write("Digite o nome do funcionario");
            var nome = Console.ReadLine();
            Console.Write("Digite a senha do funcionario");
            var senha = Console.ReadLine();
            switch (opcaoCargo)
            {
                case 1:
                    var novoFuncionarioD = new Diretor(cpf, nome, senha);
                    return sistema.AdicionarFuncionario(usuario, novoFuncionarioD);
                case 2:
                    var novoFuncionarioGC = new GerenteDeConta(cpf, nome, senha);
                    return sistema.AdicionarFuncionario(usuario, novoFuncionarioGC);
                case 3:
                    var novoFuncionarioRH = new RecursosHumanos(cpf, nome, senha);
                    return sistema.AdicionarFuncionario(usuario, novoFuncionarioRH);
            }

            return "";
        }
        private static string DemitirFuncionario(Funcionario usuario)
        {
            Console.Write("Digite o cpf do funcionario: ");
            var cpf = Console.ReadLine();
            return sistema.RemoverFuncionario(usuario, cpf);
        }
        private static Funcionario ProcurarFuncionario(Funcionario usuario)
        {
            Console.Write("Digite o cpf do funcionario: ");
            var cpf = Console.ReadLine();
            return sistema.ProcurarFuncionario(usuario, cpf);
        }
    }
}