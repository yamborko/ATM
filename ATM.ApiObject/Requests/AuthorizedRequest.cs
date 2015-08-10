using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.ApiObjects.Requests
{
    public class AuthorizedRequest : BaseRequest
    {
        public String SessionValue { get; set; }
    }
}
