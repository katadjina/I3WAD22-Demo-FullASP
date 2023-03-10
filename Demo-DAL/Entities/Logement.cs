using Demo_Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DAL.Entities
{
    public class Logement : ILogement
    {
        public int Logement_id { get; set; }
        public string nom { get; set; }
        public string rue { get; set; }
        public int nombrePieces { get; set; }
        public string DescriptionCourte { get; set; }
        public string Prix { get; set; }
        public int Client_id { get; set; }
        public DateTime date_add { get; set; }
        public string email { get; set; }




    }
}
