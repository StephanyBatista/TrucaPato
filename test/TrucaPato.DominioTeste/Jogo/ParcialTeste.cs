using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nosbor.FluentBuilder.Lib;
using TrucaPato.Dominio.Jogo;
using TrucaPato.Dominio.Jogo.Cartas;
using TrucaPato.Dominio.Jogo.Jogadores;
using TrucaPato.Dominio._Base;

namespace TrucaPato.DominioTeste.Jogo
{
    [TestClass]
    public class ParcialTeste
    {
        private Parcial _parcial;
        private List<Jogador> _jogadores;

        [TestInitialize]
        public void SetUp()
        {
            _jogadores = new List<Jogador>
            {
                new Jogador("jogador1", Equipe.Amarelo),
                new Jogador("jogador2", Equipe.Vermelho),
                new Jogador("jogador3", Equipe.Amarelo),
                new Jogador("jogador4", Equipe.Vermelho),
            };
            
            _parcial = new Parcial(_jogadores);
        }
        
        [TestMethod]
        public void DeveCriarParcial()
        {
            Assert.AreEqual(_jogadores, _parcial.Jogadores);
        }

        
        [TestMethod]
        public void DeveSelecionarOPrimeiroJogadorDaCarta()
        {
            Assert.AreEqual(_jogadores.ElementAt(0), _parcial.JogadorDaCarta);
        }

        [TestMethod]
        [DataRow(0, 1)]
        [DataRow(1, 2)]
        [DataRow(2, 3)]
        public void DeveSelecionarOProximoJogadorDaCarta(int indexDoAtualJogadorDaCarta, int indexDoEsperadoJogadorDaCarta)
        {
            var parcial = FluentBuilder<Parcial>.New().With(p => p.Jogadores, _jogadores)
                .With(p => p.JogadorDaCarta, _jogadores[indexDoAtualJogadorDaCarta]).Build();
            
            parcial.ProximoJogadorDaCarta();
            
            Assert.AreEqual(_jogadores[indexDoEsperadoJogadorDaCarta], parcial.JogadorDaCarta);
        }

        [TestMethod]
        public void DevePermitirJogarQuandoNemTodosOsJogadoresJogaram()
        {
            Assert.IsTrue(_parcial.PermiteJogar());
        }
        
        [TestMethod]
        public void NaoDevePermitirJogarQuandoTodosOsJogadoresJogaram()
        {
            var parcial = FluentBuilder<Parcial>.New().With(p => p.Jogadores, _jogadores)
                .With(p => p.JogadorDaCarta, _jogadores.Last()).Build(); 
            
            Assert.IsFalse(parcial.PermiteJogar());
        }

        [TestMethod]
        public void DeveInformarAMaiorCartaJogada()
        {
            var nomeDoJogador = "jogador1";
            var carta = FluentBuilder<Carta>.New().Build();

            _parcial.Jogar(nomeDoJogador, carta);
            
            Assert.AreEqual(carta, _parcial.MaiorCartaJogada);
        }

        [TestMethod]
        public void NaoDeveJogarQuandoNaoForAVezDoJogador()
        {
            const string nomeDoJogador = "jogador2";
            var carta = FluentBuilder<Carta>.New().Build();

            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => _parcial.Jogar(nomeDoJogador, carta)).Message;
            Assert.AreEqual(message, "Não é permitido jogar na vez de outro jogador");
        }
    }
}