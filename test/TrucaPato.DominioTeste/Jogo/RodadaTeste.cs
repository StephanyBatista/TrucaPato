using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrucaPato.Dominio.Jogo;
using TrucaPato.Dominio.Jogo.Jogadores;

namespace TrucaPato.DominioTeste.Jogo
{
    [TestClass]
    public class RodadaTeste
    {
        private List<Jogador> _jogadores;

        [TestInitialize]
        public void SetUp()
        {
            _jogadores = new List<Jogador>
            {
                new Jogador("Jogador 1", Equipe.Amarelo),
                new Jogador("Jogador 2", Equipe.Vermelho),
                new Jogador("Jogador 3", Equipe.Amarelo),
                new Jogador("Jogador 4", Equipe.Vermelho),
            };
        }
        
        [TestMethod]
        public void DeveCriarRodadaDaPartida()
        {
            var rodada = new Rodada(_jogadores);
            
            Assert.AreEqual(rodada.CartasDosJogadores.Count, _jogadores.Count);
        }

        [TestMethod]
        public void NaoDeveJogadoresTeremCartasIguais()
        {
            var rodada = new Rodada(_jogadores);
            
            foreach (var cartasDoJogador in rodada.CartasDosJogadores)
            {
                foreach (var carta in cartasDoJogador.Cartas)
                {
                    var jogadoresTemUmaMesmaCarta = rodada.CartasDosJogadores
                        .Where(
                            cj => cj.Jogador != cartasDoJogador.Jogador && cj.Cartas.Exists(c => c == carta));
                    
                    Assert.IsFalse(jogadoresTemUmaMesmaCarta.Any());
                }
            }
        }

        [TestMethod]
        public void CartaDaRodadaDeveSerSelecionada()
        {
            var rodada = new Rodada(_jogadores);
            
            Assert.IsNotNull(rodada.CartaDaRodada);
        }

        [TestMethod]
        public void NaoDeveJogadoresTerACartaDaRodadaEmSuasCartas()
        {
            var rodada = new Rodada(_jogadores);
            
            foreach (var cartasDoJogador in rodada.CartasDosJogadores)
                foreach (var carta in cartasDoJogador.Cartas)
                    Assert.AreNotEqual(carta, rodada.CartaDaRodada);
        }
    }
}