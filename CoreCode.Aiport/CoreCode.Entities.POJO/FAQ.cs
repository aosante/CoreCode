using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.Entities.POJO
{
   public class FAQ :BaseEntity
    {

        public string ID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool Status { get; set; }
    }
}
