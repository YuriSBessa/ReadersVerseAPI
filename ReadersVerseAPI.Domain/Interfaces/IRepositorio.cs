using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadersVerseAPI.Domain.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        public void Criar(T entidade);

        public IEnumerable<T> Buscar();

        public T BuscarPorId(int id);

        public void Editar(T entidade);

        public void Deletar(T entidade);
    }
}
