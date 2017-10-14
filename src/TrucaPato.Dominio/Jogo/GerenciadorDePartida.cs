namespace TrucaPato.Dominio.Jogo
{
    public interface IGerenciadorDePartida
    {
        void NovaPartida(string nomeDoJogador);
        void EntrarEmPartida(string novoJogador);
        void DesconectarJogador(string jogadorId);
    }
    
    public class GerenciadorDePartida : IGerenciadorDePartida
    {
        private readonly IPartidaRepositorio _partidaRepositorio;

        public GerenciadorDePartida(IPartidaRepositorio partidaRepositorio)
        {
            _partidaRepositorio = partidaRepositorio;
        }

        public void NovaPartida(string nomeDoJogador)
        {
            var partidaDoJogador = _partidaRepositorio.ObterPorNomeDoJogador(nomeDoJogador);

            if (partidaDoJogador != null) return;
            var partida = new Partida();
            partida.AdicionarJogador(nomeDoJogador);
            _partidaRepositorio.Adicionar(partida);
        }

        public void EntrarEmPartida(string novoJogador)
        {
            var partidaDisponivel = _partidaRepositorio.ObterDisponivel();
            
            if(partidaDisponivel != null)            
                partidaDisponivel.AdicionarJogador(novoJogador);
            else
                NovaPartida(novoJogador);
        }

        public void DesconectarJogador(string jogadorId)
        {
            var partidaDoJogador = _partidaRepositorio.ObterPorNomeDoJogador(jogadorId);

            partidaDoJogador.Desconectar(jogadorId);
        }
    }
}