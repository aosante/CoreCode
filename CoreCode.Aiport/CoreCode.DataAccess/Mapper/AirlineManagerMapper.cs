using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using DataAccess.Dao;
using DataAccess.Mapper;
using System;
using System.Collections.Generic;


namespace CoreCode.DataAccess.Mapper
{
    class AirlineManagerMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_FIRST_NAME = "FIRST_NAME";
        private const string DB_COL_SECOND_NAME = "SECOND_NAME";
        private const string DB_COL_LAST_NAME = "FIRST_LAST_NAME";
        private const string DB_COL_SECOND_LAST_NAME = "SECOND_LAST_NAME";
        private const string DB_COL_BIRTHDATE = "BIRTHDATE";
        private const string DB_COL_GENRE = "GENRE";
        private const string DB_COL_EMAIL = "EMAIL";
        private const string DB_COL_PASSWORD = "PASSWORD";
        private const string DB_COL_PHONE = "PHONE";
        private const string DB_COL_CIVIL_STATUS = "CIVIL_STATUS";
        private const string DB_COL_STATUS = "STATUS";
        private const string DB_COL_ID_ROL= "ID_ROL";
        private const string DB_COL_ID_AIRLINE = "ID_AIRLINE";
        private const string DB_COL_ID_AIRPORT = "ID_AIRPORT";



        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            
            var operation = new SqlOperation { ProcedureName = "sp_CreateAirlineManager" };

            var m = (AirlineManager)entity;
            operation.AddVarcharParam(DB_COL_ID, m.ID);
            operation.AddVarcharParam(DB_COL_FIRST_NAME, m.FirstName);
            operation.AddVarcharParam(DB_COL_SECOND_NAME, m.SecondName);
            operation.AddVarcharParam(DB_COL_LAST_NAME, m.LastName);
            operation.AddVarcharParam(DB_COL_SECOND_LAST_NAME, m.SecondLastName);
            operation.AddDateParam(DB_COL_BIRTHDATE, m.BirthDate);
            operation.AddVarcharParam(DB_COL_GENRE, m.Genre);
            operation.AddVarcharParam(DB_COL_EMAIL, m.Email);
            operation.AddVarcharParam(DB_COL_PASSWORD, m.Password);
            operation.AddVarcharParam(DB_COL_PHONE, m.Phone);
            operation.AddVarcharParam(DB_COL_CIVIL_STATUS, m.CivilStatus);
            operation.AddIntParam(DB_COL_STATUS, m.Status ? 1 : 0);
            operation.AddVarcharParam(DB_COL_ID_ROL, m.Rol);
            operation.AddVarcharParam(DB_COL_ID_AIRLINE, m.AirlineID);  
            return operation;
        }


        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "sp_UpdateAirlineManager" };

            var m = (AirlineManager)entity;
            operation.AddVarcharParam(DB_COL_ID, m.ID);
            operation.AddVarcharParam(DB_COL_FIRST_NAME, m.FirstName);
            operation.AddVarcharParam(DB_COL_SECOND_NAME, m.SecondName);
            operation.AddVarcharParam(DB_COL_LAST_NAME, m.LastName);
            operation.AddVarcharParam(DB_COL_SECOND_LAST_NAME, m.SecondLastName);
            operation.AddDateParam(DB_COL_BIRTHDATE, m.BirthDate);
            operation.AddVarcharParam(DB_COL_GENRE, m.Genre);
            operation.AddVarcharParam(DB_COL_EMAIL, m.Email);
            operation.AddVarcharParam(DB_COL_PASSWORD, m.Password);
            operation.AddVarcharParam(DB_COL_PHONE, m.Phone);
            operation.AddVarcharParam(DB_COL_CIVIL_STATUS, m.CivilStatus);
            operation.AddIntParam(DB_COL_STATUS, m.Status ? 1 : 0);
            operation.AddVarcharParam(DB_COL_ID_ROL, m.Rol);
            operation.AddVarcharParam(DB_COL_ID_AIRLINE, m.AirlineID);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "sp_DeleteAirlineManager" };

            var m = (AirlineManager)entity;
            operation.AddVarcharParam(DB_COL_ID, m.ID);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var AirlineManager = BuildObject(row);
                lstResults.Add(AirlineManager);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            AirlineCrudFactory acf = new AirlineCrudFactory();
            var entity = new Airline
            {
                Id = GetStringValue(row, DB_COL_ID_AIRLINE)
            };

            Airline airline = acf.Retrieve<Airline>(entity);

            var AirlineManager = new AirlineManager
            {
                ID = GetStringValue(row, DB_COL_ID),
                FirstName = GetStringValue(row, DB_COL_FIRST_NAME),
                SecondName = GetStringValue(row, DB_COL_SECOND_NAME),
                LastName = GetStringValue(row, DB_COL_LAST_NAME),
                SecondLastName = GetStringValue(row, DB_COL_SECOND_LAST_NAME),
                BirthDate =  Convert.ToDateTime(GetDateValue(row, DB_COL_BIRTHDATE)),
                Genre = GetStringValue(row, DB_COL_GENRE),
                Email = GetStringValue(row, DB_COL_EMAIL),
                Password = GetStringValue(row, DB_COL_PASSWORD),
                Phone = GetStringValue(row, DB_COL_PHONE),
                CivilStatus = GetStringValue(row, DB_COL_CIVIL_STATUS),
                Status = Convert.ToBoolean(GetIntValue(row, DB_COL_STATUS)),
                Rol = GetStringValue(row, DB_COL_ID_ROL),
                AirlineID = GetStringValue(row, DB_COL_ID_AIRLINE),
                AirlineName = airline.Comercial_name
            };

            return AirlineManager;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "sp_GetAirlineManagerById" };

            var m = (AirlineManager)entity;
            operation.AddVarcharParam(DB_COL_ID, m.ID);

            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "sp_GetAirlineManagers" };
            return operation;
        }
        public SqlOperation GetRetrieveAllManagersStatement(string airportID)
        {
            var operation = new SqlOperation { ProcedureName = "sp_GetRespectiveAirlineManagers" };
            operation.AddVarcharParam(DB_COL_ID_AIRPORT, airportID);
            return operation;
        }

        public SqlOperation GetRetrieveAirlineAdminByAirlineIdStatement(BaseEntity entity)
        {
            var m = (AirlineManager)entity;
            var operation = new SqlOperation { ProcedureName = "RET_ADMINAIRLINE_BY_AIRLINE_ID" };
            operation.AddVarcharParam(DB_COL_ID, m.ID);
            return operation;
        }
    }
}
