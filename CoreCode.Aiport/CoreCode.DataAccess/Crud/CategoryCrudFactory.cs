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
    public class CategoryCrudFactory : CrudFactory
    {
        private readonly CategoryMapper mapper;

        public CategoryCrudFactory()
        {
            mapper = new CategoryMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var category = (Category)entity;
            var sqlOperation = mapper.GetCreateStatement(category);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseEntity entity)
        {
            var category = (Category)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(category));
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
            var listCategories = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listCategories.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listCategories;
        }

        public List<T> RetrieveAvailable<T>()
        {
            var listCategories = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAvailable());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listCategories.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listCategories;
        }

        public List<T> RetrieveUnavailable<T>()
        {
            var listCategories = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveUnavailable());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listCategories.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listCategories;
        }


        public override void Update(BaseEntity entity)
        {
            var category = (Category)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(category));
        }
    }
}
