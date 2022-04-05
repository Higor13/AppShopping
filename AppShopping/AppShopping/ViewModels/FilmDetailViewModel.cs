using AppShopping.Models;
using AppShopping.Services;
using System.Linq;

namespace AppShopping.ViewModels
{
    public class FilmDetailViewModel
    {
        public Film Film { get; set; }

        public FilmDetailViewModel()
        {
            Film = new CinemaService().GetFilms().First();
        }
    }
}
