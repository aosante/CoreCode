using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreCode.DataAccess.Mapper;
using CoreCode.Entities.POJO;
using CoreCode.Entities.POJO.Dashboard;
using DataAccess.Crud;
using DataAccess.Dao;

namespace CoreCode.DataAccess.Crud
{
    public class AirlineReportCrudFactory : CrudFactory
    {
        private readonly string GatesGainColName = "GATE_TARIFF";
        private readonly string RunwayGainColName = "RUNWAY_TARIFF";
        private readonly string StoreNameColName = "NAME";
        private readonly string StoreRentColName = "RENT";
        private readonly string StoreIdColName = "ID";
        private readonly string StoreCategoryIdColName = "ID_CATEGORY";
        private readonly string StoreDescriptionColName = "STORE_DESCRIPTION";
        private readonly string StoreStatusColName = "STORE_STATUS";
        
        public readonly AirlineReportMapper GeneralReportMapperInstance;
        
        
        public AirlineReportCrudFactory()
        {
            GeneralReportMapperInstance = new AirlineReportMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var customer= (GeneralReportAirport)entity;
            //var sqlOperation = GeneralReportMapper.GetCreateStatement(customer);
            //dao.ExecuteProcedure(sqlOperation);
        }

        public T Retrieve<T>(string airlineId)
        {
            var lstResult = dao.ExecuteDataTableCollectionQuery(GeneralReportMapperInstance.GetRetrieveStatement(airlineId));
            
            if (lstResult.Count > 0)
            {
                var airportStoresTable = lstResult[0];
                var airlineTable = lstResult[1];
                var gateTable = lstResult[2];
                var flightList = lstResult[3];
                List<Flight> flights = new List<Flight>();
                var reportResult = new AirlineReport()
                {
                    
                };
                return (T)Convert.ChangeType(reportResult, typeof(T));
            }
            return default(T);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
