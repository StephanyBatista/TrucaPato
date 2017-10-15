using System.Collections.Generic;
using System.Linq;
using TrucaPato.Dominio.Jogo.Cartas;
using TrucaPato.Dominio.Jogo.Jogadores;
using TrucaPato.Dominio._Base;

namespace TrucaPato.Dominio.Jogo
{
    public class Parcial
    {
        public List<Jogador> Jogadores { get; private set; }
        public Jogador JogadorDaCarta { get; private set; }
        public Carta MaiorCartaJogada { get; private set; }

        public Parcial(List<Jogador> jogadores)
        {
            Jogadores = jogadores;
            JogadorDaCarta = jogadores.First();
        }

        public void ProximoJogadorDaCarta()
        {
            var indexDoJogadorDaCarta = Jogadores.IndexOf(JogadorDaCarta);
            indexDoJogadorDaCarta++;
            JogadorDaCarta = Jogadores.ElementAt(indexDoJogadorDaCarta);
        }

        public void Jogar(string nomeDoJogador, Carta carta)
        {
            ExcecaoDeDominio.Quando(JogadorDaCarta.Nome != nomeDoJogador, "Não é permitido jogar na vez de outro jogador");
            
            MaiorCartaJogada = carta;
        }

        public bool PermiteJogar()
        {
            var indexDoJogadorDaCarta = Jogadores.IndexOf(JogadorDaCarta);
            return indexDoJogadorDaCarta + 1 < 4;
        }
    }
}