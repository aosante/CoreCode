using CoreCode.DataAccess.Mapper;
using CoreCode.Entities.POJO;
using DataAccess.Crud;
using DataAccess.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.DataAccess.Crud
{
    public class AirportCrudFactory : CrudFactory
    {

        private readonly AirportMapper mapper;

        public AirportCrudFactory()
        {
            mapper = new AirportMapper();
            dao = SqlDao.GetInstance();
        }


        public override void Create(BaseEntity entity)
        {
            var airport = (Airport)entity;
            var sqlOperation = mapper.GetCreateStatement(airport);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public List<T> RetrieveStores<T>(string id)
        {
            StoreMapper storeMapper = new StoreMapper();
            var listStores = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(storeMapper.GetRetrieveStatementStoresByAirportById(id));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = storeMapper.BuildObjects(lstResult);
                foreach (var c in objs) listStores.Add((T)Convert.ChangeType(c, typeof(T)));
            }
            return listStores;
        }
        
        public List<T> RetrieveGates<T>(string id)
        {
            GateMapper gateMapper = new GateMapper();
            var listGates = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(gateMapper.GetRetrieveStatementGatesByAirportId(id));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = gateMapper.BuildObjects(lstResult);
                foreach (var c in objs) listGates.Add((T)Convert.ChangeType(c, typeof(T)));
            }
            return listGates;
        }

        public List<T> RetrieveAvailableGates<T>(string id)
        {
            GateMapper gateMapper = new GateMapper();
            var listGates = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(gateMapper.GetRetrieveStatementAvailableGatesByAirportId(id));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = gateMapper.BuildObjects(lstResult);
                foreach (var c in objs) listGates.Add((T)Convert.ChangeType(c, typeof(T)));
            }
            return listGates;
        }
        public List<T> RetrieveUnavailableGates<T>(string id)
        {
            GateMapper gateMapper = new GateMapper();
            var listGates = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(gateMapper.GetRetrieveStatementUnavailableGatesByAirportId(id));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = gateMapper.BuildObjects(lstResult);
                foreach (var c in objs) listGates.Add((T)Convert.ChangeType(c, typeof(T)));
            }
            return listGates;
        }



        public override List<T> RetrieveAll<T>()
        {
            var listAirports = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listAirports.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listAirports;
        }

        public  List<T> RetrieveAvailable<T>()
        {
            var listAirports = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAvailable());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listAirports.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listAirports;
        }

        public List<T> RetrieveUnavailable<T>()
        {
            var listAirports = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveUnavailable());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listAirports.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listAirports;
        }


        public override void Update(BaseEntity entity)
        {
            var airport = (Airport)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(airport));
        }

        public override void Delete(BaseEntity entity)
        {
            var airport = (Airport)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(airport));
        }

        public List<T> RetrieveAssociatedAirports<T>(BaseEntity entity)
        {
            var listAirports = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.RetrieveAssociatedAirportsStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listAirports.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listAirports;
        }
        public List<T> RetrieveNonAssociatedAirports<T>(BaseEntity entity)
        {
            var listAirports = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.RetrieveNonAssociatedAirportsStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listAirports.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listAirports;
        }

        public List<T> RetrievePossibleDestinyAirports<T>(BaseEntity entity)
        {
            var listAirports = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.RetrievePossibleDestinyAirportsStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listAirports.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listAirports;
        }


    }
}
