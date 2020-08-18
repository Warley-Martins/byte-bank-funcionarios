using _2_ByteBank.BancoDeDados;
using _2_ByteBank.Funcionarios;
using Dll_Byte_Bank;
using Dll_Byte_Bank.MetodosDeExtensao;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Curso .NET - C# -> Prtojeto Final" +
                              "\nByteBank - Sistema do Funcionário");

            do // Inicio do loop do programa
            {
                Console.WriteLine("\n\tBem Vindo ao ByteBank Sistema do funcionario");
                Diretor usuario;
                do
                {
                    usuario = Logar();  
                } while (usuario != null);
                Console.WriteLine($"Ola {usuario.Nome}");
                int opcaoMenu;
                do
                {
                    PrintarMenu();
                    opcaoMenu = int.Parse(Console.ReadLine());
                } while (opcaoMenu < 0 || opcaoMenu > 6);

                switch (opcaoMenu)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 0:
                        Console.WriteLine("\n\tPrograma Encerrado");
                        break;
                }
                // Cadastrar Funcionario
                // Cadastrar Cliente
            } while (true); // Fim do loop do programa
        }

        private static Diretor Logar()
        {
            Console.Write("\n\tLogin" +
                          "\nDigite seu CPF: ");
            string cpf = Console.ReadLine();
            Console.Write("Digite sua senha : ");
            string senha = Console.ReadLine();
            return new Diretor();
        }

        private static void PrintarMenu()
        {
            Console.Write("Digite a opção desejada" +
                          "\n(1). Cadastro de Cliente" +
                          "\n(2). Cadastro de conta bancária" +
                          "\n(3). Cadastro de funcionário" +
                          "\n(4). " +
                          "\n(5). " +
                          "\n(6). " +
                          "\n(0). " +
                          "Opção:  ");
        }
    }
}