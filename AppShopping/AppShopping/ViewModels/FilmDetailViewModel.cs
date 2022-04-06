using AppShopping.Helpers.MVVM;
using AppShopping.Models;
using AppShopping.Services;
using Newtonsoft.Json;
using System;
using System.Linq;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    [QueryProperty("filmSerialized", "filmSerialized")]
    public class FilmDetailViewModel : BaseViewModel
    {
        public Film Film { get; set; }

        public string filmSerialized {
            set
            {
                // Deserializar o film em forma de string que chega e atribuir ao Film
                var decode = Uri.UnescapeDataString(value); // Decodifica da Uri
                var film = JsonConvert.DeserializeObject<Film>(decode);

                Film = film;
                OnPropertyChanged(nameof(Film)); // Para avisar que o film foi alterado
            }
        }

        public FilmDetailViewModel()
        {
            
        }
    }
}
