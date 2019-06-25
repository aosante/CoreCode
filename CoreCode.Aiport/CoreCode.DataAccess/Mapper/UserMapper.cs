using CoreCode.Entities.POJO;
using DataAccess.Dao;
using DataAccess.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.DataAccess.Mapper
{
    //clase creada para funcionalidad del login
    public class UserMapper : EntityMapper, IObjectMapper, ISqlStatements
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COLD_NAME = "FIRST_NAME";
        private const string DB_COLD_SECOND_NAME = "SECOND_NAME";
        private const string DB_COLD_LAST_NAME = "FIRST_LAST_NAME";
        private const string DB_COLD_SECOND_LAST_NAME = "SECOND_LAST_NAME";
        private const string DB_COLD_BIRTHDATE = "BIRTHDATE";
        private const string DB_COLD_GENRE = "GENRE";
        private const string DB_COL_EMAIL = "EMAIL";
        private const string DB_COL_PASSWORD = "PASSWORD";
        private const string DB_COL_PHONE = "PHONE";
        private const string DB_COL_CIVIL_STATUS = "CIVIL_STATUS";
        private const string DB_COL_STATUS = "STATUS";
        private const string DB_COL_ID_ROL = "ID_ROL";
        private const string DB_COL_ID_ASSIGNED = "ID_ASSIGNED";
        //hace una instancia del pojo de user
        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var User = new User
            {
                ID = GetStringValue(row, DB_COL_ID),
                FirstName =  GetStringValue(row,DB_COLD_NAME),
                SecondName = GetStringValue(row,DB_COLD_SECOND_NAME),
                LastName=  GetStringValue(row, DB_COLD_LAST_NAME), 
                SecondLastName = GetStringValue(row,DB_COLD_SECOND_LAST_NAME),
                BirthDate = GetDateValue(row, DB_COLD_BIRTHDATE),
                Genre = GetStringValue(row, DB_COLD_GENRE),
                Email = GetStringValue(row, DB_COL_EMAIL),
                Password = GetStringValue(row, DB_COL_PASSWORD),
                Phone = GetStringValue(row, DB_COL_PHONE),
                CivilStatus = GetStringValue(row, DB_COL_CIVIL_STATUS),
                Status = GetBoolValue(row, DB_COL_STATUS),
                Rol = GetIntValue(row, DB_COL_ID_ROL),
                AssignedID= GetStringValue(row, DB_COL_ID_ASSIGNED)
            };

            return User;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var User = BuildObject(row);
                lstResults.Add(User);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "SP_GETUSERS" };
            return operation;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "sp_GetUserByUserNameAndPassword" };
            var userEntity = (User)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, userEntity.Email);
            operation.AddVarcharParam(DB_COL_PASSWORD, userEntity.Password);
            return operation;
        }

        public SqlOperation GetRetrieveStatementByUser(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "sp_GetUserByUserName" };
            var userEntity = (User)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, userEntity.Email);
            return operation;
        }

        public SqlOperation GetRetrieveStatementByUserOrId(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "sp_GetUserByUserNameOrId" };
            var userEntity = (User)entity;
            operation.AddVarcharParam(DB_COL_EMAIL, userEntity.Email);
            operation.AddVarcharParam(DB_COL_ID, userEntity.ID);
            return operation;
        }


        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation UpdatePasswordAdminAirport(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATEPSWDADMINAIRPORT" };

            var user = (User)entity;

            operation.AddVarcharParam(DB_COL_ID, user.ID);
            operation.AddVarcharParam(DB_COL_PASSWORD, user.Password);
            //operation.AddVarcharParam(DB_COL_ANSWER, user);

            return operation;
        }

        public SqlOperation UpdatePasswordAdminAirline(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATEPSWDADMINAIRLINE" };
            var user = (User)entity;

            operation.AddVarcharParam(DB_COL_ID, user.ID);
            operation.AddVarcharParam(DB_COL_PASSWORD, user.Password);
            return operation;
        }

        public SqlOperation GetUpdateGeneralAdminStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "sp_UpdateGeneralAdmin" };
            var c = (User)entity;
            operation.AddVarcharParam(DB_COL_ID, c.ID);
            return operation;
        }

        public SqlOperation GetUpdateAirportAdmin(BaseEntity entity)
        {
            return CommonUpdateUser("sp_UpdateAirportAdmin", entity);
        }

        private SqlOperation CommonUpdateUser(string procName, BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = procName };
            var c = (User)entity;
            operation.AddVarcharParam(DB_COL_ID, c.ID);
            operation.AddVarcharParam(DB_COLD_NAME, c.FirstName);
            operation.AddVarcharParam(DB_COLD_SECOND_NAME, c.SecondName);
            operation.AddVarcharParam(DB_COLD_LAST_NAME, c.LastName);
            operation.AddVarcharParam(DB_COLD_SECOND_LAST_NAME, c.SecondLastName);
            operation.AddDateParam(DB_COLD_BIRTHDATE, c.BirthDate);
            operation.AddVarcharParam(DB_COLD_GENRE, c.Genre);
            operation.AddVarcharParam(DB_COL_PHONE, c.Phone);
            operation.AddVarcharParam(DB_COL_CIVIL_STATUS, c.CivilStatus);
            operation.AddVarcharParam(DB_COL_EMAIL, c.Email);
            return operation;
        }

        public SqlOperation GetUpdateAirlineAdmin(BaseEntity entity)
        {
            return CommonUpdateUser("sp_UpdateAirlineAdmin", entity);
        }

        public SqlOperation GetUpdatePassengerAdmin(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "sp_UpdateAirlineAdmin" };
            var c = (User)entity;
            operation.AddVarcharParam(DB_COL_ID, c.ID);
            return operation;
        }
    }
}
