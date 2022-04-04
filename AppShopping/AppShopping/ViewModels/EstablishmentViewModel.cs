using AppShopping.Models;
using AppShopping.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using AppShopping.Libraries.Enums;
using AppShopping.Helpers.MVVM;
using Newtonsoft.Json;

namespace AppShopping.ViewModels
{
    public abstract class EstablishmentViewModel : BaseViewModel
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

        public ICommand DetailCommand { get; set; }
        private EstablishmentType _establishmentType;

        public EstablishmentViewModel(EstablishmentType establishmentType)
        {
            _establishmentType = establishmentType;
            SearchCommand = new Command(Search); // O que será feito quando clicar no botão de OK
            DetailCommand = new Command<Establishment>(Detail);

            var allEstablishment = new EstablishmentService().GetEstablishments(); // Todos os Establishments
            var allStores = allEstablishment.Where(a => a.Type == _establishmentType).ToList(); // Todos as Stores

            Establishments = allStores;
            _allEstablishments = allStores;
        }

        private void Search()
        {
            // Lógica para filtrar a lista de Lojas
            Establishments = _allEstablishments.Where(a => a.Name.ToLower().Contains(SearchWord.ToLower())).ToList();
        }

        private void Detail(Establishment establishment)
        {
            String establishmentSerialized = JsonConvert.SerializeObject(establishment);

            // Shell GoTo EstablishmentDetail
            Shell.Current.GoToAsync($"establishment/detail?establishmentSerialized={Uri.EscapeDataString(establishmentSerialized)}"); // Apontando para a rota estabelecida no menu
        }
    }
}
