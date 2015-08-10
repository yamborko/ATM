using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.ApiObjects.Requests
{
    public class CardNumberAuthenticationRequest : BaseRequest
    {
        public String CardNumber { get; set; }
    }
}
