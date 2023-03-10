using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP.Models.LogementViewModels
{
    public class LogementDetails
    {
        public int Logement_id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        [DisplayName("Nom : ")]
        public string nom { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        [DisplayName("Adresse : ")]
        public string rue { get; set; }
        [Required]
        [DisplayName("Nombre de piece : ")]
        public int nombrePiece { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(4000)]
        [DisplayName("Description : ")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [DisplayName("Prix : ")]
        public string Prix { get; set; }
        [DisplayName("Proprietaire : ")]
        public int Client_id { get; set; }
        public string email { get; set; }   

    }
}
