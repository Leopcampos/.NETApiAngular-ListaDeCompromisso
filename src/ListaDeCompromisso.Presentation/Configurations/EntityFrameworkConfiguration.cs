using ListaDeCompromisso.Infra.Contexts;
using ListaDeCompromisso.Infra.Interfaces;
using ListaDeCompromisso.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ListaDeCompromisso.Presentation.Configurations
{
    public static class EntityFrameworkConfiguration
    {
        public static void AddEntityFrameworkConfiguration(this WebApplicationBuilder builder)
        {
            #region Configuração do Contexto do EntityFramework

            builder.Services.AddDbContext<SqlServerContext>(options =>
                           options.UseSqlServer(builder.Configuration.GetConnectionString("Context")));

            #endregion

            #region Configuração das interfaces e classes de repositório

            builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddTransient<ICompromissoRepository, CompromissoRepository>();

            #endregion
        }
    }
}