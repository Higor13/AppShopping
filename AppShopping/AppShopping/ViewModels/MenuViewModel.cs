using AppShopping.Helpers.MVVM;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using System.Windows.Input;
using Xamarin.Forms;
using MvvmHelpers.Commands;
using System.Threading.Tasks;

namespace AppShopping.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public ICommand OpenMapCommand { get; set; }

        public MenuViewModel()
        {
            OpenMapCommand = new AsyncCommand(OpenMapAsync);
        }

        private async Task OpenMapAsync()
        {
            var location = new Location(-12.936447185401027, -38.39510656483502);
            var options = new MapLaunchOptions
            {
                Name = "App - Shopping",
                NavigationMode = NavigationMode.Default
            };

            try
            {
                await Map.OpenAsync(location, options);
            }
            catch (Exception e)
            {
                await Shell.Current.DisplayAlert("Erro!", "Não conseguimos abrir o mapa no seu celular!", "OK");
            }
        }
    }
}
