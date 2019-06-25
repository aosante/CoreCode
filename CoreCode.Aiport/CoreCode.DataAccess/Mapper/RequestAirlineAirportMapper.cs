using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreCode.Entities.POJO;
using DataAccess.Dao;
using DataAccess.Mapper;

namespace CoreCode.DataAccess.Mapper
{


    public class RequestAirlineAirportMapper : EntityMapper, ISqlStatements, IObjectMapper
    {

        private const string DB_COL_IDAIRLINE = "IDAIRLINE";
        private const string DB_COL_IDAIRPORT = "IDAIRPORT";
        private const string DB_COL_REQUEST = "REQUEST";


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var request = new RequestAirlineAirport
            {
                IDAirline = GetStringValue(row, DB_COL_IDAIRLINE),
                IDAirport = GetStringValue(row, DB_COL_IDAIRPORT),
                Request = GetStringValue(row, DB_COL_REQUEST),
            };
            return request;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var request = BuildObject(row);
                lstResults.Add(request);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "INSERT_AIRPORT_AIRLINE" };
            var c = (RequestAirlineAirport)entity;
            operation.AddVarcharParam(DB_COL_IDAIRLINE, c.IDAirline);
            operation.AddVarcharParam(DB_COL_IDAIRPORT, c.IDAirport);


            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_AIRLINE_AIRPORT_ASSOCIATION" };
            var c = (RequestAirlineAirport)entity;

            operation.AddVarcharParam(DB_COL_IDAIRLINE, c.IDAirline);
            operation.AddVarcharParam(DB_COL_IDAIRPORT, c.IDAirport);
            operation.AddVarcharParam(DB_COL_REQUEST, c.Request);

            return operation;
        }
       

    }
}
