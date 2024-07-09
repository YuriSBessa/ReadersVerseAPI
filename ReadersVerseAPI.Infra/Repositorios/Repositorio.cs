using Microsoft.EntityFrameworkCore;
using ReadersVerseAPI.Domain.Interfaces;
using ReadersVerseAPI.Infra.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadersVerseAPI.Infra.Repositorios
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        protected readonly MyDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repositorio(MyDbContext context)
        {
            this._context = context;
            _dbSet = _context.Set<T>();
        }
        public IEnumerable<T> Buscar()
        {
            return _dbSet.ToList();
        }

        public T BuscarPorId(int id)
        {
            return _dbSet.Find(id);
        }

        public void Criar(T entidade)
        {
            _dbSet.Add(entidade);
            _context.SaveChanges();
        }

        public void Deletar(T entidade)
        {
            _dbSet.Remove(entidade);
            _context.SaveChanges();
        }

        public void Editar(T entidade)
        {
            _dbSet.Update(entidade);
            _context.SaveChanges();
        }
    }
}
