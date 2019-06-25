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
    public class FlightCrudFactory : CrudFactory
    {

        private readonly FlightMapper mapper;

        public FlightCrudFactory()
        {
            mapper = new FlightMapper();
            dao = SqlDao.GetInstance();
        }


        public override void Create(BaseEntity entity)
        {
            var flight = (Flight)entity;
            var sqlOperation = mapper.GetCreateStatement(flight);
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

        public override List<T> RetrieveAll<T>()
        {
            var listFlights = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listFlights.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listFlights;
        }

        public  List<T> RetrieveOnTime<T>()
        {
            var listFlights = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetOnTimeFlight());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listFlights.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listFlights;
        }

        public List<T> RetrieveCanceled<T>()
        {
            var listFlights = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetCanceledFlight());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listFlights.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listFlights;
        }

        public List<T> RetrieveDelay<T>()
        {
            var listFlights = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetDelayFlight());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listFlights.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listFlights;
        }



        public override void Update(BaseEntity entity)
        {
            var flight = (Flight)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(flight));
        }

        public override void Delete(BaseEntity entity)
        {
            var flight = (Flight)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(flight));
        }

    }
}
