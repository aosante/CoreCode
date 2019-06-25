using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.API.Core
{
    public class StoreManagement
    {
        private readonly StoreCrudFactory crudStore;

        public StoreManagement()
        {
            crudStore = new StoreCrudFactory();
        }

        public void Create(Store store)
        {
            crudStore.Create(store);
        }

        public List<Store> RetrieveAll()
        {
            return crudStore.RetrieveAll<Store>();
        }

        public Store RetrieveById(Store store)
        {
            return crudStore.Retrieve<Store>(store);
        }

        public void Update(Store store)
        {
            crudStore.Update(store);
        }

        public void Delete(Store store)
        {
            crudStore.Delete(store);
        }
    }
}
