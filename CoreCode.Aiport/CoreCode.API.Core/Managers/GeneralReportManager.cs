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
    public class GeneralReportManager : IManager
    {
        private GeneralReportCrudFactory crudGeneralReport { get;set; }
        public GeneralReportManager()
        {
            crudGeneralReport = new GeneralReportCrudFactory();
        }

        public GeneralReportAirport RetrieveReport(string airportId)
        {
            GeneralReportAirport reportAirportToReturn = null;
            try
            {
                reportAirportToReturn = crudGeneralReport.Retrieve<GeneralReportAirport>(airportId);
                if (reportAirportToReturn == null)
                {
                    //TODO: Log Exception
                    //The Airport doesn't have any report to process.
                    return new GeneralReportAirport();
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
