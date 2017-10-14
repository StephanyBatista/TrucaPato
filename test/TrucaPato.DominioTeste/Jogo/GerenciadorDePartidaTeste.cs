using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TrucaPato.Dominio.Jogo;

namespace TrucaPato.DominioTeste.Jogo
{
    [TestClass]
    public class GerenciadorDePartidaTeste
    {
        private string _nomeDoJogador;
        private Mock<IPartidaRepositorio> _partidaRepositorio;
        private GerenciadorDePartida _gerenciadorDePartida;

        [TestInitialize]
        public void SetUp()
        {
            _nomeDoJogador = "34d343";
            _partidaRepositorio = new Mock<IPartidaRepositorio>();
            _gerenciadorDePartida = new GerenciadorDePartida(_partidaRepositorio.Object);
        }
        
        [TestMethod]
        public void DeveCriarNovaPartida()
        {
            _gerenciadorDePartida.NovaPartida(_nomeDoJogador);

            _partidaRepositorio.Verify(r => r.Adicionar(It.Is<Partida>(s => s.Jogadores.Exists(j => j.Nome == _nomeDoJogador))));
        }

        [TestMethod]
        public void NaoDeveCriarNovaPartidaQuandoUsuarioJaEstaEmUma()
        {
            var partidaComJogador = new Partida();
            partidaComJogador.AdicionarJogador(_nomeDoJogador);
            _partidaRepositorio.Setup(r => r.ObterPorNomeDoJogador(_nomeDoJogador)).Returns(partidaComJogador);
            
            _gerenciadorDePartida.NovaPartida(_nomeDoJogador);

            _partidaRepositorio.Verify(r => r.Adicionar(It.IsAny<Partida>()), Times.Never);
        }

        [TestMethod]
        public void DeveEntrarEmPartidaDisponivelParaJogador()
        {
            const string novoJogador = "343df3";
            var partidaDisponivel = new Partida();
            _partidaRepositorio.Setup(r => r.ObterDisponivel()).Returns(partidaDisponivel);

            _gerenciadorDePartida.EntrarEmPartida(novoJogador);

            Assert.IsTrue(partidaDisponivel.Jogadores.Exists(j => j.Nome == novoJogador));
        }

        [TestMethod]
        public void DeveCriarNovaParidaQuandoNaoExisteParidaDisponivelParaJogador()
        {
            const string novoJogador = "343df3";
            
            _gerenciadorDePartida.EntrarEmPartida(novoJogador);

            _partidaRepositorio.Verify(r => r.Adicionar(It.Is<Partida>(s => s.Jogadores.Exists(j => j.Nome == _nomeDoJogador))));
        }

        [TestMethod]
        public void DeveDesconectarJogadorDaParida()
        {
            var partidaComJogador = new Partida();
            partidaComJogador.AdicionarJogador(_nomeDoJogador);
            _partidaRepositorio.Setup(r => r.ObterPorNomeDoJogador(_nomeDoJogador)).Returns(partidaComJogador);

            _gerenciadorDePartida.DesconectarJogador(_nomeDoJogador);
            
            Assert.IsFalse(partidaComJogador.Jogadores.Exists(j => j.Nome == _nomeDoJogador));
        }
    }
}