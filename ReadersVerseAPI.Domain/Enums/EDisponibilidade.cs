using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadersVerseAPI.Domain.Enums
{
    public enum EDisponibilidade : byte
    {
        [Description("Disponível")]
        Disponivel = 0,

        [Description("Não Disponível")]
        NaoDisponivel = 1
    }
}
