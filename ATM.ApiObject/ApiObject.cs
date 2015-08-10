using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.ApiObjects.Requests
{
    public class ApiObject
    {
        public Guid AtmGuid { get; set; }
        public Byte[] Data { get; set; }
        public Byte[] Key { get; set; }
    }
}
