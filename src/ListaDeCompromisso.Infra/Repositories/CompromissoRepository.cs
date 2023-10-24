using ListaDeCompromisso.Domain.Entities;
using ListaDeCompromisso.Infra.Contexts;
using ListaDeCompromisso.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ListaDeCompromisso.Infra.Repositories
{
    public class CompromissoRepository : BaseRepository<Compromisso>, ICompromissoRepository
    {
        private readonly SqlServerContext _context;

        public CompromissoRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        public List<Compromisso> GetByDatas(DateTime dataMin, DateTime dataMax, Guid idUsuario)
        {
            return _context.Compromisso
                .Include(c => c.Usuario)
                .Where(c => c.Data >= dataMin && c.Data <= dataMax && c.IdUsuario == idUsuario)
                .OrderBy(c => c.Data)
                .ToList();
        }
    }
}