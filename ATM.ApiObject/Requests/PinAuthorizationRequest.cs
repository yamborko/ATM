using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.ApiObjects.Requests
{
    public class PinAuthorizationRequest : CardNumberAuthenticationRequest
    {
        public String Pin { get; set; }
    }
}
