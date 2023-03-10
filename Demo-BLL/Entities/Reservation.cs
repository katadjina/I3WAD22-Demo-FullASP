using Demo_Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_BLL.Entities
{
    public class Reservation : IReservation
    {
        public int Reservation_id { get; set; }
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
        public decimal PrixTotal { get; set; }
        public int nombreAdultes { get; set; }
        public int nombreEnfants { get; set; }
        public int Client_id { get; set; }
        public int Logement_id { get; set; }
        public string nom { get; set; }
        public string DescriptionCourte { get; set; }



    }
}
