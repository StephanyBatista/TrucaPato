using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrucaPato.Dominio.Jogo.Jogadores;
using TrucaPato.Dominio._Base;

namespace TrucaPato.DominioTeste.Jogo.Jogadores
{
    [TestClass]
    public class JogadorTeste
    {
        [TestMethod]
        public void DeveCriarJogador()
        {
            const string nome = "jogador teste";
            const Equipe amarelo = Equipe.Amarelo;
            var jogador = new Jogador(nome, amarelo);
            
            Assert.AreEqual(nome, jogador.Nome);
            Assert.AreEqual(amarelo, jogador.Equipe);
        }

        [TestMethod]
        public void NaoDevCriarJogadorComNomeNulo()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Jogador(null, Equipe.Amarelo)).Message;
            Assert.AreEqual("Nome do jogador é obrigatório", message);
        }
        
        [TestMethod]
        public void NaoDevCriarJogadorComNomeVazio()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Jogador(string.Empty, Equipe.Amarelo)).Message;
            Assert.AreEqual("Nome do jogador é obrigatório", message);
        }
    }
}