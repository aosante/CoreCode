using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.Entities.POJO
{
    public class Airport : BaseEntity
    {

        public string ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ZipCode { get; set; }
        public decimal GateTariff { get; set; }
        public decimal RunwayTariff { get; set; }
        public decimal Tax { get; set; }
        public bool Status { get; set; }
        public bool Asigned { get; set; }
        public List<Store> StoreList { get; set; }
        public List<Gate> GateList { get; set; }
       // public List<Store> StoreList { get; set; }
       // public List<Store> StoreList { get; set; }
        
    }
}
