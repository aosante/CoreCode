using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.API.Core
{
    public class ApplicationMessageManagement
    {

        private readonly ApplicationMessagesCrudFactory crudMessage;

        public ApplicationMessageManagement()
        {
            crudMessage = new ApplicationMessagesCrudFactory();
        }

        public void Create(ApplicationMessage message)
        {
            crudMessage.Create(message);
        }

        public List<ApplicationMessage> RetrieveAll()
        {
            return crudMessage.RetrieveAll<ApplicationMessage>();
        }

        public ApplicationMessage RetrieveById(ApplicationMessage message)
        {
            return crudMessage.Retrieve<ApplicationMessage>(message);
        }

        internal void Update(ApplicationMessage message)
        {
            crudMessage.Update(message);
        }
        public void Delete(ApplicationMessage message)
        {
            crudMessage.Delete(message);
        }

    }
}
