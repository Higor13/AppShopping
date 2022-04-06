using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppShopping.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)] // informa que o SessionGroup é um obj e a forma que vai serializar
    public class SessionGroup : List<String>
    {
        [JsonProperty] // O nome é uma propriedade
        public string Name { get; set; } // Para legendado e dublado
        [JsonProperty]
        String[] Items
        { // Para a lista com todos os horários de cada um dos tipos
            get
            {
                return this.ToArray(); // Importante para o Json colocar os valores(a lista) em Items
            }
            set
            {
                if (value != null)
                    this.AddRange(value); // Adc os items (array de strings) à lista
            }
        }

        public SessionGroup()
        {

        }
        public SessionGroup(string name, List<String> list) : base(list)
        {
            Name = name;
        }
    }
}
