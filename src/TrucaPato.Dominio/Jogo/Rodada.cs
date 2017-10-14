using System.Collections.Generic;
using System.Linq;
using TrucaPato.Dominio.Jogo.Cartas;
using TrucaPato.Dominio.Jogo.Jogadores;

namespace TrucaPato.Dominio.Jogo
{
    public class Rodada
    {
        public List<CartasDoJogador> CartasDosJogadores { get; private set; }
        public Carta CartaDaRodada { get; private set; }

        public Rodada(IReadOnlyList<Jogador> jogadores)
        {
            CartasDosJogadores = new List<CartasDoJogador>();
            var cartasEmbaralhadas = TodasAsCartas.Embaralhar(13);

            for (var i = 0; i < jogadores.Count; i++)
                CartasDosJogadores.Add(new CartasDoJogador(jogadores[i], cartasEmbaralhadas.Skip(i * 3).Take(3).ToList()));

            CartaDaRodada = cartasEmbaralhadas.Last();
        }
    }
}