using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadersVerseAPI.Domain.Enums
{
    public enum EStatus : byte
    {
        Emprestado = 0,
        Devolvido = 1,
        Atrasado = 2
    }
}
