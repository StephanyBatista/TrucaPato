using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrucaPato.Dominio.Jogo.Cartas;
using TrucaPato.Dominio._Base;

namespace TrucaPato.DominioTeste.Jogo.Cartas
{
    
    [TestClass]
    public class ManilhaTeste
    {
        [TestMethod]
        public void DeveCriarUmaManilha()
        {
            const string nome = "Copas";
            const int peso = 1;
            
            var manilha = new Manilha(nome, peso);
            
            Assert.AreEqual(nome, manilha.Nome);
            Assert.AreEqual(peso, manilha.Peso);
        }

        [TestMethod]
        public void NaoDeveCriarManilhaComNomeNulo()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Manilha(null, peso: 0)).Message;
            Assert.AreEqual("Nome da manilha é obrigatório", message);
        }
        
        [TestMethod]
        public void NaoDeveCriarManilhaComNomeVazio()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Manilha(string.Empty, peso: 0)).Message;
            Assert.AreEqual("Nome da manilha é obrigatório", message);
        }
    }
}