using AppShopping.Helpers.MVVM;
using AppShopping.Models;
using AppShopping.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    [QueryProperty("Number", "number")]
    [QueryProperty("Message", "message")]
    public class TicketPaymentFailedViewModel : BaseViewModel
    {
        private string _message;

        public string Message
        {
            get { return _message; }
            set 
            { 
                SetProperty(ref _message, value);
            }
        }

        private Ticket _ticket;

        public Ticket Ticket
        {
            get 
            { 
                return _ticket;
            }
            set 
            { 
                SetProperty(ref _ticket, value);
            }
        }
        private string _number;
        public String Number
        {
            set
            {
                SetProperty(ref _number, value);

                // Pesquisar ticket e jogar na tela
                Ticket = _ticketService.GetTicket(value);
            }
        }
        public ICommand OkCommand { get; set; }
        private TicketService _ticketService;

        public TicketPaymentFailedViewModel()
        {
            _ticketService = new TicketService();

            OkCommand = new Command(Ok);
        }

        private void Ok()
        {
            Shell.Current.Navigation.PopToRootAsync(); // Volta a tela inicial (tela pague seu ticket)
        }
    }
}
