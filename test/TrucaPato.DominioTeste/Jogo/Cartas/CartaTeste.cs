using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nosbor.FluentBuilder.Lib;
using TrucaPato.Dominio.Jogo.Cartas;
using TrucaPato.Dominio._Base;

namespace TrucaPato.DominioTeste.Jogo.Cartas
{
    [TestClass]
    public class CartaTeste
    {
        private Manilha _manilha;

        [TestInitialize]
        public void SetUp()
        {
            _manilha = FluentBuilder<Manilha>.New().Build();
        }
        
        [TestMethod]
        public void DeveCriarCarta()
        {
            const string nome = "A";
            const int peso = 0;

            var carta = new Carta(nome, peso, _manilha);
            
            Assert.AreEqual(nome, carta.Nome);
            Assert.AreEqual(peso, carta.Peso);
            Assert.AreEqual(_manilha, carta.Manilha);
        }

        [TestMethod]
        public void NaoDeveCriarCartaComNomeNulo()
        {
            const int PESO_QUALQUER = 0;
            
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Carta(null, PESO_QUALQUER, _manilha)).Message;
            Assert.AreEqual(message, "Nome da carta é obrigatório");
        }
        
        [TestMethod]
        public void NaoDeveCriarCartaComNomeVazio()
        {
            const int PESO_QUALQUER = 0;
            
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Carta(string.Empty, PESO_QUALQUER, _manilha)).Message;
            Assert.AreEqual(message, "Nome da carta é obrigatório");
        }
        
        [TestMethod]
        public void NaoDeveCriarCartaSemManilha()
        {
            const int PESO_QUALQUER = 0;
            
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Carta("NOME QUALQUER", PESO_QUALQUER, null)).Message;
            Assert.AreEqual(message, "Manilha da carta é obrigatório");
        }
    }
}