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
            // TODO - Validar - Manual, Data Annotations e Fluent Validation*
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
            else if (IsCpf(creditCard.Document))
            {
                messages.Append("O CPF é inválido!" + Environment.NewLine);
            }

            return messages.ToString();
        }
        public bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
