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
    public class LoginCrudFactory: CrudFactory
    {
        private readonly UserMapper mapper;

        public LoginCrudFactory()
        {
            mapper = new UserMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
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

        public bool UserExists(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveStatementByUser(entity));
            if (lstResult.Count > 0)
            {
                return true;
            }
            return false;
        }

        public T UserExistsByUserNameOrId<T>(BaseEntity entity)
        {
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveStatementByUserOrId(entity));
            var dic = new Dictionary<string, object>();
            if (lstResult.Count <= 0) return default(T);
            dic = lstResult[0];
            var objs = mapper.BuildObject(dic);
            return (T)Convert.ChangeType(objs, typeof(T));
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstUsers = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetrieveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs) lstUsers.Add((T)Convert.ChangeType(c, typeof(T)));
            }
            return lstUsers;
        }

        public override void Update(BaseEntity entity)
        {
            var currentUser = (User)entity;
            switch (currentUser.Rol)
            {
               case 2:
                   dao.ExecuteProcedure(mapper.GetUpdateAirportAdmin(currentUser));
                   break;
                case 3:
                    dao.ExecuteProcedure(mapper.GetUpdateAirlineAdmin(currentUser));
                    break;
                case 4:
                    dao.ExecuteProcedure(mapper.GetUpdatePassengerAdmin(currentUser));
                    break;
                default:
                    break;
            }
            
        }

        public  void UpdatePsswdAdminAirport(BaseEntity entity)
        {
            var user = (User)entity;
            dao.ExecuteProcedure(mapper.UpdatePasswordAdminAirport(user));
        }

        public  void  UpdatePsswdAdminAirline(BaseEntity entity)
        {
            var user = (User)entity;
            dao.ExecuteProcedure(mapper.UpdatePasswordAdminAirline(user));
        }
    }
}
