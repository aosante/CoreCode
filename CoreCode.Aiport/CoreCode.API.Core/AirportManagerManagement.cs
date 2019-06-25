using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using System.Collections.Generic;
using CoreCode.API.Core.Helpers;

namespace CoreCode.API.Core
{
    public class AirportManagerManagement
    {
        private readonly AirportManagerCrudFactory crudAirportManager;
            
        public AirportManagerManagement()
        {
            crudAirportManager = new AirportManagerCrudFactory();
        }

        public void Create(AirportManager manager)
        {
            manager.Password = EncryptionHelper.GetEncryptedMd5Value(manager.Password);
            crudAirportManager.Create(manager);
        }

        public List<AirportManager> RetrieveAll()
        {
            return crudAirportManager.RetrieveAll<AirportManager>();
        }

        public AirportManager RetrieveById(AirportManager manager)
        {
            return crudAirportManager.Retrieve<AirportManager>(manager);
        }
        public AirportManager RetrieveAdminAirportByAirportId(AirportManager manager)
        {
            return crudAirportManager.RetrieveAdminAirportByAirportId<AirportManager>(manager);
        }

        public void Update(AirportManager manager)
        {
            crudAirportManager.Update(manager);
        }

        public void Delete(AirportManager manager)
        {
            crudAirportManager.Delete(manager);
        }
    }
}
