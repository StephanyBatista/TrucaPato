namespace TrucaPato.Dominio._Base
{
    public class ExcecaoDeDominio : System.Exception
    {
        public ExcecaoDeDominio(string erro) : base(erro) { }

        public static void Quando(bool temErro, string mensagemDeError)
        {
            if (temErro)
                throw new ExcecaoDeDominio(mensagemDeError);
        }
    }
}