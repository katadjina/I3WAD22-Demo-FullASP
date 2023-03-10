using Demo_ASP.Models.LogementViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP.Models.ReservationViewModels
{
    public class ReservationEditForm
    {
        public int Reservation_id { get; set; }
        [Required]
        [DisplayName("Check In : ")]
        public DateTime checkIn { get; set; }
        [Required]
        [DisplayName("Check Out : ")]
        public DateTime checkOut { get; set; }
        [Required]
        [DisplayName("Prix total : ")]
        public int prix { get; set; }
        [Required]
        [DisplayName("Nombre d'adultes : ")]
        public int nombreAdultes { get; set; }
        [Required]
        [DisplayName("Nombre d'enfants : ")]
        public int nombreEnfants { get; set; }
        public int Client_id { get; set; }
        public int Logement_id { get; set; }
        public LogementDetails logement { get; set; }
    }
}
