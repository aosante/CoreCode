using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using CoreCode.Exceptions;

namespace CoreCode.API.Core.Managers
{
    public class UserHistoryManager : IManager
    {
        private readonly UserHistoryCrudFactory _crudFactory;

        public UserHistoryManager()
        {
            _crudFactory = new UserHistoryCrudFactory();
        }

        public UserHistory RetrieveUserHistory(string userId)
        {
            UserHistory reportToReturn = null;
            try
            {
                reportToReturn = _crudFactory.RetrieveByUserId<UserHistory>(userId);
                if (reportToReturn == null)
                {
                    throw new BussinessException(4);
                }
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return reportToReturn;
        }

        public void Create(UserHistory userHistory)
        {
            _crudFactory.Create(userHistory);
        }
        
        public void Update(UserHistory userHistory)
        {
            _crudFactory.Update(userHistory);
        }

        public void Delete(UserHistory userHistory)
        {
            _crudFactory.Delete(userHistory);
        }

    }
}
