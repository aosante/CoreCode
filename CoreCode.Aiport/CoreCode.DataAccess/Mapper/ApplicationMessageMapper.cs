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
    public class ApplicationMessageMapper : EntityMapper, ISqlStatements, IObjectMapper
    {

        private const string DB_COL_ID_MESSAGE = "id_message";
        private const string DB_COL_DATE = "date";
        private const string DB_COL_MESSAGE = "message";




        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_EXCEPTION" };

            var a = (ApplicationMessage)entity;
            operation.AddVarcharParam(DB_COL_DATE, DateTime.Now.ToString());
            operation.AddVarcharParam(DB_COL_MESSAGE, a.Message);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_EXCEPTIONS" };
            return operation;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var appMessage = BuildObject(row);
                lstResults.Add(appMessage);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var appMessage = new ApplicationMessage
            {
                Id = GetIntValue(row, DB_COL_ID_MESSAGE),
                Message = GetStringValue(row, DB_COL_MESSAGE)
            };

            return appMessage;
        }


    }
}
