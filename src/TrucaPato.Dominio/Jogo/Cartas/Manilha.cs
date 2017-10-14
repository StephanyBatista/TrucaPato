using TrucaPato.Dominio._Base;

namespace TrucaPato.Dominio.Jogo.Cartas
{
    public class Manilha
    {
        public string Nome { get; private set; }
        public int Peso { get; private set; }

        public Manilha(string nome, int peso)
        {
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(nome), "Nome da manilha é obrigatório");
            
            Nome = nome;
            Peso = peso;
        }
    }
}