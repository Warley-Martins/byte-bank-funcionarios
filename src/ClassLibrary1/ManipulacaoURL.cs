using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Dll_Byte_Bank
{
    /// <summary>
    /// Extrai argumentos de uma url
    /// </summary>
    public class ManipulacaoURL
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
            if (indiceEComercial == -1)
            {
                return res;
            }
            return res.Remove(indiceEComercial);
        }

        /// <summary>
        /// Confere o site pertence ao site dominio
        /// </summary>
        /// <param name="urlSite">Url testada</param>
        /// <param name="urlDominio">Url do site dominio</param>
        /// <returns>Retorna o valor logico da comparação</returns>
        /// <exception cref="ArgumentException">O parametro: <paramref name="urlDominio"/> não pode ser nulo ou vazio</exception>
        /// /// <exception cref="ArgumentException">O parametro: <paramref name="urlSite"/> não pode ser nulo ou vazio</exception>
        public bool ConferirDominio(string urlSite, string urlDominio)
        {
            if (String.IsNullOrEmpty(urlSite))
            {
                throw new ArgumentException("A URL do site para busca de dominio não pode ser nula ou vazia!", nameof(urlSite));
            }
            if (String.IsNullOrEmpty(urlDominio))
            {
                throw new ArgumentException("A URL de dominio não pode ser nula ou vazia!", nameof(urlDominio));
            }
            if (urlSite.StartsWith(urlDominio))
                return true;
            return false;
        }

    }
}
