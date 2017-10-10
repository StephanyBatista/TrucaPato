using System.Collections.Generic;
using System.Linq;
using TrucaPato.Dominio.Jogo.Salas;

namespace TrucaPato.Dado.Repositorio
{
    public class SalaRepositorio : ISalaRepositorio
    {
        private static List<Sala> _salas;

        public void Adicionar(Sala entidade)
        {
            _salas.Add(entidade);
        }

        public Sala ObterPorJogador(string jogadorId)
        {
            return _salas.Where(s => s.Jogadores.Contains(jogadorId)).FirstOrDefault();
        }
    }
}