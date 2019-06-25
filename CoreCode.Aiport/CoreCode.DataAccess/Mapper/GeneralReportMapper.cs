using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreCode.Entities.POJO;
using CoreCode.Entities.POJO.Dashboard;
using DataAccess.Dao;
using DataAccess.Mapper;

namespace CoreCode.DataAccess.Mapper
{
    public class GeneralReportMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string SpParamStoresGain = "ID";
        private const string SpParamGatesGain = "NAME";
        private const string SpParamRunwayGain = "LAST_NAME";
        
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation {ProcedureName = "GET_GENERAL_REPORT_PR"};
            var generalReportEntity = (GeneralReportAirport) entity;            
            return operation;
        }

        public SqlOperation GetRetrieveStatement(string airportId)
        {
            var operation = new SqlOperation {ProcedureName = "RET_GENERAL_REPORT_SP"};
            operation.AddVarcharParam("ID_AIRPORT", airportId);
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
            throw new NotImplementedException();
        }
    }
}
