using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nosbor.FluentBuilder.Lib;
using TrucaPato.Dominio.Jogo.Cartas;
using TrucaPato.Dominio.Jogo.Jogadores;
using TrucaPato.Dominio._Base;

namespace TrucaPato.DominioTeste.Jogo.Jogadores
{
    [TestClass]
    public class CartasDoJogadorTeste
    {
        [TestMethod]
        public void DeveDarAsCartasDoJogador()
        {
            var jogador = FluentBuilder<Jogador>.New().Build();
            var cartas = FluentBuilder<Carta>.Many(3);

            var cartasDoJogador = new CartasDoJogador(jogador, cartas.ToList());
            
            Assert.AreEqual(jogador, cartasDoJogador.Jogador);
            Assert.AreEqual(cartas, cartasDoJogador.Cartas);
        }

        [TestMethod]
        public void NaoDeveDarCartasComJogadorNulo()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new CartasDoJogador(null, FluentBuilder<Carta>.Many(3).ToList())).Message;
            Assert.AreEqual("Não deve dar cartas sem jogador", message);
        }
        
        [TestMethod]
        public void NaoDeveDarCartasNulas()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new CartasDoJogador(FluentBuilder<Jogador>.New().Build(), null)).Message;
            Assert.AreEqual("Três cartas devem ser dadas para jogador", message);
        }
        
        [TestMethod]
        public void NaoDeveDarCartasVazias()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new CartasDoJogador(FluentBuilder<Jogador>.New().Build(), new List<Carta>())).Message;
            Assert.AreEqual("Três cartas devem ser dadas para jogador", message);
        }
        
        [TestMethod]
        public void DeveCadaJogadorReceberTresCartas()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new CartasDoJogador(FluentBuilder<Jogador>.New().Build(), FluentBuilder<Carta>.Many(2).ToList())).Message;
            Assert.AreEqual("Três cartas devem ser dadas para jogador", message);
        }
    }
}