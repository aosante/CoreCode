using System.Collections.Generic;
using CoreCode.Entities.POJO;
using DataAccess.Dao;

namespace DataAccess.Crud
{
    public abstract class CrudFactory
    {
        protected SqlDao dao;
        public abstract void Create(BaseEntity entity);
        public abstract T Retrieve<T>(BaseEntity entity);
        public abstract List<T> RetrieveAll<T>();
        public abstract void Update(BaseEntity entity);
        public abstract void Delete(BaseEntity entity);
    }
}