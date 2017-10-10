using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nosbor.FluentBuilder.Lib;
using TrucaPato.Dominio._Base;
using TrucaPato.Dominio.Jogo.Salas;

namespace TrucaPato.DominioTeste.Jogo.Salas
{
    [TestClass]
    public class CriadorDeSalaTeste
    {
        private string _jogadorId;
        private Mock<ISalaRepositorio> _salaRepositorio;
        private CriadorDeSala _criadorDeSala;

        [TestInitialize]
        public void SetUp()
        {
            _jogadorId = "34d343";
            _salaRepositorio = new Mock<ISalaRepositorio>();
            _criadorDeSala = new CriadorDeSala(_salaRepositorio.Object);
        }
        
        [TestMethod]
        public void DeveCriarUmaSala()
        {
            _criadorDeSala.Criar(_jogadorId);

            _salaRepositorio.Verify(r => r.Adicionar(It.Is<Sala>(s => s.Criador == _jogadorId)));
        }

        [TestMethod]
        public void NaoDeveCriarSalaQuandoJogadorJaEstaEmUma()
        {
            var salaComJogador = FluentBuilder<Sala>.New().With(s => s.Criador, _jogadorId).Build();
            _salaRepositorio.Setup(r => r.ObterPorJogador(_jogadorId)).Returns(salaComJogador);

            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => _criadorDeSala.Criar(_jogadorId)).Message;
            Assert.AreEqual(message, "Não é possível criar sala quando já está em uma");
        }
    }
}