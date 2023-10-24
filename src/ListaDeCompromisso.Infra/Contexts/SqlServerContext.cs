using ListaDeCompromisso.Domain.Entities;
using ListaDeCompromisso.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ListaDeCompromisso.Infra.Contexts
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Compromisso> Compromisso { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new CompromissoMap());

            #region Criação de Índices no banco de dados

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(u => u.Email).IsUnique();
            });

            #endregion
        }
    }
}