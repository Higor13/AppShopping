using AppShopping.Models;
using AppShopping.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using AppShopping.Libraries.Enums;
using System.ComponentModel;
using AppShopping.Helpers.MVVM;

namespace AppShopping.ViewModels
{
    public class StoresViewModel : BaseViewModel
    {
        public String SearchWord { get; set; }
        public ICommand SearchCommand { get; set; }
        private List<Establishment> _establishments;
        public List<Establishment> Establishments
        {
            get
            {
                return _establishments;
            }
            set
            {
                SetProperty(ref _establishments, value);
            }
        }
        private List<Establishment> _allEstablishments;

        public StoresViewModel()
        {
            SearchCommand = new Command(Search); // O que será feito quando clicar no botão de OK
            var allEstablishment = new EstablishmentService().GetEstablishments(); // Todos os Establishments
            var allStores = allEstablishment.Where(a => a.Type == EstablishmentType.Store).ToList(); // Todos as Stores
            Establishments = allStores;
            _allEstablishments = allStores;
        }

        private void Search()
        {
            // Lógica para filtrar a lista de Lojas
            Establishments = _allEstablishments.Where(a => a.Name.ToLower().Contains(SearchWord.ToLower())).ToList();
        }
    }
}
