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
   public class FAQMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_QUESTION = "QUESTION";
        private const string DB_COL_ANSWER = "ANSWER";
        private const string DB_COL_STATUS = "STATUS";

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var Faq = new FAQ
            {
                ID = GetStringValue(row, DB_COL_ID),
                Question = GetStringValue(row, DB_COL_QUESTION),
                Answer = GetStringValue(row, DB_COL_ANSWER),
                Status = GetBoolValue(row, DB_COL_STATUS)

            };
            return Faq;
        }
        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var Faq = BuildObject(row);
                lstResults.Add(Faq);
            }

            return lstResults;
        }
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "sp_CreateFAQ" };
            var f = (FAQ)entity;

            operation.AddVarcharParam(DB_COL_ID, f.ID);
            operation.AddVarcharParam(DB_COL_QUESTION, f.Question);
            operation.AddVarcharParam(DB_COL_ANSWER, f.Answer);

            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "sp_GetAllFAQS" };
            return operation;
        }

        public SqlOperation GetRetrieveAvailable()
        {
            var operation = new SqlOperation { ProcedureName = "RET_AVAILABLE_FAQS_PR" };
            return operation;
        }
        public SqlOperation GetRetrieveUnavailable()
        {
            var operation = new SqlOperation { ProcedureName = "RET_UNAVAILABLE_FAQS_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "sp_UpdateFAQ" };
            var f = (FAQ)entity;

            operation.AddVarcharParam(DB_COL_ID, f.ID);
            operation.AddVarcharParam(DB_COL_QUESTION, f.Question);
            operation.AddVarcharParam(DB_COL_ANSWER, f.Answer);
            operation.AddIntParam(DB_COL_STATUS, f.Status ? 1 : 0);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "sp_DeleteFAQById" };
            var a = (FAQ)entity;
            operation.AddVarcharParam(DB_COL_ID, a.ID);
            return operation;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "sp_GetFAQById" };
            var f = (FAQ)entity;
            operation.AddVarcharParam(DB_COL_ID, f.ID);
            return operation;
        }
    }
}
