using CoreCode.Entities.POJO;
using DataAccess.Dao;
using DataAccess.Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.DataAccess.Mapper
{
   public class AirlineMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_COMERCIAL_NAME = "COMERCIAL_NAME";
        private const string DB_COL_BUSINESS_NAME = "BUSINESS_NAME";
        private const string DB_COL_CREATION_YEAR = "CREATION_YEAR";
        private const string DB_COL_DESCRIPTION = "DESCRIPTION";
        private const string DB_COL_EMAIL = "EMAIL";
        private const string DB_COL_STATUS = "STATUS";
        private const string DB_COL_REQUEST = "REQUEST";

        private const string DB_COL_AIRPORT_ID = "AIRPORT_ID";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var airline = new Airline
            {
                Id = GetStringValue(row, DB_COL_ID),
                Comercial_name = GetStringValue(row, DB_COL_COMERCIAL_NAME),
                Business_name = GetStringValue(row, DB_COL_BUSINESS_NAME),
                Creation_year = Convert.ToDateTime(GetDateValue(row, DB_COL_CREATION_YEAR)),
                Description = GetStringValue(row, DB_COL_DESCRIPTION),
                Email = GetStringValue(row, DB_COL_EMAIL),
                Status = Convert.ToBoolean(GetBoolValue(row, DB_COL_STATUS)),
                Request = GetStringValue(row, DB_COL_REQUEST)

            };
            return airline;
        }

        public Airline BuildObjectFromDataRow(DataRow row)
        {
            var airline = new Airline
            {
                Id = row.Field<string>(DB_COL_ID),
                Comercial_name = row.Field<string>(DB_COL_COMERCIAL_NAME),
                Business_name = row.Field<string>(DB_COL_BUSINESS_NAME),
                Creation_year = row.Field<DateTime>(DB_COL_CREATION_YEAR),
                Description = row.Field<string>(DB_COL_DESCRIPTION),
                Email = row.Field<string>(DB_COL_EMAIL),
                Status = row.Field<bool>(DB_COL_STATUS),
                Request = row.Field<string>(DB_COL_REQUEST)
            };
            return airline;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var airline = BuildObject(row);
                lstResults.Add(airline);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_CREATEAIRLINE" };
            var a = (Airline)entity;

            operation.AddVarcharParam(DB_COL_ID, a.Id);
            operation.AddVarcharParam(DB_COL_COMERCIAL_NAME, a.Comercial_name);
            operation.AddVarcharParam(DB_COL_BUSINESS_NAME, a.Business_name);
            operation.AddDateParam(DB_COL_CREATION_YEAR, a.Creation_year);
            operation.AddVarcharParam(DB_COL_DESCRIPTION, a.Description);
            operation.AddVarcharParam(DB_COL_EMAIL, a.Email);
            operation.AddIntParam(DB_COL_STATUS, a.Status ? 1 : 0);
            operation.AddVarcharParam(DB_COL_REQUEST, a.Request);

            return operation;
        }

        

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "SP_LISTAIRLINE" };
            return operation;
        }

        public SqlOperation RetrieveWaitingAirlines()//*
        {
            var operation = new SqlOperation { ProcedureName = "RET_WAITING_AIRLINES" };
            return operation;
        }

        public SqlOperation RetrieveAcceptedAirlines()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ACCEPTED_AIRLINES" };
            return operation;
        }

        public SqlOperation RetrieveDeniedAirlines()
        {
            var operation = new SqlOperation { ProcedureName = "RET_REJECTED_AIRLINES" };
            return operation;
        }

        public SqlOperation RetrieveAvailableAirlines()
        {
            var operation = new SqlOperation { ProcedureName = " RET_AVAILABLE_AIRLINES" };
            return operation;
        }

        public SqlOperation RetrieveUnvailableAirlines()
        {
            var operation = new SqlOperation { ProcedureName = "RET_UNAVAILABLE_AIRLINES" };
            return operation;
        }

        public SqlOperation RetrieveAssociatedAirlinesStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ASSOCIATED_AIRLINES" };
            var c = (Airline)entity;

            operation.AddVarcharParam(DB_COL_AIRPORT_ID, c.Id);

            return operation; 
        }


        public SqlOperation RetrieveRejectedAirlinesStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_REJECTED_AIRLINES_AIRPORTS" };
            var c = (Airline)entity;

            operation.AddVarcharParam(DB_COL_AIRPORT_ID, c.Id);

            return operation;
        }


        public SqlOperation RetrieveWaitingAirlinesStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_WAITING_AIRLINES_AIRPORT" };
            var c = (Airline)entity;

            operation.AddVarcharParam(DB_COL_AIRPORT_ID, c.Id);

            return operation; 
        }



        public SqlOperation GetAirlinesByAirportIdStatement(string airportId)
        {
            var operation = new SqlOperation { ProcedureName = "sp_getAirlinesByAirportId" };
            operation.AddVarcharParam(DB_COL_ID, airportId);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATEAIRLINE" };
            var a = (Airline)entity;
            operation.AddVarcharParam(DB_COL_ID, a.Id);
            operation.AddVarcharParam(DB_COL_COMERCIAL_NAME, a.Comercial_name);
            operation.AddVarcharParam(DB_COL_BUSINESS_NAME, a.Business_name);
            operation.AddDateParam(DB_COL_CREATION_YEAR, a.Creation_year);
            operation.AddVarcharParam(DB_COL_DESCRIPTION, a.Description);
            operation.AddVarcharParam(DB_COL_EMAIL, a.Email);
            operation.AddIntParam(DB_COL_STATUS, a.Status ? 1 : 0);
            operation.AddVarcharParam(DB_COL_REQUEST, a.Request);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_DELETEAIRLINE" };
            var a = (Airline)entity;
            operation.AddVarcharParam(DB_COL_ID, a.Id);
            return operation;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {

            var operation = new SqlOperation { ProcedureName = "SP_GETAIRLINEBYID" };
            var a = (Airline)entity;
            operation.AddVarcharParam(DB_COL_ID, a.Id);
            return operation;
        }



        public SqlOperation GetRetrieveStatementAirlineById(String Id)
        {

            var operation = new SqlOperation { ProcedureName = "SP_GETAIRLINEBYID" };
            var a = new Airline();
            operation.AddVarcharParam(DB_COL_ID, a.Id);
         
            return operation;
        }


    }
}
