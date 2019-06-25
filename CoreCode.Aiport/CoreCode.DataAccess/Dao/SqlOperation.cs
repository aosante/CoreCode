using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Dao
{
    public class SqlOperation
    {
        public SqlOperation()
        {
            Parameters = new List<SqlParameter>();
        }

        public string ProcedureName { get; set; }
        public List<SqlParameter> Parameters { get; set; }

        public void AddVarcharParam(string paramName, string paramValue)
        {
            var param = new SqlParameter("@" + paramName, SqlDbType.NVarChar, 50)
            {
                Value = paramValue
            };
            Parameters.Add(param);
        }

        public void AddIntParam(string paramName, int paramValue)
        {
            var param = new SqlParameter("@" + paramName, SqlDbType.Int)
            {
                Value = paramValue
            };
            Parameters.Add(param);
        }

        public void AddDoubleParam(string paramName, double paramValue)
        {
            var param = new SqlParameter("@" + paramName, SqlDbType.Decimal)
            {
                Value = paramValue
            };
            Parameters.Add(param);
        }
        public void AddDecimalParam(string paramName, decimal paramValue)
        {
            var param = new SqlParameter("@" + paramName, SqlDbType.Decimal)
            {
                Value = paramValue
            };
            Parameters.Add(param);
        }

        public void AddDateParam(string paramName, DateTime dateParam)
        {
            var param = new SqlParameter("@" + paramName, SqlDbType.DateTime)
            {
                Value = dateParam
            };
            Parameters.Add(param);
        }

    }
}