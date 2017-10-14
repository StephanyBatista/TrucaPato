using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TrucaPato.Dominio.Jogo.Jogadores;
using TrucaPato.Dominio._Base;

namespace TrucaPato.Dominio.Jogo
{
    public class Partida
    {
        public bool PartidaIniciada { get; private set; }
        public Guid Id { get; private set; }
        public List<Jogador> Jogadores { get; private set; }
        public Rodada RodadaAtual { get; private set; }
        public IEnumerable<CartasDoJogador> AtualCartasDosJogadores => RodadaAtual.CartasDosJogadores;

        private const int NumeroMaximoDeJogadores = 4;

        public Partida()
        {
            Id = Guid.NewGuid();
            Jogadores = new List<Jogador>();
        }

        public void AdicionarJogador(string nomeDoJogador)
        {
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(nomeDoJogador), "Jogador inicial da partida é obrigatório");
            ExcecaoDeDominio.Quando(Jogadores.Count == 4, "Uma partida não pode ter mais que 4 jogadores");

            Jogadores.Add(new Jogador(nomeDoJogador, SelecionarEquipeDoJogador()));
        }

        private Equipe SelecionarEquipeDoJogador()
        {
            var equipeAtual = Equipe.Amarelo;

            if (Jogadores.Any() && Jogadores.LastOrDefault().Equipe == Equipe.Amarelo)
                equipeAtual = Equipe.Vermelho;
            
            return equipeAtual;
        }

        public void Desconectar(string nomeDoJogador)
        {
            Jogadores.RemoveAll(j => j.Nome == nomeDoJogador);
        }

        public bool PodeIniciarPartida()
        {
            return Jogadores.Count == NumeroMaximoDeJogadores;
        }

        public void IniciarPartida()
        {
            PartidaIniciada = true;
        }

        public void IniciarRodada()
        {
            RodadaAtual = new Rodada(Jogadores);
        }
    }
}