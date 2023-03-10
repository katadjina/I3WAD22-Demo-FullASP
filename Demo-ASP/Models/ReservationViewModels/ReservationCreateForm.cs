using Demo_ASP.Models.LogementViewModels;
using Demo_BLL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP.Models.ReservationViewModels
{
    public class ReservationCreateForm
    {
        // public int Reservation_id { get; set; }
        [Required]
        [DisplayName("Check In : ")]
        public DateTime checkIn { get; set; }
        [Required]
        [DisplayName("Check Out : ")]
        public DateTime checkOut { get; set; }
       
        [Required]
        [Range(0, 10)] // at least 1 adult
        [DisplayName("Nombre d'adultes : ")]
        public int nombreAdultes { get; set; }
        [Required]
        [Range(0, 10)]
        [DisplayName("Nombre d'enfants : ")]
        public int nombreEnfants { get; set; }
        public int Client_id { get; set; }
        public int Logement_id { get; set; }
        public LogementDetails logement { get; set; }


    }
}
