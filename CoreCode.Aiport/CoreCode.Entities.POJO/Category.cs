using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.Entities.POJO
{
    public class Category : BaseEntity
    {
        public string IDCategory { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        
    }
}
