using Microsoft.AspNetCore.Mvc;
using TrucaPato.Dominio.Jogo;

namespace TrucaPato.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PartidaController : Controller
    {
        private readonly IGerenciadorDePartida _gerenciadorDePartida;

        public PartidaController(IGerenciadorDePartida gerenciadorDePartida)
        {
            _gerenciadorDePartida = gerenciadorDePartida;
        }

        [HttpPost]        
        public void Entrar()
        {
            _gerenciadorDePartida.EntrarEmPartida(User.Identity.Name);
        }
    }
}