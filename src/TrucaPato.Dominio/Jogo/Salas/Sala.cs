using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TrucaPato.Dominio._Base;

namespace TrucaPato.Dominio.Jogo.Salas
{
    public class Sala
    {
        public string Criador {get; private set;}
        private List<string> _jogadores;
        public ReadOnlyCollection<string> Jogadores{ get { return new ReadOnlyCollection<string>(_jogadores);}}
        public bool PartidaIniciada { get; private set; }
        private int numeroMaximoDeJogadores = 4;

        public Sala(string criador)
        {
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(criador), "Criador da sala é obrigatório");
            
            Criador = criador;
            _jogadores = new List<string>();
            _jogadores.Add(criador);
        }

        public void AdicionarJogador(string jogador)
        {
            ExcecaoDeDominio.Quando(_jogadores.Count == 4, "Uma sala não pode ter mais que 4 jogadores");
            
            _jogadores.Add(jogador);

            if(_jogadores.Count == numeroMaximoDeJogadores)
                PartidaIniciada = true;
        }
    }
}