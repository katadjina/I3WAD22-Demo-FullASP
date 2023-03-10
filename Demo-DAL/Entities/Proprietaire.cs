using Demo_Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DAL.Entities
{
    public class Proprietaire : IProprietaire
    {
        public int Client_id { get; set; }
    }
}
