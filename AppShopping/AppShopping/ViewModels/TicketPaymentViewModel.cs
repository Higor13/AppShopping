using AppShopping.Helpers.MVVM;
using AppShopping.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    [QueryProperty("Number", "number")] // Sempre que trocar para essa tela, receber o número do ticket escaneado
    public class TicketPaymentViewModel : BaseViewModel
    {
        private string _number;
        public String Number
        {
            set
            {
                _number = value;
                OnPropertyChanged(nameof(Number));

                // TODO - Pesquisar ticket e jogar na tela
            }
        }
        private Ticket _ticket;
        public Ticket Ticket
        {
            get { return _ticket; }
            set
            {
                SetProperty(ref _ticket, value);
            }
        }

        public TicketPaymentViewModel()
        {

        }
    }
}
