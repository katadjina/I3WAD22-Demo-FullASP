using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP.Models.LogementViewModels
{
    public class LogementSearch
    {
        
        public DateTime date { get; set; }
        public DateTime date_deb { get; set; }
        public DateTime date_fin { get; set; }

        public IEnumerable<LogementListItem> logements { get; set; }

}
}
