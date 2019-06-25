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
   public class FlightMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_AIRLINE_ID = "AIRLINE_ID";
        private const string DB_COL_ORIGIN_AIRPORT = "ORIGIN_AIRPORT_ID";
        private const string DB_COL_DESTINY_AIRPORT = "DESTINY_AIRPORT_ID";
        private const string DB_COL_DEPARTURE_TIME = "DEPARTURE_TIME";
        private const string DB_COL_ARRIVAL_TIME = "ARRIVAL_DATETIME";
        private const string DB_COL_STATUS = "STATUS";
        private const string DB_COL_ID_AIRPLANE = "ID_AIRPLANE";
        private const string DB_COL_ID_GATE = "ID_GATE";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
           
            var FLight = new Flight
            {
                Id = GetStringValue(row, DB_COL_ID),
                Airline_Id = GetStringValue(row, DB_COL_AIRLINE_ID),
                Origin_Airport_Id = GetStringValue(row, DB_COL_ORIGIN_AIRPORT),
                Destiny_Airport_Id = GetStringValue(row, DB_COL_DESTINY_AIRPORT),
                Departure_Time = Convert.ToDateTime(GetDateValue(row, DB_COL_DEPARTURE_TIME)),
                Arrival_DateTime = Convert.ToDateTime(GetDateValue(row, DB_COL_ARRIVAL_TIME)),
                Status = GetStringValue(row, DB_COL_STATUS),
                Id_Gate = GetStringValue(row, DB_COL_ID_GATE)

            };
            return FLight;
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
            var operation = new SqlOperation { ProcedureName = "SP_CREATEFLIGHT" };
            var a = (Flight)entity;

            operation.AddVarcharParam(DB_COL_ID, a.Id);
            operation.AddVarcharParam(DB_COL_AIRLINE_ID, a.Airline_Id);
            operation.AddVarcharParam(DB_COL_ORIGIN_AIRPORT, a.Origin_Airport_Id);
            operation.AddVarcharParam(DB_COL_DESTINY_AIRPORT, a.Destiny_Airport_Id);
            operation.AddDateParam(DB_COL_DEPARTURE_TIME, a.Departure_Time);
            operation.AddDateParam(DB_COL_ARRIVAL_TIME, a.Arrival_DateTime);
            operation.AddVarcharParam(DB_COL_STATUS, a.Status);
            operation.AddVarcharParam(DB_COL_ID_AIRPLANE, a.Id_Airplane);
            operation.AddVarcharParam(DB_COL_ID_GATE, a.Id_Gate);


            return operation;
        }

        public SqlOperation GetOnTimeFlight()
        {
            var operation = new SqlOperation { ProcedureName = "SP_LIST_ONTIME_FLIGHT" };
            return operation;
        }

        public SqlOperation GetCanceledFlight()
        {
            var operation = new SqlOperation { ProcedureName = "SP_LIST_CANCELED_FLIGHT" };
            return operation;
        }
        public SqlOperation GetDelayFlight()
        {
            var operation = new SqlOperation { ProcedureName = "SP_LIST_DELAY_FLIGHT" };
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "SP_LIST_FLIGHTS"};
            return operation;
        }

        public SqlOperation GetAirlinesByFLightIdStatement(string flightId)
        {
            var operation = new SqlOperation { ProcedureName = "sp_getAirlinesByAirportId" };
            operation.AddVarcharParam(DB_COL_ID, flightId);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATEFLIGHT" };
            var a = (Flight)entity;
            operation.AddVarcharParam(DB_COL_ID, a.Id);
            //operation.AddVarcharParam(DB_COL_AIRLINE_ID, a.Airline_Id);
            //operation.AddVarcharParam(DB_COL_ORIGIN_AIRPORT, a.Origin_Airport_Id);
            //operation.AddVarcharParam(DB_COL_DESTINY_AIRPORT, a.Destiny_Airport_Id);
            //operation.AddDateParam(DB_COL_DEPARTURE_TIME, a.Departure_Time);
            //operation.AddDateParam(DB_COL_ARRIVAL_TIME, a.Arrival_DateTime);
            operation.AddVarcharParam(DB_COL_STATUS, a.Status);
            //operation.AddVarcharParam(DB_COL_ID_AIRPLANE, a.Id_Airplane);
            ///operation.AddVarcharParam(DB_COL_ID_GATE, a.Id_Gate);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_DELETEFLIGHT" };
            var a = (Flight)entity;
            operation.AddVarcharParam(DB_COL_ID, a.Id);
            return operation;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {

            var operation = new SqlOperation { ProcedureName = "SP_GETFLIGHTYID" };
            var a = (Flight)entity;
            operation.AddVarcharParam(DB_COL_ID, a.Id);
            return operation;
        }



        public SqlOperation GetRetrieveStatementFlightById(String Id)
        {

            var operation = new SqlOperation { ProcedureName = "SP_GETFLIGHTBYID" };
            var a = new Flight();
            operation.AddVarcharParam(DB_COL_ID, a.Id);
         
            return operation;
        }


    }
}
