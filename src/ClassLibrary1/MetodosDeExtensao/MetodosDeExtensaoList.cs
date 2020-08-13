using _2_ByteBank;
using _2_ByteBank.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll_Byte_Bank.MetodosDeExtensao
{
    /// <summary>
    /// 
    /// </summary>
    public static class MetodosDeExtensaoList
    {
        /// <summary>
        /// 
        /// </summary>
        public static void AdicionarVariosFuncionarios(this Funcionario funcionarioContratante, params Funcionario[] novosFuncionarios)
        {
            if (funcionarioContratante == null)
            {
                throw new NullReferenceException("Referencia não definida para o funcionario contratante");
            }
            if (novosFuncionarios == null)
            {
                throw new NullReferenceException("Referencia não definida para o(s) funcionario(s) contratado(s)");
            }

            var diretor = funcionarioContratante as Diretor;
            var RH = funcionarioContratante as RecursosHumanos;

            if (diretor != null)
                foreach (var item in novosFuncionarios)
                {
                    diretor.ContratrarFuncionario(item);
                }
            else if (RH != null)
                foreach (var item in novosFuncionarios)
                {
                    RH.ContratrarFuncionario(item);
                }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="funcionario"></param>
        /// <param name="novosClientes"></param>
        public static void AdicionarVariosClientes(this Funcionario funcionario, params Cliente[] novosClientes)
        {
            if (funcionario == null)
            {
                throw new NullReferenceException("Referencia não definida para o funcionario");
            }
            if (novosClientes == null)
            {
                throw new NullReferenceException("Referencia não definida para o(s) cliente(s) contratado(s)");
            }

            var diretor = funcionario as Diretor;
            var GC = funcionario as GerenteDeConta;

            if (diretor != null)
                foreach (var item in novosClientes)
                {
                    diretor.CadastrarCliente(item);
                }
            else if (GC != null)
                foreach (var item in novosClientes)
                {
                    GC.CadastrarCliente(item);
                }
        }

    }
}
