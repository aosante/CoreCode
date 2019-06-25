using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using DataAccess.Dao;
using DataAccess.Mapper;
using System;
using System.Collections.Generic;


namespace CoreCode.DataAccess.Mapper
{
    class AirportManagerMapper : EntityMapper, ISqlStatements, IObjectMapper
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
        private const string DB_COL_ID_ROL= "ID_ROL";
        private const string DB_COL_ID_AIRPORT = "ID_AIRPORT";



        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            //este stored proc inserta en la tabla persona y en la tabla admin aeropuerto
            var operation = new SqlOperation { ProcedureName = "sp_CreateAirportManager" };

            var m = (AirportManager)entity;

            operation.AddVarcharParam(DB_COL_ID, m.ID);
            operation.AddVarcharParam(DB_COL_FIRST_NAME, m.FirstName);
            operation.AddVarcharParam(DB_COL_SECOND_NAME, m.SecondName);
            operation.AddVarcharParam(DB_COL_FIRST_LAST_NAME, m.LastName);
            operation.AddVarcharParam(DB_COL_SECOND_LAST_NAME, m.SecondLastName);
            operation.AddDateParam(DB_COL_BIRTHDATE, m.BirthDate);

            operation.AddVarcharParam(DB_COL_GENRE, m.Genre);
            operation.AddVarcharParam(DB_COL_EMAIL, m.Email);
            operation.AddVarcharParam(DB_COL_PASSWORD, m.Password);
            operation.AddVarcharParam(DB_COL_PHONE, m.Phone);
            operation.AddVarcharParam(DB_COL_CIVIL_STATUS, m.CivilStatus);
            operation.AddIntParam(DB_COL_STATUS, m.Status ? 1 : 0);
            operation.AddVarcharParam(DB_COL_ID_ROL, m.Rol);
            operation.AddVarcharParam(DB_COL_ID_AIRPORT, m.AirportID);

            return operation;
        }




        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            //este proc hace el update en la tabla persona y en la tabla admin de aeropuerto
            var operation = new SqlOperation { ProcedureName = "sp_UpdateAirportManager" };

            var m = (AirportManager)entity;
            operation.AddVarcharParam(DB_COL_ID, m.ID);
            operation.AddVarcharParam(DB_COL_FIRST_NAME, m.FirstName);
            operation.AddVarcharParam(DB_COL_SECOND_NAME, m.SecondName);
            operation.AddVarcharParam(DB_COL_FIRST_LAST_NAME, m.LastName);
            operation.AddVarcharParam(DB_COL_SECOND_LAST_NAME, m.SecondLastName);
            operation.AddVarcharParam(DB_COL_BIRTHDATE, m.BirthDate.ToString("dd/MM/yyyy"));

            operation.AddVarcharParam(DB_COL_GENRE, m.Genre);
            operation.AddVarcharParam(DB_COL_EMAIL, m.Email);
            operation.AddVarcharParam(DB_COL_PASSWORD, m.Password);
            operation.AddVarcharParam(DB_COL_PHONE, m.Phone);
            operation.AddVarcharParam(DB_COL_CIVIL_STATUS, m.CivilStatus);
            operation.AddIntParam(DB_COL_STATUS, m.Status ? 1 : 0);
            operation.AddVarcharParam(DB_COL_ID_ROL, m.Rol);
            operation.AddVarcharParam(DB_COL_ID_AIRPORT, m.AirportID);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            //borra de la tabla persona y de la tabla admin de aeropuerto
            var operation = new SqlOperation { ProcedureName = "sp_DeleteAirportManager" };

            var m = (AirportManager)entity;
            operation.AddVarcharParam(DB_COL_ID, m.ID);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var AirportManager = BuildObject(row);
                lstResults.Add(AirportManager);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            AirportCrudFactory acf = new AirportCrudFactory();
            var entity = new Airport
            {
                ID = GetStringValue(row, DB_COL_ID_AIRPORT)
            };

            Airport airport = acf.Retrieve<Airport>(entity);

            var AirportManager = new AirportManager
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
                Status = Convert.ToBoolean(GetIntValue(row, DB_COL_STATUS)),
                Rol = GetStringValue(row, DB_COL_ID_ROL),
                AirportID = GetStringValue(row, DB_COL_ID_AIRPORT),
                AirportName = airport.Name
            };

            return AirportManager;
        }

    
        public SqlOperation GetRetrieveAllStatement()
        {
            //en este proc, se debe de consultar por rol
            var operation = new SqlOperation { ProcedureName = "sp_GetAirportManagers" };
            return operation;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "sp_GetAirportManagerById" };

            var m = (AirportManager)entity;
            operation.AddVarcharParam(DB_COL_ID, m.ID);

            return operation;
        }
        public SqlOperation RetrieveAdminAirportByAirportIdStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ADMINAIRPORT_BY_AIRPORT_ID" };

            var m = (AirportManager)entity;
            operation.AddVarcharParam(DB_COL_ID, m.AirportID);
            return operation;
        }


    }
}
