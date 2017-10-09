using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrucaPato.Dado.Contexto;

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
        }
    }
}
