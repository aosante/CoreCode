using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreCode.Entities.POJO.Enums;

namespace CoreCode.Entities.POJO
{
    public class UserHistory : BaseEntity
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public DateTime ActionDate { get; set; }
        public UserActionType ActionType { get; set; }
    }
}
