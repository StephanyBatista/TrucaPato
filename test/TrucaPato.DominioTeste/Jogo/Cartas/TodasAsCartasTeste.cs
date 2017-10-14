using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrucaPato.Dominio.Jogo.Cartas;

namespace TrucaPato.DominioTeste.Jogo.Cartas
{
    [TestClass]
    public class TodasAsCartasTeste
    {
        [TestMethod]
        public void DeveRetornarCartasEmbaralhadas()
        {
            const int numeroDeCartasParaOJogo = 13;
            var cartasOrdenadas = TodasAsCartas.Todas.Take(numeroDeCartasParaOJogo).ToList();

            var cartasEmbaralhadas = TodasAsCartas.Embaralhar(numeroDeCartasParaOJogo);
            
            Assert.AreEqual(numeroDeCartasParaOJogo, cartasEmbaralhadas.Count);
            CollectionAssert.AreNotEquivalent(cartasOrdenadas, cartasEmbaralhadas);
        }
    }
}