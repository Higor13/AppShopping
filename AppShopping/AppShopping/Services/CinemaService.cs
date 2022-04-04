using AppShopping.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppShopping.Services
{
    public class CinemaService
    {
        public List<Film> GetFilms()
        {
            return new List<Film>() 
            { 
                new Film() { 
                    Name = "1917", 
                    Description = "Na Primeira Guerra Mundial, dois soldados britânicos recebem ordens aparentemente impossíveis de cumprir. Em uma corrida contra o tempo, eles precisam atravessar o território inimigo e entregar uma mensagem que pode salvar 1600 de seus companheiros.",
                },
                new Film() { 
                    Name = "Arlequina em Aves de Rapina", 
                    Description = "Depois de se aventurar com o Coringa, Arlequina se junta a Canário Negro, Caçadora e Renee Montoya para salvar a vida de uma garotinha do criminoso Máscara Negra em Gotham City.",
                },
            };
        }
    }
}
