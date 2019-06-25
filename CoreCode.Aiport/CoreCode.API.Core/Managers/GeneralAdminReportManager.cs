using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO.Dashboard;
using CoreCode.Exceptions;

namespace CoreCode.API.Core.Managers
{
    public class GeneralAdminReportManager
    {
        private GeneralAdminReportCrudFactory crudGeneralReport { get;set; }
        public GeneralAdminReportManager()
        {
            crudGeneralReport = new GeneralAdminReportCrudFactory();
        }

        public GeneralAdminReport RetrieveReport()
        {
            GeneralAdminReport reportAirportToReturn = null;
            try
            {
                reportAirportToReturn = crudGeneralReport.Retrieve<GeneralAdminReport>();
                if (reportAirportToReturn == null)
                {
                    //TODO: Log Exception
                    //The Airport doesn't have any report to process.
                    return new GeneralAdminReport();
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return reportAirportToReturn;
        }
    }
}
