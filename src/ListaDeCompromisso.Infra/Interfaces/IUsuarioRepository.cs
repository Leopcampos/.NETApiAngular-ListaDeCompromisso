using ListaDeCompromisso.Domain.Entities;

namespace ListaDeCompromisso.Infra.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario Get(string email);
        Usuario Get(string email, string senha);
    }
}