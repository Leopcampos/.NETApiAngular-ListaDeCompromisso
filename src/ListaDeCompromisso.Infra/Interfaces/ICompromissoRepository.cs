using ListaDeCompromisso.Domain.Entities;

namespace ListaDeCompromisso.Infra.Interfaces
{
    public interface ICompromissoRepository : IBaseRepository<Compromisso>
    {
        List<Compromisso> GetByDatas(DateTime dataMin, DateTime dataMax, Guid idUsuario);
    }
}