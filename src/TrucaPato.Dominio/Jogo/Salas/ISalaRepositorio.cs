namespace TrucaPato.Dominio.Jogo.Salas
{
    public interface ISalaRepositorio
    {
         void Adicionar(Sala entidade);
         Sala ObterPorJogador(string jogadorId);
    }
}