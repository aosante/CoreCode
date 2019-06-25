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
    public class StoreCrudFactory : CrudFactory
    {

        private readonly StoreMapper mapper;

        public StoreCrudFactory()
        {
            mapper = new StoreMapper();
            dao = SqlDao.GetInstance();
        }



        public override void Create(BaseEntity entity)
        {
            var store = (Store)entity;
            var sqlOperation = mapper.GetCreateStatement(store);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var store = (Store)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(store));
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
            var listStores = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listStores.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listStores;
        }

        public override void Update(BaseEntity entity)
        {
            var store = (Store)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(store));
        }
    }
}
