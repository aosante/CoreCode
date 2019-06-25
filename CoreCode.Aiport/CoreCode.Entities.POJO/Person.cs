using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.Entities.POJO
{
    public class Person : BaseEntity
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public string Genre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string CivilStatus { get; set; }
        public bool Status { get; set; }
        public string Rol { get; set; }
        
        public string FormattedYear => BirthDate.ToString("yyyy-MM-dd");
    }
}
