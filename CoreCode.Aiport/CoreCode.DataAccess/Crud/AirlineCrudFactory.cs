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
    public class AirlineCrudFactory : CrudFactory
    {

        private readonly AirlineMapper mapper;

        public AirlineCrudFactory()
        {
            mapper = new AirlineMapper();
            dao = SqlDao.GetInstance();
        }


        public override void Create(BaseEntity entity)
        {
            var airline = (Airline)entity;
            var sqlOperation = mapper.GetCreateStatement(airline);
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

        /*public List<T> RetrieveAirlines<T>(BaseEntity entity)
        {
            AirlineMapper airlineMapper = new AirlineMapper();
            var listAirlines = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(airlineMapper.GetRetrieveStatementAirlineById(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = airlineMapper.BuildObjects(lstResult);
                foreach (var c in objs) listAirlines.Add((T)Convert.ChangeType(c, typeof(T)));
            }
            return listAirlines;
        }*/

        public override List<T> RetrieveAll<T>()
        {
            var listAirlines = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listAirlines.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listAirlines;
        }

        public  List<T> RetrieveWaitingAirlines<T>()
        {
            var listAirlines = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.RetrieveWaitingAirlines());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listAirlines.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listAirlines;
        }
        //
        public List<T> RetrieveAcceptedAirlines<T>()
        {
            var listAirlines = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.RetrieveAcceptedAirlines());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listAirlines.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listAirlines;
        }
        public List<T> RetrieveDeniedAirlines<T>()
        {
            var listAirlines = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.RetrieveDeniedAirlines());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listAirlines.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listAirlines;
        }
        public List<T> RetrieveAvailableAirlines<T>()
        {
            var listAirlines = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.RetrieveAvailableAirlines());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listAirlines.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listAirlines;
        }
        public List<T> RetrieveUnvailableAirlines<T>()
        {
            var listAirlines = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.RetrieveUnvailableAirlines());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listAirlines.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listAirlines;
        }

        public List<T> RetrieveAssociatedAirlines<T>(BaseEntity entity)
        {
            var listAirlines = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.RetrieveAssociatedAirlinesStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listAirlines.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listAirlines;
        }
        public List<T> RetrieveRejectedAirlines<T>(BaseEntity entity)
        {
            var listAirlines = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.RetrieveRejectedAirlinesStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listAirlines.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listAirlines;
        }


        public List<T> RetrieveWaitingAirlines<T>(BaseEntity entity)
        {
            var listAirlines = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.RetrieveWaitingAirlinesStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listAirlines.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listAirlines;
        }


        //
        public override void Update(BaseEntity entity)
        {
            var airline = (Airline)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(airline));
        }

        public override void Delete(BaseEntity entity)
        {
            var airline = (Airline)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(airline));
        }

    }
}
