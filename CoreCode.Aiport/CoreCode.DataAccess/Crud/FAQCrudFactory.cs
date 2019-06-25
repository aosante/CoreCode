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
    public class FAQCrudFactory : CrudFactory
    {
        private readonly FAQMapper mapper;

        public FAQCrudFactory()
        {
            mapper = new FAQMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var Faq = (FAQ)entity;
            var sqlOperation = mapper.GetCreateStatement(Faq);
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
            var listFaqs = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listFaqs.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listFaqs;
        }
        public  List<T> RetrieveAvailable<T>()
        {
            var listFaqs = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAvailable());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listFaqs.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listFaqs;
        }
        public List<T> RetrieveUnavailable<T>()
        {
            var listFaqs = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveUnavailable());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) listFaqs.Add((T)Convert.ChangeType(c, typeof(T)));
            }

            return listFaqs;
        }

        public override void Update(BaseEntity entity)
        {
            var Faq = (FAQ)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(Faq));
        }

        public override void Delete(BaseEntity entity)
        {
            var Faq = (FAQ)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(Faq));
        }
    }
}
