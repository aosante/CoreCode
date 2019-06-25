using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.API.Core
{
    public class GateManagement
    {

        private readonly GateCrudFactory crudGate;

        public GateManagement()
        {
            crudGate = new GateCrudFactory();
        }

        public void Create(Gate gate)
        {
            crudGate.Create(gate);
        }

        public List<Gate> RetrieveAll()
        {
            return crudGate.RetrieveAll<Gate>();
        }

        public Gate RetrieveById(Gate gate)
        {
            return crudGate.Retrieve<Gate>(gate);
        }

        public void Update(Gate gate)
        {
            crudGate.Update(gate);
        }

        public void Delete(Gate gate)
        {
            crudGate.Delete(gate);
        }

    }
}
