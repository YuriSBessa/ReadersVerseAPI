using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReadersVerseAPI.Domain.Models.Response
{
    public class UsuarioLoginResponse
    {
        public bool Sucesso { get; private set; }

        public string? Token { get; set; }

        public List<string> Erros { get; private set; }

        public UsuarioLoginResponse() => 
            Erros = new List<string>();
        public UsuarioLoginResponse(bool sucesso = true) : this() =>
            Sucesso = sucesso;

        public UsuarioLoginResponse(bool sucesso, string? token)
        {
            this.Sucesso = sucesso;
            this.Token = token;
        }

        public void AdicionarErro(string erro) =>
            this.Erros.Add(erro);

        public void AdicionarErro(IEnumerable<string> erros) =>
            Erros.AddRange(erros);
    }
}
