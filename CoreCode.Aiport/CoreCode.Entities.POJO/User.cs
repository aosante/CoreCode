using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.Entities.POJO
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   An user. </summary>
    ///
    /// <remarks>   Celopez, 4/17/2019. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class User: BaseEntity
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Genre { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string CivilStatus { get; set; }
        public bool Status { get; set; }
        public int Rol { get; set; }
        public string AssignedID { get; set; }
    }
}
