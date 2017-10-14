namespace TrucaPato.Dominio.Jogo
{
    public interface IPartidaRepositorio
    {
        void Adicionar(Partida entidade);
        Partida ObterPorNomeDoJogador(string nomeDoJogador);
        Partida ObterDisponivel();
    }
}