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
            var d = new Diretor();
            var gc = new Cliente();
            var gc2 = new Cliente();
            d.AdicionarVariosClientes(gc, gc2);


            //Console.WriteLine("\n\tPrograma ainda incompleto" +
            //                  "\n\tCliente + Funcionario");
            //string url = "dnfuasbnuigbuisdbguib?arguMenTo1=olaMundo&Argumento2=oiProgramador";
            //ExtratorArgumentosURL Extrator = new ExtratorArgumentosURL();
            //Console.WriteLine(Extrator.ExtrairArgumento(url, "argumento1"));
            //Console.WriteLine(Extrator.ExtrairArgumento(url, "argumento2"));
        }
    }
}