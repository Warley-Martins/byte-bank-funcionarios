using System;
using System.Collections.Generic;
using System.Text;

namespace Dll_Byte_Bank
{
    /// <summary>
    /// Extrai argumentos de uma url
    /// </summary>
    public class ExtratorArgumentosURL
    {

        /// <summary>
        /// Realiza a extração dos argumentos de uma url
        /// </summary>
        /// <param name="url">URL que sera extraida o argumento</param>
        /// <param name="nomeParametro">Parametro que contem o argumento desejado</param>
        /// <returns>Retorna o argumento procurado</returns>
        public string ExtrairArgumento(string url, string nomeParametro)
        {
            string url2 = url.ToUpper();
            string nomeParametro2 = nomeParametro.ToUpper();
            nomeParametro2 += "=";
            int indiceArgumentos = url2.IndexOf(nomeParametro2);
            int tamanhoParametro = nomeParametro2.Length;
            string res = url.Substring(indiceArgumentos + tamanhoParametro);
            int indiceEComercial = res.IndexOf('&');
            if(indiceEComercial == -1)
            {
                return res;
            }
            return res.Remove(indiceEComercial);
        }
    }
}
