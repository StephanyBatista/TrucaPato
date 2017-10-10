using System;
using TrucaPato.Dominio._Base;

namespace TrucaPato.Dominio.Jogo.Salas
{
    public interface ICriadorDeSala
    {
        void Criar(string jogadorId);
    }
    
    public class CriadorDeSala : ICriadorDeSala
    {
        private ISalaRepositorio _salaRepositorio;

        public CriadorDeSala(ISalaRepositorio salaRepositorio)
        {
            _salaRepositorio = salaRepositorio;
        }

        public void Criar(string jogadorId)
        {
            var salaJaCriada = _salaRepositorio.ObterPorJogador(jogadorId);
            ExcecaoDeDominio.Quando(salaJaCriada != null, "Não é possível criar sala quando já está em uma");
            
            var sala = new Sala(jogadorId);
            _salaRepositorio.Adicionar(sala);
        }
    }
}