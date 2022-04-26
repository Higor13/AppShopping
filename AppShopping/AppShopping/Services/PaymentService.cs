using AppShopping.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppShopping.Services
{
    public class PaymentService
    {
        public int SendPayment(CreditCard creditCard) // Enviar dados do cartão para empresa que intermedia o pagamento
        {
            if (creditCard.SecurityCode == "111")
            {
                throw new Exception("Código de segurança inválido.");
            }
            return 1;
        }
    }
}
