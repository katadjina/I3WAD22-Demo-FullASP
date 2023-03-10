using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP.Models.ClientViewModels
{
    public class ClientCreateForm
    {
        [DisplayName("Identifiant")]
        [ScaffoldColumn(false)]
        public int Client_id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        [DisplayName("Nom de famille : ")]
        public string nom { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        [DisplayName("Prénom : ")]
        public string prenom { get; set; }
        [Required]
        [MaxLength(255)]
        [MinLength(5)]
        [EmailAddress]
        [DisplayName("Adresse e-mail : ")]
        public string email { get; set; }
        [Required]
        [MaxLength(32)]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [DisplayName("Mot de passe : ")]
        public string pass { get; set; }
        [Required]
        [MaxLength(32)]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Compare(nameof(pass))]
        [DisplayName("Confirmez le mot de passe : ")]
        public string confirmPass { get; set; }
        [Required]
        [DisplayName("Telephone : ")]
        public int telephone { get; set; }
        [Required]
       // [DataType(DataType.MultilineText)]
        [MaxLength(55)]
        [DisplayName("pays : ")]
        public string pays { get; set; }
    }
}
