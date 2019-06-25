using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreCode.DataAccess.Mapper;
using CoreCode.Entities.POJO;
using DataAccess.Crud;
using DataAccess.Dao;

namespace CoreCode.DataAccess.Crud
{
    public class RequestAirlineAirportCrud : CrudFactory
    {
        private readonly RequestAirlineAirportMapper mapper;
        private readonly AirportMapper am;


        public RequestAirlineAirportCrud()
        {

            am = new AirportMapper();

            mapper = new RequestAirlineAirportMapper();
            dao = SqlDao.GetInstance();
        }


        public override void Create(BaseEntity entity)
        {
            var request = (RequestAirlineAirport)entity;
            var sqlOperation = mapper.GetCreateStatement(request);
            dao.ExecuteProcedure(sqlOperation);
        }

        public override T Retrieve<T>(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

     

        public override void Update(BaseEntity entity)
        {
            var request = (RequestAirlineAirport)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(request));
        }

        public override void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
