using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.Entities.POJO
{
    public class FullStoreInformation : BaseEntity
    {
        public string IDStore { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public string Phone { get; set; }
        public Category Category { get; set; }
        public string IDAirport { get; set; }
        public decimal Rent { get; set; }
        public bool Status { get; set; }
    }
}
