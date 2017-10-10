using Microsoft.AspNetCore.Mvc;
using TrucaPato.Dominio.Jogo.Salas;

namespace TrucaPato.Web.Controllers
{
    [Route("api/[controller]")]
    public class SalaController : Controller
    {
        private readonly ICriadorDeSala _criadorDeSala;

        public SalaController(ICriadorDeSala criadorDeSala)
        {
            _criadorDeSala = criadorDeSala;
        }

        [HttpPost]        
        public void Post()
        {
            _criadorDeSala.Criar(User.Identity.Name);
        }
    }
}