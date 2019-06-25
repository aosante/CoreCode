using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.Entities.POJO
{
    public class RequestAirlineAirportcs : BaseEntity
    {

        public string ID { get; set; }
        public string IDAirline { get; set; }
        public string IDAirport { get; set; }
        public bool Status { get; set; }
        public bool Requested { get; set; }
        public bool Denied { get; set; }


    }
}
