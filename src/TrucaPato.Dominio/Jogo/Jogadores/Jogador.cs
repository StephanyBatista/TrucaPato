using TrucaPato.Dominio._Base;

namespace TrucaPato.Dominio.Jogo.Jogadores
{
    public class Jogador
    {
        public string Nome { get; private set; }
        public Equipe Equipe { get; set; }

        public Jogador(string nome, Equipe equipe)
        {
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(nome), "Nome do jogador é obrigatório");
            
            Nome = nome;
            Equipe = equipe;
        }
    }
}