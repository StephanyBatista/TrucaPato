using System.Collections.Generic;

namespace TrucaPato.Web.Models
{
    public static class GerenteDeConexaoDeHub
    {
        private static Dictionary<string, string> _usuarios;

        public static void Adicionar(string nomeDoUsuario, string conexao)
        {
            if(_usuarios == null)
                _usuarios = new Dictionary<string, string>();

            if (_usuarios.ContainsKey(nomeDoUsuario))
                _usuarios.Remove(nomeDoUsuario);
            
            _usuarios.Add(nomeDoUsuario, conexao);
        }

        public static string ObterConexaoDoUsuario(string nomeDoUsuario)
        {
            return _usuarios.GetValueOrDefault(nomeDoUsuario);
        }
    }
}