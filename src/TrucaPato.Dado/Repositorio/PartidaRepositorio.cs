using System.Collections.Generic;
using System.Linq;
using TrucaPato.Dominio.Jogo;

namespace TrucaPato.Dado.Repositorio
{
    public class PartidaRepositorio : IPartidaRepositorio
    {
        private static List<Partida> _partidas;

        public PartidaRepositorio()
        {
            if(_partidas == null)
                _partidas = new List<Partida>();
        }

        public void Adicionar(Partida entidade)
        {
            _partidas.Add(entidade);
        }

        public Partida ObterPorNomeDoJogador(string nomeDoJogador)
        {
            return _partidas.FirstOrDefault(s => s.Jogadores.Exists(j => j.Nome == nomeDoJogador));
        }

        public Partida ObterDisponivel()
        {
            return _partidas.FirstOrDefault(s => !s.PartidaIniciada);
        }
    }
}