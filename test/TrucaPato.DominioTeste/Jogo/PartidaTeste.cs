using System;
using System.Linq;
using System.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nosbor.FluentBuilder.Lib;
using TrucaPato.Dominio.Jogo;
using TrucaPato.Dominio._Base;

namespace TrucaPato.DominioTeste.Jogo
{
    [TestClass]
    public class PartidaTeste
    {
        private Partida _partidaCom4Jogadores;

        [TestInitialize]
        public void SetUp()
        {
            var jogadoresDaPartida = new []{ "jogador1", "jogador2", "jogador3", "jogador4" };
            
            _partidaCom4Jogadores = new Partida();
            _partidaCom4Jogadores.AdicionarJogador(jogadoresDaPartida[0]);
            _partidaCom4Jogadores.AdicionarJogador(jogadoresDaPartida[1]);
            _partidaCom4Jogadores.AdicionarJogador(jogadoresDaPartida[2]);
            _partidaCom4Jogadores.AdicionarJogador(jogadoresDaPartida[3]);
        }
        
        [TestMethod]
        public void DeveCriarUmaPartida()
        {
            var partida = new Partida();

            Assert.AreNotEqual(partida.Id, Guid.Empty);
        }

        [TestMethod]
        public void DeveTerOpcaoDeAdcionarJogador()
        {
            const string jogador = "343er";
            var partida = new Partida();

            partida.AdicionarJogador(jogador);

            Assert.IsTrue(partida.Jogadores.Exists(j => j.Nome == jogador));
        }

        [TestMethod]
        public void DeveAdicionarJogadoresAlternadamenteDentroDasEquipes()
        {
            for(var i = 1; i < _partidaCom4Jogadores.Jogadores.Count; i++)
                Assert.AreNotEqual(_partidaCom4Jogadores.Jogadores[i - 1].Equipe, _partidaCom4Jogadores.Jogadores[i].Equipe);
        }
        
        [TestMethod]
        public void NaoDeveAdicionarJogadorNulo()
        {
            var partida = new Partida();
            
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => partida.AdicionarJogador(null)).Message;
            Assert.AreEqual(message, "Jogador inicial da partida é obrigatório");
        }

        [TestMethod]
        public void NaoDeveCriarUmaPartidaComJogadorVazio()
        {
            var partida = new Partida();
            
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => partida.AdicionarJogador(string.Empty)).Message;
            Assert.AreEqual(message, "Jogador inicial da partida é obrigatório");
        }

        [TestMethod]
        public void NaoDevePartidaTerMaisQue4Jogadores()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => _partidaCom4Jogadores.AdicionarJogador("jogador5")).Message;
            Assert.AreEqual(message, "Uma partida não pode ter mais que 4 jogadores");
        }

        [TestMethod]
        public void DeveInformarQuePartidaPodeSerIniciadaQuandoTem4Jogadores()
        {
            Assert.IsTrue(_partidaCom4Jogadores.PodeIniciarPartida());
        }

        [TestMethod]
        public void NaoDeveInformarQuePartidaPodeSerIniciadaQuandoTemMenosQue4Jogadores()
        {
            var partida = FluentBuilder<Partida>.New().Build();
            
            Assert.IsFalse(partida.PodeIniciarPartida());
        }

        [TestMethod]
        public void QuandoIniciadaPartidaDeveInformarQuePartidaFoiIniciada()
        {
            _partidaCom4Jogadores.IniciarPartida();
            
            Assert.IsTrue(_partidaCom4Jogadores.PartidaIniciada);
        }

        [TestMethod]
        public void DeveIniciarRodada()
        {
            _partidaCom4Jogadores.IniciarRodada();
            
            Assert.IsNotNull(_partidaCom4Jogadores.RodadaAtual);
        }
    }
}