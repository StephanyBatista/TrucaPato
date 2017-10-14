using System;
using System.Collections.Generic;
using System.Linq;

namespace TrucaPato.Dominio.Jogo.Cartas
{
    public static class TodasAsCartas
    {
        public static List<Carta> Todas
        {
            get
            {
                var mailhaDePica = new Manilha("Picafumo", 1);
                var mailhaDeEspadilha = new Manilha("Espadilha", 2);
                var mailhaDeCopas = new Manilha("Copas", 3);
                var mailhaDeZapi = new Manilha("Zapi", 4);
                
                return new List<Carta>
                {
                    new Carta("Q", 1, mailhaDePica),
                    new Carta("Q", 1, mailhaDeEspadilha),
                    new Carta("Q", 1, mailhaDeCopas),
                    new Carta("Q", 1, mailhaDeZapi),
                    
                    new Carta("J", 2, mailhaDePica),
                    new Carta("J", 2, mailhaDeEspadilha),
                    new Carta("J", 2, mailhaDeCopas),
                    new Carta("J", 2, mailhaDeZapi),
                    
                    new Carta("K", 3, mailhaDePica),
                    new Carta("K", 3, mailhaDeEspadilha),
                    new Carta("K", 3, mailhaDeCopas),
                    new Carta("K", 3, mailhaDeZapi),
                    
                    new Carta("A", 4, mailhaDePica),
                    new Carta("A", 4, mailhaDeEspadilha),
                    new Carta("A", 4, mailhaDeCopas),
                    new Carta("A", 4, mailhaDeZapi),
                    
                    new Carta("2", 5, mailhaDePica),
                    new Carta("2", 5, mailhaDeEspadilha),
                    new Carta("2", 5, mailhaDeCopas),
                    new Carta("2", 5, mailhaDeZapi),
                    
                    new Carta("3", 6, mailhaDePica),
                    new Carta("3", 6, mailhaDeEspadilha),
                    new Carta("3", 6, mailhaDeCopas),
                    new Carta("3", 6, mailhaDeZapi),
                    
                    new Carta("4", 7, mailhaDePica),
                    new Carta("4", 7, mailhaDeEspadilha),
                    new Carta("4", 7, mailhaDeCopas),
                    new Carta("4", 7, mailhaDeZapi),
                    
                    new Carta("5", 1, mailhaDePica),
                    new Carta("5", 1, mailhaDeEspadilha),
                    new Carta("5", 1, mailhaDeCopas),
                    new Carta("5", 1, mailhaDeZapi),
                    
                    new Carta("6", 1, mailhaDePica),
                    new Carta("6", 1, mailhaDeEspadilha),
                    new Carta("6", 1, mailhaDeCopas),
                    new Carta("6", 1, mailhaDeZapi),
                    
                    new Carta("7", 1, mailhaDePica),
                    new Carta("7", 1, mailhaDeEspadilha),
                    new Carta("7", 1, mailhaDeCopas),
                    new Carta("7", 1, mailhaDeZapi),
                };
            }
        }
        
        public static List<Carta> Embaralhar(int numeroDeCartasParaOJogo)
        {
            return Todas.OrderBy(c => Guid.NewGuid()).Take(numeroDeCartasParaOJogo).ToList();
        }
    }
}