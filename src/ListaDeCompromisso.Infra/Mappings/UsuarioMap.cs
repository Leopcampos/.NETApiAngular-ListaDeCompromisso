using ListaDeCompromisso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ListaDeCompromisso.Infra.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //definir a chave primária
            builder.HasKey(u => u.IdUsuario);

            //mapear os campos da tabela
            builder.Property(u => u.Nome)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Senha)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.DataCriacao)
                .IsRequired();
        }
    }
}