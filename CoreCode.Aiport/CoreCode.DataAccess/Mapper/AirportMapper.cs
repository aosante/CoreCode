using CoreCode.DataAccess.Crud;
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
   public class AirportMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_NAME = "NAME";
        private const string DB_COL_ADDRESS = "ADDRESS";
        private const string DB_COL_PHONE = "PHONE";
        private const string DB_COL_ZIPCODE = "ZIPCODE";
        private const string DB_COL_GATE_TARIFF = "GATE_TARIFF";
        private const string DB_COL_RUNWAY_TARIFF = "RUNWAY_TARIFF";
        private const string DB_COL_TAX = "TAX";
        private const string DB_COL_STATUS = "STATUS";
        private const string DB_COL_ASIGNED = "ASIGNED";
        private const string DB_COL_LATITUDE = "LATITUDE";
        private const string DB_COL_LONGITUDE = "LONGITUDE";

        private const string DB_COL_AIRLINE_ID = "AIRLINE_ID";
        private const string DB_COL_AIRPORT_ID = "AIRPORT_ID";


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            
            var airport = new Airport
            {
                ID = GetStringValue(row, DB_COL_ID),
                Name = GetStringValue(row, DB_COL_NAME),
                Address = GetStringValue(row, DB_COL_ADDRESS),
                Phone = GetStringValue(row, DB_COL_PHONE),
                ZipCode = GetStringValue(row, DB_COL_ZIPCODE),
                GateTariff = GetDecimalValue(row, DB_COL_GATE_TARIFF),
                RunwayTariff = GetDecimalValue(row, DB_COL_RUNWAY_TARIFF),
                Tax = GetDecimalValue(row, DB_COL_TAX),
                Status = Convert.ToBoolean(GetBoolValue(row, DB_COL_STATUS)),
                Asigned = Convert.ToBoolean(GetBoolValue(row, DB_COL_ASIGNED)), 
                Latitude = GetStringValue(row, DB_COL_LATITUDE),
                Longitude = GetStringValue(row, DB_COL_LONGITUDE),
            };
            return airport;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var airport = BuildObject(row);
                lstResults.Add(airport);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_AIRPORT_PR" };
            var c = (Airport)entity;

            operation.AddVarcharParam(DB_COL_ID, c.ID);
            operation.AddVarcharParam(DB_COL_NAME, c.Name);
            operation.AddVarcharParam(DB_COL_ADDRESS, c.Address);
            operation.AddVarcharParam(DB_COL_PHONE, c.Phone);
            operation.AddVarcharParam(DB_COL_ZIPCODE, c.ZipCode);
            operation.AddDecimalParam(DB_COL_GATE_TARIFF, c.GateTariff);
            operation.AddDecimalParam(DB_COL_RUNWAY_TARIFF, c.RunwayTariff);
            operation.AddDecimalParam(DB_COL_TAX, c.Tax);
            operation.AddIntParam(DB_COL_STATUS, c.Status ? 1 : 0);
            operation.AddVarcharParam(DB_COL_LATITUDE, c.Latitude);
            operation.AddVarcharParam(DB_COL_LONGITUDE, c.Longitude);
            // operation.AddIntParam(DB_COL_ASIGNED, c.Asigned ? 1 : 0);
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_AIRPORT_PR" };
            return operation;
        }


        public SqlOperation GetRetrieveAvailable()
        {
            var operation = new SqlOperation { ProcedureName = "RET_AVAILABLE_AIRPORT_PR" };
            return operation;
        }

        public SqlOperation GetRetrieveUnavailable()
        {
            var operation = new SqlOperation { ProcedureName = "RET_UNAVAILABLE_AIRPORT_PR" };
            return operation;
        }


        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_AIRPORT_PR" };
            var c = (Airport)entity;
            operation.AddVarcharParam(DB_COL_ID, c.ID);
            operation.AddVarcharParam(DB_COL_NAME, c.Name);
            operation.AddVarcharParam(DB_COL_ADDRESS, c.Address);
            operation.AddVarcharParam(DB_COL_PHONE, c.Phone);
            operation.AddVarcharParam(DB_COL_ZIPCODE, c.ZipCode);
            operation.AddDecimalParam(DB_COL_GATE_TARIFF, c.GateTariff);
            operation.AddDecimalParam(DB_COL_RUNWAY_TARIFF, c.RunwayTariff);
            operation.AddDecimalParam(DB_COL_TAX, c.Tax);
            operation.AddIntParam(DB_COL_STATUS, c.Status ? 1 : 0);
            operation.AddIntParam(DB_COL_ASIGNED, c.Asigned ? 1 : 0);
            operation.AddVarcharParam(DB_COL_LATITUDE, c.Latitude);
            operation.AddVarcharParam(DB_COL_LONGITUDE, c.Longitude);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_AIRPORT_PR" };
            var c = (Airport)entity;
            operation.AddVarcharParam(DB_COL_ID, c.ID);
            return operation;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_AIRPORT_PR" };
            var c = (Airport)entity;
            operation.AddVarcharParam(DB_COL_ID, c.ID);
            return operation;
        }

       public SqlOperation RetrieveAssociatedAirportsStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ASSOCIATED_AIRPORTS" };
            var c = (Airport)entity;
            operation.AddVarcharParam(DB_COL_AIRLINE_ID, c.ID);

            return operation;
        }
        public SqlOperation RetrieveNonAssociatedAirportsStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_NON_ASSOCIATED_AIRPORTS" };
            var c = (Airport)entity;

            operation.AddVarcharParam(DB_COL_AIRLINE_ID, c.ID);

            return operation;
        }
        
     public SqlOperation RetrievePossibleDestinyAirportsStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_POSSIBLE_DESTINY_AIRPORT" };
            var c = (RequestAirlineAirport)entity;

            operation.AddVarcharParam(DB_COL_AIRLINE_ID, c.IDAirline);
            operation.AddVarcharParam(DB_COL_AIRPORT_ID, c.IDAirport);

            return operation;
        }

    }
}
