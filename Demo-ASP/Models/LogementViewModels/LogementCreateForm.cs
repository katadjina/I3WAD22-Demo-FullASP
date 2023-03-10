using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP.Models.LogementViewModels
{
    public class LogementCreateForm
    {
       
        [Required]
        [MinLength(1)]
        [MaxLength(55)]
        [DisplayName("Nom : ")]
        public string nom { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(55)]
        [DisplayName("Rue : ")]
        public string rue { get; set; }
        [Required]
        [DisplayName("Numero : ")]
        public int numero { get; set; }
        [Required]
        [DisplayName("Code Postal : ")]
        public int codePostal { get; set; }
        
        [Required]
        [DisplayName("Pays : ")]
        public string pays { get; set; }

        [Required]
        [DisplayName("Nombre De Pieces : ")]
        public int nombrePiece { get; set; }

        [Required]
        [DisplayName("Nombre De Chambres : ")]
        public int nombreChambre { get; set; }
        
        [Required]
        [DisplayName("Nombre De WC : ")]
        public int nombreWC { get; set; }

        [Required]
        [DisplayName("Nombre De Douche : ")]
        public int nombreDouche { get; set; }


        [Required]
        [DisplayName("Capacite : ")]
        public int capacite { get; set; }

        [Required]
        [DisplayName("Prix par Jour : ")]
        public string Prix { get; set; }

        [Required]
        [DisplayName("Aircondition : ")]
        public bool air { get; set; }

        [Required]
        [DisplayName("WIFI : ")]
        public bool wifi { get; set; }

        [Required]
        [DisplayName("animaux Admis : ")]
        public bool animaux { get; set; }
        [Required]
        [DisplayName("MiniBar : ")]
        public bool minibar { get; set; }
        [Required]
        [DisplayName("MiniBar : ")]
        public bool piscine { get; set; }

        [Required]
        [DisplayName("Voiturier : ")]
        public bool voiturier{ get; set; }

        [Required]
        [DisplayName("Room Service : ")]
        public bool roomService { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(4000)]
        [DisplayName("Description : ")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        




        public int Client_id { get; set; }
        public DateTime date_add { get; set; }
        public string email { get; set; }


    }
}
