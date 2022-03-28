using AppShopping.Models;
using AppShopping.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using AppShopping.Libraries.Enums;

namespace AppShopping.ViewModels
{
    public class StoresViewModel
    {
        public String SearchWord { get; set; }
        public ICommand SearchCommand { get; set; }
        public List<Establishment> Establishments { get; set; }

        public StoresViewModel()
        {
            SearchCommand = new Command(Search); // O que será feito quando clicar no botão de OK
            var allEstablishment = new EstablishmentService().GetEstablishments(); // Todos os Establishments
            var allStores = allEstablishment.Where(a => a.Type == EstablishmentType.Store).ToList(); // Todos as Stores
            Establishments = allStores;
        }

        private void Search()
        {
            // Lógica de filtrar a lista de Lojas
        }
    }
}
