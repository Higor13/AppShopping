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
        private PaymentService _paymentService;
        public TicketPaymentViewModel()
        {
            _ticketService = new TicketService();
            _paymentService = new PaymentService();

            CreditCard = new CreditCard();

            PaymentCommand = new Command(Payment);
        }

        private void Payment()
        {
            // TODO - Validar
            try
            {
                int paymentId = _paymentService.SendPayment(CreditCard);

                // TODO - Redirecionar para a tela de sucesso
            }
            catch (Exception e)
            {
                // TODO - Colocar msg de erro (Redirecionar para tela de erro)
            }
        }
    }
}
