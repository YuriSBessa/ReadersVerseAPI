using Microsoft.EntityFrameworkCore;
using ReadersVerseAPI.Domain.Dtos;
using ReadersVerseAPI.Domain.Entidades;
using ReadersVerseAPI.Domain.Interfaces;
using ReadersVerseAPI.Infra.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadersVerseAPI.Infra.Repositorios
{
    public class CarteiraRepositorio : Repositorio<Carteira>, ICarteiraRepositorio
    {
        public CarteiraRepositorio(MyDbContext context) : base(context)
        {
        }

        public Carteira BuscarCarteiraCompleta(string userId)
        {
            return _dbSet.FirstOrDefault(v => v.UserId == userId);
        }

        public IEnumerable<CarteiraDTO> GetCarteira(string userId)
        {
            return _dbSet.Where(v => v.UserId == userId)
                .Include(v => v.User)
                .Select(x => new CarteiraDTO
                {
                    Username = x.User.UserName,
                    Saldo_Atual = x.Saldo_Atual.ToString("C2")
                });
        }
    }
}
