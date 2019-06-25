using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.Entities.POJO
{
    public class Gate : BaseEntity
    {
        public string IDAirport { get; set; }
        public string IDGate { get; set; }
        public int Number { get; set; }
        public bool Status { get; set; }
    }
}
