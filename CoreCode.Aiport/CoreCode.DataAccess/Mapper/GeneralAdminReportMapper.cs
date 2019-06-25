using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreCode.Entities.POJO;
using CoreCode.Entities.POJO.Dashboard;
using DataAccess.Dao;

namespace CoreCode.DataAccess.Mapper
{
    public class GeneralAdminReportMapper
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

        public SqlOperation GetRetrieveStatement()
        {
            var operation = new SqlOperation {ProcedureName = "sp_GetGeneralAdminReport"};
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
            var customer = new GeneralReportAirport
            {
                StoresGain = 250000,
                GatesGain = 12000,
                RunwayLandingGain=  50000,
            };

            return customer;
        }
    }
}
