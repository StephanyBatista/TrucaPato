using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrucaPato.Dado.Contexto;
using TrucaPato.Dado.Repositorio;
using TrucaPato.Dominio.Jogo;

namespace TrucaPato.Di
{
    public static class ConfiguracaoDeServicos
    {
        public static void Configurar(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContextoDaAplicacao>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ContextoDaAplicacao>()
                .AddDefaultTokenProviders();

            services.AddScoped(typeof(IPartidaRepositorio), typeof(PartidaRepositorio));
            services.AddScoped(typeof(IGerenciadorDePartida), typeof(GerenciadorDePartida));
        }
    }
}
