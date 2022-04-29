using AppShopping.Helpers.MVVM;
using AppShopping.Libraries.Validators;
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
        private string _messages;

        public string Messages
        {
            get { return _messages; }
            set 
            { 
                SetProperty(ref _messages, value);
            }
        }

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
            // Tipos de Validação: Manual, Data Annotations e Fluent Validation*
            try
            {
                Messages = string.Empty;

                string messages = Valid(CreditCard);

                if (string.IsNullOrEmpty(messages))
                {
                    // Redirecionar para a tela de sucesso
                    int paymentId = _paymentService.SendPayment(CreditCard);
                }
                else
                {
                    Messages = messages;
                }

            }
            catch (Exception e)
            {
                // TODO - Colocar msg de erro (Redirecionar para tela de erro)
            }
        }
        private string Valid(CreditCard creditCard)
        {
            StringBuilder messages = new StringBuilder();

            if (string.IsNullOrEmpty(creditCard.Name))
            {
                messages.Append("O nome não foi preenchido!" + Environment.NewLine); // Independente da plataforma, cria uma nova linha
            }

            if (string.IsNullOrEmpty(_creditCard.Number))
            {
                messages.Append("O numero do cartão não foi preenchido!" + Environment.NewLine);
            }
            else if (_creditCard.Number.Length < 19)
            {
                messages.Append("O numero do cartão está incompleto!" + Environment.NewLine);
            }
            
            try
            {
                var expiredString = creditCard.Expire.Split('/');
                var month = int.Parse(expiredString[0]);
                var year = int.Parse(expiredString[1]);

                new DateTime(month, year, 01);
            }
            catch (Exception e)
            {
                messages.Append("A validade do cartão não é valida!" + Environment.NewLine);
            }

            if (string.IsNullOrEmpty(_creditCard.SecurityCode))
            {
                messages.Append("O código de segurança não foi preenchido!" + Environment.NewLine);
            }
            else if (creditCard.SecurityCode.Length < 3)
            {
                messages.Append("O código de segurança está incompleto!" + Environment.NewLine);
            }

            if (string.IsNullOrEmpty(_creditCard.Document))
            {
                messages.Append("O CPF não foi preenchido!" + Environment.NewLine);
            }
            else if (creditCard.Document.Length < 14)
            {
                messages.Append("O CPF está incompleto!" + Environment.NewLine);
            }
            else if (CpfValidator.IsCpf(creditCard.Document))
            {
                messages.Append("O CPF é inválido!" + Environment.NewLine);
            }

            return messages.ToString();
        }
    }
}
