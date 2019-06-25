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
    public class AirlineManagerCrudFactory : CrudFactory
    {
        private readonly AirlineManagerMapper mapper;

        public AirlineManagerCrudFactory()
        {
            mapper = new AirlineManagerMapper();
            dao = SqlDao.GetInstance();
        }


        public override void Create(BaseEntity entity)
        {
            var manager = (AirlineManager)entity;
            var sqlOperation = mapper.GetCreateStatement(manager);
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


        public T RetrieveAirlineAdminByAirlineId<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAirlineAdminByAirlineIdStatement(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public List<T> RetrieveAllManagers<T>(string airportID)
        {
            var lstManager = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllManagersStatement(airportID));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) lstManager.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return lstManager;
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstManager = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) lstManager.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return lstManager;
        }

        public override void Update(BaseEntity entity)
        {
            var manager = (AirlineManager)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(manager));
        }

        public override void Delete(BaseEntity entity)
        {
            var manager = (AirlineManager)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(manager));
        }
    }
}
