using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreCode.DataAccess.Mapper;
using CoreCode.Entities.POJO;
using DataAccess.Crud;
using DataAccess.Dao;

namespace CoreCode.DataAccess.Crud
{
    public class UserHistoryCrudFactory : CrudFactory
    {
        private readonly UserHistoryMapper _mapper;

        public UserHistoryCrudFactory()
        {
            _mapper = new UserHistoryMapper();
            dao = SqlDao.GetInstance();
        }
        public override void Create(BaseEntity entity)
        {
            var customer= (UserHistory)entity;
            var sqlOperation = _mapper.GetCreateStatement(customer);
            dao.ExecuteProcedure(sqlOperation);
        }

        public T RetrieveByUserId<T>(string userId)
        {
            var lstResult = dao.ExecuteQueryProcedure(_mapper.GetUserHistoryByUserId(userId));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = _mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
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
