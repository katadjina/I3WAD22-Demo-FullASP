using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP.Handlers
{
    public class CurrentUser
    {
        public int IdUser { get; set; }
        public string Email { get; set; }
        public DateTime LastConnection { get; set; }
    }
}
