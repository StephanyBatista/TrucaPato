using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nosbor.FluentBuilder.Lib;
using TrucaPato.Dominio._Base;
using TrucaPato.Dominio.Jogo.Salas;

namespace TrucaPato.DominioTeste.Jogo.Salas
{
    [TestClass]
    public class SalaTeste
    {
        [TestMethod]
        public void DeveCriarUmaSala()
        {
            var criador = "23456";

            var sala = new Sala(criador);

            Assert.AreEqual(criador, sala.Criador);
        }

        [TestMethod]
        public void NaoDeveCriarUmaSalaComSeuCriadorNulo()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Sala(null)).Message;
            Assert.AreEqual(message, "Criador da sala é obrigatório");
        }

        [TestMethod]
        public void NaoDeveCriarUmaSalaComSeuCriadorVazio()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Sala(string.Empty)).Message;
            Assert.AreEqual(message, "Criador da sala é obrigatório");
        }

        [TestMethod]
        public void CriadorDaSalaDeveSerOPrimeiroJogadorAdicionadoNaSala()
        {
            var criador = "23456";
            var sala = new Sala(criador);

            Assert.AreEqual(criador, sala.Jogadores[0]);
        }

        [TestMethod]
        public void DeveTerOpcaoDeAdcionarJogador()
        {
            var jogador1 = "23456";
            var jogador2 = "343er";
            var sala = FluentBuilder<Sala>.New().With(s => s.Criador, jogador1).Build();

            sala.AdicionarJogador(jogador2);

            CollectionAssert.Contains(sala.Jogadores, jogador2);
        }

        [TestMethod]
        public void UmaSalaNaoPodeTerMaisQue4Jogadores()
        {
            var jogadoresDaSala = new []{ "jogador1", "jogador2", "jogador3", "jogador4" };
            var sala = new Sala(jogadoresDaSala[0]);
            sala.AdicionarJogador(jogadoresDaSala[1]);
            sala.AdicionarJogador(jogadoresDaSala[2]);
            sala.AdicionarJogador(jogadoresDaSala[3]);

            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => sala.AdicionarJogador("jogador5")).Message;
            Assert.AreEqual(message, "Uma sala não pode ter mais que 4 jogadores");
        }

        [TestMethod]
        public void SalaTemParaIniciadaQuandoTem4Jogadores()
        {
            var jogadoresDaSala = new []{ "jogador1", "jogador2", "jogador3", "jogador4" };
            var sala = new Sala(jogadoresDaSala[0]);
            sala.AdicionarJogador(jogadoresDaSala[1]);
            sala.AdicionarJogador(jogadoresDaSala[2]);
            sala.AdicionarJogador(jogadoresDaSala[3]);

            Assert.IsTrue(sala.PartidaIniciada);
        }
    }
}