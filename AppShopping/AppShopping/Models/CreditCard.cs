using System;
using System.Collections.Generic;
using System.Text;

namespace AppShopping.Models
{
    public class CreditCard
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Expire { get; set; } // Seguir formato do provedor de pagamento
        public string SecurityCode { get; set; }
        public string Document { get; set; }
    }
}
