using Demo_ASP.Models.ClientViewModels;
using Demo_BLL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP.Models.LogementViewModels
{
    public class LogementListItem
    {

        [DisplayName("Identifiant : ")]
        [ScaffoldColumn(false)]
        public int Logement_id { get; set; }
        [DisplayName("Logement :")]

        public string nom { get; set; }
        [DisplayName("Adresse :")]

        public string rue { get; set; }
        [DisplayName("Nmbr Pieces :")]

        public int nombrePiece { get; set; }
        [DisplayName("Description :")]

        public string Description { get; set; }
        [DisplayName("Prix :")]

        public string Prix { get; set; }
        [DisplayName("Proprietaire :")]
        public int Client_id { get; set; }
        public ClientListItem Client { get; set; }
        public string email { get; set; }



    }
}
