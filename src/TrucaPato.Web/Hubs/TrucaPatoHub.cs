using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using StackExchange.Redis;
using TrucaPato.Dominio.Jogo;
using TrucaPato.Web.Models;

namespace TrucaPato.Web.Hubs
{
    public class TrucaPatoHub : Hub
    {
        private readonly IPartidaRepositorio _partidaRepositorio;
        private readonly IGerenciadorDePartida _gerenciadorDePartida;

        public TrucaPatoHub(IPartidaRepositorio partidaRepositorio, IGerenciadorDePartida gerenciadorDePartida)
        {
            _partidaRepositorio = partidaRepositorio;
            _gerenciadorDePartida = gerenciadorDePartida;
        }
        
        public async Task EntrarNaPartida(string nomeDoUsuario)
        {
            GerenteDeConexaoDeHub.Adicionar(nomeDoUsuario, Context.ConnectionId);
            
            var partida = _partidaRepositorio.ObterPorNomeDoJogador(nomeDoUsuario);
            await Groups.AddAsync(Context.ConnectionId, partida.Id.ToString());
            await Clients.Group(partida.Id.ToString()).InvokeAsync("JogadoresDaPartida", partida.Jogadores);

            if (partida.PodeIniciarPartida())
            {
                partida.IniciarPartida();
                partida.IniciarRodada();

                foreach (var cartasDoJogador in partida.AtualCartasDosJogadores)
                {
                    await Clients
                        .Client(GerenteDeConexaoDeHub.ObterConexaoDoUsuario(cartasDoJogador.NomeDoJogador))
                        .InvokeAsync("MinhasCartas", cartasDoJogador.Cartas);
                }
            }
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            //var partida = _partidaRepositorio.ObterPorNomeDoJogador(Context.User.Identity.Name);
            //_gerenciadorDePartida.DesconectarJogador(Context.User.Identity.Name);
            //Clients.Group(partida.Id.ToString()).InvokeAsync("JogadoresDaPartida", partida.Jogadores);
            
            return base.OnDisconnectedAsync(exception);
        }
    }
}