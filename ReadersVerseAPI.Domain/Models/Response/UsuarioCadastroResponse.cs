﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadersVerseAPI.Domain.Models.Response
{
    public class UsuarioCadastroResponse
    {
        public bool Sucesso { get; private set; }
        public List<string> Erros { get; private set; }

        public UsuarioCadastroResponse() =>
            Erros = new List<string>();

        public UsuarioCadastroResponse(bool sucesso = true) : this() =>
            Sucesso = sucesso;

        public void AdicionarErro(IEnumerable<string> erros) => 
            Erros.AddRange(erros);

    }
}
