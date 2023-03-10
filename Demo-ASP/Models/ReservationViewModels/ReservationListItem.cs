using Demo_ASP.Models.ClientViewModels;
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
    public class ReservationListItem
    {

        public int Reservation_id { get; set; }
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
        public decimal prix { get; set; }
        public int nombreAdultes { get; set; }
        public int nombreEnfants { get; set; }
        public int Client_id { get; set; }
        public int Logement_id { get; set; }
        public LogementDetails logement { get; set; }
        public string nom { get; set; }
        public string DescriptionCourte { get; set; }


    }
}
