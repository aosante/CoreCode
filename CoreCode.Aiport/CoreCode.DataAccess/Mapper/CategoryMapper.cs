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
    public class CategoryMapper : EntityMapper, ISqlStatements, IObjectMapper

    {

        private const string DB_COL_ID = "ID";
        private const string DB_COL_DESCRIPTION = "DESCRIPTION";
        private const string DB_COL_STATUS = "STATUS";



        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
           // string DB_COL_ID = null;
            var category = new Category
            {
                IDCategory = GetStringValue(row, DB_COL_ID),
                Description = GetStringValue(row, DB_COL_DESCRIPTION),
                Status = GetBoolValue(row, DB_COL_STATUS)
            };
            return category;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var category = BuildObject(row);
                lstResults.Add(category);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_CATEGORY_PR" };
            var c = (Category)entity;

            operation.AddVarcharParam(DB_COL_ID, c.IDCategory);
            operation.AddVarcharParam(DB_COL_DESCRIPTION, c.Description);
            operation.AddIntParam(DB_COL_STATUS, c.Status ? 1 : 0);


            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CATEGORY_PR" };
            var c = (Category)entity;
            operation.AddVarcharParam(DB_COL_ID, c.IDCategory);
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CATEGORY_PR" };
            return operation;
        }
        public SqlOperation GetRetrieveAvailable()
        {
            var operation = new SqlOperation { ProcedureName = "RET_AVAILABLE_CATEGORY_PR" };
            return operation;
        }
        public SqlOperation GetRetrieveUnavailable()
        {
            var operation = new SqlOperation { ProcedureName = "RET_UNAVAILABLE_CATEGORY_PR" };
            return operation;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CATEGORY_PR" };
            var c = (Category)entity;
            operation.AddVarcharParam(DB_COL_ID, c.IDCategory);

            return operation; 
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CATEGORY_PR" };
            var c = (Category)entity;
            operation.AddVarcharParam(DB_COL_ID, c.IDCategory);
            operation.AddVarcharParam(DB_COL_DESCRIPTION, c.Description);
            operation.AddIntParam(DB_COL_STATUS, c.Status ? 1 : 0);
            return operation;
        }
    }
}
