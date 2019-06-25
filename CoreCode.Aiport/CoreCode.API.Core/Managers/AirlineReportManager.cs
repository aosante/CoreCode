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
    public class AirlineReportManager
    {
        private AirlineReportCrudFactory crudGeneralReport { get;set; }
        public AirlineReportManager()
        {
            crudGeneralReport = new AirlineReportCrudFactory();
        }

        public AirlineReport RetrieveReport(string airlineId)
        {
            AirlineReport reportAirportToReturn = null;
            try
            {
                reportAirportToReturn = crudGeneralReport.Retrieve<AirlineReport>(airlineId);
                if (reportAirportToReturn == null)
                {
                    //TODO: Log Exception
                    //The Airport doesn't have any report to process.
                    return new AirlineReport();
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
