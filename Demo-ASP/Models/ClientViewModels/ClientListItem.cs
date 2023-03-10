using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP.Models.ClientViewModels
{
    public class ClientListItem
    {
        [DisplayName("Identifiant")]
        [ScaffoldColumn(false)]
        public int Client_id { get; set; }
        [DisplayName("Nom de famille :")]
        public string nom { get; set; }
        [DisplayName("Prénom :")]
        public string prenom { get; set; }
    }
}
