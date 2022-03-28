using AppShopping.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppShopping.Services
{
    public class EstablishmentService
    {
        public List<Establishment> GetEstablishment()
        {
            var establishments = new List<Establishment>()
            {
                new Establishment()
                {
                    Id = 1,
                    Logo = "",
                    Name = "Renner",
                    Description = "A Lojas Renner S.A é uma rede de lojas de departamento brasileira",
                    Address = "3 Andar - Loja 10 - Setor Norte",
                    Phone = "(61) 3333-3333",
                }
            };
            return establishments;
        }
    }
}
