using System.Collections.Generic;
using System.Linq;
using TrucaPato.Dominio.Jogo.Cartas;
using TrucaPato.Dominio._Base;

namespace TrucaPato.Dominio.Jogo.Jogadores
{
    public class CartasDoJogador
    {
        public Jogador Jogador { get; private set; }
        public List<Carta> Cartas { get; private set; }
        public string NomeDoJogador => Jogador.Nome;

        public CartasDoJogador(Jogador jogador, List<Carta> cartas)
        {
            ExcecaoDeDominio.Quando(jogador == null, "Não deve dar cartas sem jogador");
            ExcecaoDeDominio.Quando(cartas == null || !cartas.Any() || cartas.Count() != 3, "Três cartas devem ser dadas para jogador");
            
            Jogador = jogador;
            Cartas = cartas;
        }
    }
}