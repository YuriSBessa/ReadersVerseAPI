using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadersVerseAPI.Domain.Enums
{
    public enum EFiltro : byte
    {
        [Description("Título")]
        Titulo = 0,

        [Description("Autor")]
        Autor = 1,

        [Description("Gênero")]
        Genero = 2,

        [Description("Editora")]
        Editora = 3,
    }
}
