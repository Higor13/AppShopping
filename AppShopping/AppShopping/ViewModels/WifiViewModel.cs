using AppShopping.Helpers.MVVM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    public class WifiViewModel : BaseViewModel
    {
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public ICommand ConnectToWifiCommand { get; set; }

        public WifiViewModel()
        {
            ConnectToWifiCommand = new Command(ConnecToWifi);
        }

        private void ConnecToWifi(object obj)
        {
            
        }
    }
}
