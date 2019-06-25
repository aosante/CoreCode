using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.Entities.POJO
{
    public class Airline : BaseEntity
    {
        public String Id {get; set; }
        public String Comercial_name {get; set; }
        public String Business_name {get; set; }

        public string FormattedYear => Creation_year.ToString("yyyy-MM-dd");

        public DateTime Creation_year{get; set; }
        

        public String Description {get; set; }
        public String Email {get; set;}
        public bool Status {get; set;}
        public String Request { get; set; }
    }
}
