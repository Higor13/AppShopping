using AppShopping.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppShopping.Services
{
    public class PaymentService
    {
        // Falta enviar para o provedor de pagamento: Valor, Dados do cliente (endereço) - Visa, Master
        public string SendPayment(CreditCard creditCard, Ticket ticket) // Enviar dados do cartão para empresa que intermedia o pagamento
        {
            if (creditCard.SecurityCode == "111")
            {
                throw new Exception("Código de segurança inválido.");
            }
            return "1";
        }
    }
}
