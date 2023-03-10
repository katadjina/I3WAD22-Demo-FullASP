using Demo_Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DAL.Entities
{
    public class Client : IClient
    {
        //INTEGER
        public int Client_Id { get; set; }
        //NCHAR(10)
        public string email { get; set; }
        //NCHAR(55)
        public string pass { get; set; }
        //NCHAR(20)
        public string nom { get; set; }
        //NCHAR(20)
        public string prenom { get; set; }
        //NCHAR(10)
        public int telephone { get; set; }
        //NCHAR(10)
        public string pays { get; set; }
    }
}
