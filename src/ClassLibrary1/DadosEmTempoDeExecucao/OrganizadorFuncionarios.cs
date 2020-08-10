using _2_ByteBank.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2_ByteBank.Funcionarios
{
    /// <summary>
    /// Salva os dados dos funcionarios da empresa
    /// </summary>
    public static class OrganizadorFuncionarios
    {
        internal static List<Funcionario> funcionarios = new List<Funcionario>();
        //private static bool Logar(Funcionario funcionario)
        //{
        //    Diretor diretor = funcionario as Diretor;
        //    RecursosHumanos RH = funcionario as RecursosHumanos;
        //    if (diretor != null)
        //    {
        //        foreach (var elemento in funcionarios)
        //            if (elemento.CPF == funcionario.CPF && elemento.GetSenha() == funcionario.GetSenha())
        //                return true;
        //    }
        //    else if (RH != null)
        //    {
        //        foreach (var elemento in funcionarios)
        //            if (elemento.CPF == funcionario.CPF && elemento.GetSenha() == funcionario.GetSenha())
        //                return true;
        //    }
        //    return false;
        //}

        ///// <summary>
        ///// Adiciona um funcionario à empresa
        ///// </summary>
        ///// <param name="funcionarioContratando">Autor da contratação</param>
        ///// <param name="funcionarioContratado">Novo funcionario</param>
        ///// <exception cref="NullReferenceException">No parametro: <paramref name="funcionarioContratado"/>, Referencia nula</exception>
        ///// <exception cref="NullReferenceException">No parametro: <paramref name="funcionarioContratando"/>, Referencia nula</exception>
        //public static void AdicionarFuncionario(Funcionario funcionarioContratando, Funcionario funcionarioContratado)
        //{
        //    if (funcionarioContratado == null)
        //    {
        //        throw new NullReferenceException("Referência não definida para o novo funcionario");
        //    }
        //    if (funcionarioContratando == null)
        //    {
        //        throw new NullReferenceException("Referência não definida para o funcionario contratante");
        //    }

        //    if (Logar(funcionarioContratando) == true)
        //    {
        //        Diretor novo = funcionarioContratado as Diretor;
        //        RecursosHumanos novoRH = funcionarioContratado as RecursosHumanos;
        //        GerenteDeConta novoGC = funcionarioContratado as GerenteDeConta;
        //        if (novo != null)
        //            funcionarios.Add(novo);
        //        else if (novoRH != null)
        //            funcionarios.Add(novoRH);
        //        else if (novoGC != null)
        //            funcionarios.Add(novoGC);
        //        Console.WriteLine("\nNovo funcionario cadastrado no sistema");
        //        return;
        //    }
        //    Console.WriteLine("\nAcesso Negado");
        //}
    }
}
