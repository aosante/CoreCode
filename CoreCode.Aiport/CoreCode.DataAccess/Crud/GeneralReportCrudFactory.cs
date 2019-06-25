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
    public class GeneralReportCrudFactory : CrudFactory
    {
        private readonly string GatesGainColName = "GATE_TARIFF";
        private readonly string RunwayGainColName = "RUNWAY_TARIFF";
        private readonly string StoreNameColName = "NAME";
        private readonly string StoreRentColName = "RENT";
        private readonly string StoreIdColName = "ID";
        private readonly string StoreCategoryIdColName = "ID_CATEGORY";
        private readonly string StoreDescriptionColName = "STORE_DESCRIPTION";
        private readonly string StoreStatusColName = "STORE_STATUS";


        public readonly GeneralReportMapper GeneralReportMapperInstance;
        public readonly StoreMapper StoreMapperInstance;
        public readonly GateMapper GateMapperInstance;
        public readonly AirlineMapper AirlineMapperInstance;
        public GeneralReportCrudFactory()
        {
            GeneralReportMapperInstance = new GeneralReportMapper();
            StoreMapperInstance = new StoreMapper();
            GateMapperInstance = new GateMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var customer= (GeneralReportAirport)entity;
            //var sqlOperation = GeneralReportMapper.GetCreateStatement(customer);
            //dao.ExecuteProcedure(sqlOperation);
        }

        public T Retrieve<T>(string airportId)
        {
            var lstResult = dao.ExecuteDataTableCollectionQuery(GeneralReportMapperInstance.GetRetrieveStatement(airportId));
            
            if (lstResult.Count > 0)
            {
                var airportStoresTable = lstResult[0];
                var airlineTable = lstResult[1];
                var gateTable = lstResult[2];
                var flightList = lstResult[3];
                List<FullStoreInformation> stores = airportStoresTable.AsEnumerable().Select(row => new FullStoreInformation
                {
                    Name = row.Field<string>(StoreNameColName),
                    IDStore = row.Field<string>(StoreIdColName),
                    Category = new Category
                    {
                        Description = row.Field<string>(StoreDescriptionColName),
                        IDCategory = row.Field<string>(StoreCategoryIdColName),
                        Status = row.Field<bool>(StoreStatusColName)
                    },
                    ManagerName = "Cesar Lopez",
                    Rent = row.Field<decimal>(StoreRentColName)
                }).ToList();
                List<Gate> gates = gateTable.AsEnumerable().Select(row => GateMapperInstance.BuildObjectFromDataRow(row)).ToList();
                List<Airline> airlines = airlineTable.AsEnumerable().Select(row => AirlineMapperInstance.BuildObjectFromDataRow(row)).ToList();
                List<Flight> flights = new List<Flight>();
                var reportResult = new GeneralReportAirport
                {
                    Airlines = airlines,
                    Flights = flights,
                    Gates = gates,
                    Stores = stores
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
