using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.Entities.POJO
{
    public class Store : BaseEntity
    {
        public string IDStore { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public string Phone { get; set; }
        public string IDCategory { get; set; } 
        public string IDAirport { get; set; }
        public decimal Rent { get; set; }
        public bool Status { get; set; }
    }
}
