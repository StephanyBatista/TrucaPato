using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TrucaPato.Dado.Contexto
{
    public class ContextoDaAplicacao : IdentityDbContext<IdentityUser>
    {
        public ContextoDaAplicacao(DbContextOptions<ContextoDaAplicacao> options) : base(options)
        {
            
        }
    }
}