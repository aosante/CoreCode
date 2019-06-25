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
    public class StoreMapper : EntityMapper, ISqlStatements, IObjectMapper

    {

        private const string DB_COL_ID = "ID";
        private const string DB_COL_NAME = "NAME";
        private const string DB_COL_MANAGER_NAME = "MANAGER_NAME";
        private const string DB_COL_PHONE = "PHONE";
        private const string DB_COL_ID_CATEGORY = "ID_CATEGORY";
        private const string DB_COL_ID_AIRPORT = "ID_AIRPORT";
        private const string DB_COL_RENT = "RENT";
        private const string DB_COL_STATUS = "STATUS";


        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var store = new Store
            {
                IDStore = GetStringValue(row, DB_COL_ID),
                Name = GetStringValue(row, DB_COL_NAME),
                ManagerName = GetStringValue(row, DB_COL_MANAGER_NAME),
                Phone = GetStringValue(row, DB_COL_PHONE),
                IDCategory =GetStringValue(row, DB_COL_ID_CATEGORY),
                IDAirport = GetStringValue(row, DB_COL_ID_AIRPORT),
                Rent = GetDecimalValue(row, DB_COL_RENT),
                Status = Convert.ToBoolean(GetBoolValue(row, DB_COL_STATUS)),

            };
            return store;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();
            foreach (var row in lstRows)
            {
                var store = BuildObject(row);
                lstResults.Add(store);
            }

            return lstResults;
        }

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_STORE_PR" };
            var c = (Store)entity;
            operation.AddVarcharParam(DB_COL_ID, c.IDStore);
            operation.AddVarcharParam(DB_COL_NAME, c.Name);
            operation.AddVarcharParam(DB_COL_MANAGER_NAME, c.ManagerName);
            operation.AddVarcharParam(DB_COL_PHONE, c.Phone);
            operation.AddVarcharParam(DB_COL_ID_CATEGORY, c.IDCategory);
            operation.AddVarcharParam(DB_COL_ID_AIRPORT, c.IDAirport);
            operation.AddDecimalParam(DB_COL_RENT, c.Rent);
            operation.AddIntParam(DB_COL_STATUS, c.Status ? 1 : 0);


            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_STORE_PR" };
            var c = (Store)entity;
            operation.AddVarcharParam(DB_COL_ID, c.IDStore);
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_STORE_PR" };
            return operation;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_STORE_PR" };
            var c = (Store)entity;

            operation.AddVarcharParam(DB_COL_ID, c.IDStore);

            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_STORE_PR" };
            var c = (Store)entity;

            operation.AddVarcharParam(DB_COL_ID, c.IDStore);
            operation.AddVarcharParam(DB_COL_NAME, c.Name);
            operation.AddVarcharParam(DB_COL_MANAGER_NAME, c.ManagerName);
            operation.AddVarcharParam(DB_COL_PHONE, c.Phone);
            operation.AddVarcharParam(DB_COL_ID_CATEGORY, c.IDCategory);
            operation.AddVarcharParam(DB_COL_ID_AIRPORT, c.IDAirport);
            operation.AddDecimalParam(DB_COL_RENT, c.Rent);
            operation.AddIntParam(DB_COL_STATUS, c.Status ? 1 : 0);

            return operation;
        }
        public SqlOperation GetRetrieveStatementStoresByAirportById(string idAirport)
        {

            var operation = new SqlOperation { ProcedureName = "RET_AIRPORT_STORES" };
            operation.AddVarcharParam(DB_COL_ID_AIRPORT, idAirport);
            return operation;
        }
    }
}
