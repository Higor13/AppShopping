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
    [QueryProperty("Number", "number")] // Sempre que trocar para essa tela, receber o número do ticket escaneado
    public class TicketPaymentViewModel : BaseViewModel
    {
        private string _number;
        public String Number
        {
            set
            {
                SetProperty(ref _number, value);

                // Pesquisar ticket e jogar na tela
                Ticket = _ticketService.GetTicketInfo(value);
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
        private CreditCard _creditCard;

        public CreditCard CreditCard
        {
            get { return _creditCard; }
            set 
            {
                SetProperty(ref _creditCard, value);
            }
        }

        public ICommand PaymentCommand { get; set; }

        private TicketService _ticketService;
        public TicketPaymentViewModel()
        {
            _ticketService = new TicketService();
        }

        private void Payment()
        {
            // TODO - Implementar
            // TODO - Validar
            // TODO - Integração com um serviço API
            // TODO - Colocar msg de erro (Redirecionar)
        }
    }
}
