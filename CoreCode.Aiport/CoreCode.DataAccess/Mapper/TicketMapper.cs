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
   public class TicketMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_ID_FLIGHT = "ID_FLIGHT";
        private const string DB_COL_TICKET_CLASS = "TICKET_CLASS";
        private const string DB_COL_STATUS = "STATUS";
        private const string DB_COL_PRICE = "PRICE";
        private const string DB_COL_BUY_DATE = "BUY_DATE";
        private const string DB_COL_ID_PERSON = "ID_PERSON";
        private const string DB_COL_PERSON_NAME = "PERSON_NAME";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
           
            var ticket = new Ticket
            {
                Id = GetStringValue(row, DB_COL_ID),
                Id_Flight = GetStringValue(row, DB_COL_ID_FLIGHT),
                Ticket_Class = GetStringValue(row, DB_COL_TICKET_CLASS),
                Status = GetStringValue(row, DB_COL_STATUS),
                Price = GetDecimalValue(row, DB_COL_PRICE),
                Buy_Date = Convert.ToDateTime(GetDateValue(row, DB_COL_BUY_DATE)),
                Id_Person = GetStringValue(row, DB_COL_ID_PERSON),
                Person_Name = GetStringValue(row, DB_COL_PERSON_NAME)
            };
            return ticket;
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
            var operation = new SqlOperation { ProcedureName = "SP_CREATE_TICKET" };
            var a = (Ticket)entity;

            operation.AddVarcharParam(DB_COL_ID, a.Id);
            operation.AddVarcharParam(DB_COL_ID_FLIGHT, a.Id_Flight);
            operation.AddVarcharParam(DB_COL_TICKET_CLASS, a.Ticket_Class);
            operation.AddVarcharParam(DB_COL_STATUS, a.Status);
            operation.AddDecimalParam(DB_COL_PRICE, a.Price);
            operation.AddDateParam(DB_COL_BUY_DATE, a.Buy_Date);
            operation.AddVarcharParam(DB_COL_ID_PERSON, a.Id_Person);
            operation.AddVarcharParam(DB_COL_PERSON_NAME, a.Person_Name);

            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "SP_LIST_TICKETS" };
            return operation;
        }

        public SqlOperation GetTicketByIdStatement(string ticketId)
        {
            var operation = new SqlOperation { ProcedureName = "SP_GETTICKETBYID" };
            operation.AddVarcharParam(DB_COL_ID, ticketId);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_UPDATE_TICKET_NAME" };
            var a = (Ticket)entity;
            operation.AddVarcharParam(DB_COL_ID, a.Id);
            operation.AddVarcharParam(DB_COL_PERSON_NAME, a.Person_Name);
            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "SP_DELETETICKET" };
            var a = (Ticket)entity;
            operation.AddVarcharParam(DB_COL_ID, a.Id);
            return operation;
        }

        //No funciona
        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {

            var operation = new SqlOperation { ProcedureName = "SP_GETTICKETBYID" };
            var a = (Ticket)entity;
            operation.AddVarcharParam(DB_COL_ID, a.Id);
            return operation;
        }

        public SqlOperation GetOnTimeTicket()
        {
            var operation = new SqlOperation { ProcedureName = "SP_LIST_ONTIME_TICKET" };
            return operation;
        }

        public SqlOperation GetCanceledTicket()
        {
            var operation = new SqlOperation { ProcedureName = "SP_LIST_CANCELED_TICKET" };
            return operation;
        }
        public SqlOperation GetDelayTicket()
        {
            var operation = new SqlOperation { ProcedureName = "SP_LIST_DELAY_TICKET" };
            return operation;
        }

    }
}
