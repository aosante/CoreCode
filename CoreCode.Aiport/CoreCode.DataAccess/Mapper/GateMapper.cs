using CoreCode.DataAccess.Crud;
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
    public class GateMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
            private const string DB_COL_GATE_ID = "GATE_ID";
            private const string DB_COL_ID_AIRPORT = "ID_AIRPORT";
            private const string DB_COL_STATUS = "STATUS";
        private const string DB_COL_NUMBER = "NUMBER";
        private const string DB_COL_AIRPORT_ID = "AIRPORT_ID";
            

            public BaseEntity BuildObject(Dictionary<string, object> row)
            {
           
            var gate = new Gate
            {
                IDGate = GetStringValue(row, DB_COL_GATE_ID),
                IDAirport = GetStringValue(row, DB_COL_AIRPORT_ID),
                Status = GetBoolValue(row, DB_COL_STATUS),
                Number = GetIntValue(row, DB_COL_NUMBER)
            };
                return gate;
            }

        public Gate BuildObjectFromDataRow(DataRow row)
        {
            var gate = new Gate
            {
                IDGate = row.Field<string>(DB_COL_GATE_ID),
                IDAirport = row.Field<string>(DB_COL_AIRPORT_ID),
                Status = row.Field<bool>(DB_COL_STATUS),
                Number = row.Field<int>(DB_COL_NUMBER)
            };
            return gate;
        }

            public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
            {
                var lstResults = new List<BaseEntity>();
                foreach (var row in lstRows)
                {
                    var gate = BuildObject(row);
                    lstResults.Add(gate);
                }

                return lstResults;
            }

            public SqlOperation GetCreateStatement(BaseEntity entity)
            {
                var operation = new SqlOperation { ProcedureName = "CRE_GATE_PR" };
                var c = (Gate)entity;
                operation.AddVarcharParam(DB_COL_GATE_ID, c.IDGate);
                operation.AddVarcharParam(DB_COL_ID_AIRPORT, c.IDAirport);
                operation.AddIntParam(DB_COL_STATUS, c.Status ? 1 : 0);
               operation.AddIntParam(DB_COL_NUMBER, c.Number);


            return operation;
            }

            public SqlOperation GetRetrieveAllStatement()
            {
                var operation = new SqlOperation { ProcedureName = "RET_ALL_GATES_PR" };
                return operation;
            }

            public SqlOperation GetUpdateStatement(BaseEntity entity)
            {
                var operation = new SqlOperation { ProcedureName = "UPD_GATE_PR" };
                var c = (Gate)entity;
                operation.AddVarcharParam(DB_COL_GATE_ID, c.IDGate);
                operation.AddVarcharParam(DB_COL_ID_AIRPORT, c.IDAirport);
                operation.AddIntParam(DB_COL_STATUS, c.Status ? 1 : 0);
                operation.AddIntParam(DB_COL_NUMBER, c.Number);


            return operation;
            }

            public SqlOperation GetDeleteStatement(BaseEntity entity)
            {
                var operation = new SqlOperation { ProcedureName = "DEL_GATE_PR" };
                var c = (Gate)entity;
                operation.AddVarcharParam(DB_COL_GATE_ID, c.IDGate);
                return operation;
            }

            public SqlOperation GetRetrieveStatement(BaseEntity entity)
            {
                var operation = new SqlOperation { ProcedureName = "RET_GATE_PR" };
                var c = (Gate)entity;
                operation.AddVarcharParam(DB_COL_GATE_ID, c.IDGate);
                return operation;
            }

            public SqlOperation GetGateByAirportId(string airportId)
            {
                var operation = new SqlOperation { ProcedureName = "sp_GateByAirportId" };
                operation.AddVarcharParam(DB_COL_AIRPORT_ID, airportId);
                return operation;
            }

        public SqlOperation GetRetrieveStatementGatesByAirportId(string idAirport)
        {

            var operation = new SqlOperation { ProcedureName = "RET_AIRPORT_GATES" };
            operation.AddVarcharParam(DB_COL_ID_AIRPORT, idAirport);
            return operation;
        }

        public SqlOperation GetRetrieveStatementAvailableGatesByAirportId(string idAirport) 
        {

            var operation = new SqlOperation { ProcedureName = "RET_AVAILABLE_ARPT_GATES_PR" };
            operation.AddVarcharParam(DB_COL_ID_AIRPORT, idAirport);
            return operation;
        }

        public SqlOperation GetRetrieveStatementUnavailableGatesByAirportId(string idAirport)
        {

            var operation = new SqlOperation { ProcedureName = "RET_UNAVAILABLE_ARPT_GATES_PR" };
            operation.AddVarcharParam(DB_COL_ID_AIRPORT, idAirport);
            return operation;
        }

    }


}

