using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreCode.Entities.POJO;
using CoreCode.Entities.POJO.Enums;
using DataAccess.Dao;
using DataAccess.Mapper;

namespace CoreCode.DataAccess.Mapper
{
    public class UserHistoryMapper: EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID_ACTION = "ID_ACTION";
        private const string DB_COL_ID_USER = "ID_USER";
        private const string DB_COL_ACTION = "ACTION";
        private const string DB_COL_DATE_ACTION = "DATE_ACTION";
        public const string SP_COL_USER_NAME = "USER_NAME";
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation {ProcedureName = "sp_CreateUserHistory"};
            var userHistory = (UserHistory)entity;            
            operation.AddVarcharParam(DB_COL_ID_ACTION, userHistory.Id);
            operation.AddVarcharParam(DB_COL_ID_USER, userHistory.UserId);
            operation.AddVarcharParam(DB_COL_ACTION, userHistory.ActionType.ToString());
            operation.AddDateParam(DB_COL_DATE_ACTION, userHistory.ActionDate);
            return operation;
        }

        public SqlOperation GetRetrieveStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveAllStatement()
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            throw new NotImplementedException();
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            Enum.TryParse(GetStringValue(row, DB_COL_ACTION), out UserActionType actionType);
            var customer = new UserHistory
            {
                Id = GetStringValue(row, DB_COL_ID_ACTION),
                UserId= GetStringValue(row, DB_COL_ID_USER),
                UserName = GetStringValue(row, SP_COL_USER_NAME),
                ActionDate = GetDateValue(row, DB_COL_DATE_ACTION),
                ActionType = actionType
            };
            return customer;
        }

        public SqlOperation GetUserHistoryByUserId(string userId)
        {
            var operation = new SqlOperation {ProcedureName = "sp_GetUserHistoryByUserId"};
            operation.AddVarcharParam(DB_COL_ID_USER, userId);
            return operation;
        }
    }
}
