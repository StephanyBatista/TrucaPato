using TrucaPato.Dominio._Base;

namespace TrucaPato.Dominio.Jogo.Cartas
{
    public class Carta
    {
        public string Nome { get; private set; }
        public Manilha Manilha { get; private set; }
        public int Peso { get; private set; }

        public Carta(string nome, int peso, Manilha manilha)
        {
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(nome), "Nome da carta é obrigatório");
            ExcecaoDeDominio.Quando(manilha == null, "Manilha da carta é obrigatório");
            
            Nome = nome;
            Manilha = manilha;
        }
    }
}