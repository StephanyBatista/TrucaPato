using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrucaPato.Dominio.Jogo;
using TrucaPato.Web.Models;

namespace TrucaPato.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IPartidaRepositorio _partidaRepositorio;

        public HomeController(IPartidaRepositorio partidaRepositorio)
        {
            _partidaRepositorio = partidaRepositorio;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Partida()
        {
            return View("Partida", User.Identity.Name);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
