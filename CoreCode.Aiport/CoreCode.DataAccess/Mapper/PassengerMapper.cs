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
    public class PassengerMapper : EntityMapper, IObjectMapper, ISqlStatements
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_FIRST_NAME = "FIRST_NAME";
        private const string DB_COL_SECOND_NAME = "SECOND_NAME";
        private const string DB_COL_FIRST_LAST_NAME = "FIRST_LAST_NAME";
        private const string DB_COL_SECOND_LAST_NAME = "SECOND_LAST_NAME";
        private const string DB_COL_BIRTHDATE = "BIRTHDATE";
        private const string DB_COL_GENRE = "GENRE";
        private const string DB_COL_EMAIL = "EMAIL";
        private const string DB_COL_PASSWORD = "PASSWORD";
        private const string DB_COL_PHONE = "PHONE";
        private const string DB_COL_CIVIL_STATUS = "CIVIL_STATUS";
        private const string DB_COL_STATUS = "STATUS";
        private const string DB_COL_ID_ROL = "ID_ROL";


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var passenger = new Passenger
            {
                ID = GetStringValue(row, DB_COL_ID),
                FirstName = GetStringValue(row, DB_COL_FIRST_NAME),
                SecondName = GetStringValue(row, DB_COL_SECOND_NAME),
                LastName = GetStringValue(row, DB_COL_FIRST_LAST_NAME),
                SecondLastName = GetStringValue(row, DB_COL_SECOND_LAST_NAME),
                BirthDate = GetDateValue(row, DB_COL_BIRTHDATE),
                Genre = GetStringValue(row, DB_COL_GENRE),
                Email = GetStringValue(row, DB_COL_EMAIL),
                Password = GetStringValue(row, DB_COL_PASSWORD),
                Phone = GetStringValue(row, DB_COL_PHONE),
                CivilStatus = GetStringValue(row, DB_COL_CIVIL_STATUS),
                Status = GetBoolValue(row, DB_COL_STATUS),
                Rol = GetStringValue(row, DB_COL_ID_ROL),
            };

            return passenger;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var passenger = BuildObject(row);
                lstResults.Add(passenger);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_CREATE_PASSENGER" };

            var p = (Passenger)entity;

            operation.AddVarcharParam(DB_COL_ID, p.ID);
            operation.AddVarcharParam(DB_COL_FIRST_NAME, p.FirstName);
            operation.AddVarcharParam(DB_COL_SECOND_NAME, p.SecondName);
            operation.AddVarcharParam(DB_COL_FIRST_LAST_NAME, p.LastName);
            operation.AddVarcharParam(DB_COL_SECOND_LAST_NAME, p.SecondLastName);
            operation.AddVarcharParam(DB_COL_BIRTHDATE, p.BirthDate.ToString("dd/MM/yyyy"));

            operation.AddVarcharParam(DB_COL_GENRE, p.Genre);
            operation.AddVarcharParam(DB_COL_EMAIL, p.Email);
            operation.AddVarcharParam(DB_COL_PASSWORD, p.Password);
            operation.AddVarcharParam(DB_COL_PHONE, p.Phone);
            operation.AddVarcharParam(DB_COL_CIVIL_STATUS, p.CivilStatus);
            operation.AddIntParam(DB_COL_STATUS, p.Status ? 1 : 0);
            operation.AddVarcharParam(DB_COL_ID_ROL, p.Rol);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "SP_GET_LIST_PASSENGERS" };
            return operation;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_GET_PASSENGER_BY_ID" };

            var P = (Passenger)entity;
            operation.AddVarcharParam(DB_COL_ID, P.ID);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATE_PASSENGER" };

            var p = (Passenger)entity;

            operation.AddVarcharParam(DB_COL_ID, p.ID);
            operation.AddVarcharParam(DB_COL_FIRST_NAME, p.FirstName);
            operation.AddVarcharParam(DB_COL_SECOND_NAME, p.SecondName);
            operation.AddVarcharParam(DB_COL_FIRST_LAST_NAME, p.LastName);
            operation.AddVarcharParam(DB_COL_SECOND_LAST_NAME, p.SecondLastName);
            operation.AddVarcharParam(DB_COL_BIRTHDATE, p.BirthDate.ToString("dd/MM/yyyy"));

            operation.AddVarcharParam(DB_COL_GENRE, p.Genre);
            operation.AddVarcharParam(DB_COL_EMAIL, p.Email);
            operation.AddVarcharParam(DB_COL_PASSWORD, p.Password);
            operation.AddVarcharParam(DB_COL_PHONE, p.Phone);
            operation.AddVarcharParam(DB_COL_CIVIL_STATUS, p.CivilStatus);
            operation.AddIntParam(DB_COL_STATUS, p.Status ? 1 : 0);
            operation.AddVarcharParam(DB_COL_ID_ROL, p.Rol);

            return operation;
        }
    }
}
