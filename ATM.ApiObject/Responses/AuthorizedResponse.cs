using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.ApiObjects.Responses
{
    public class AuthorizedResponse : BaseResponse
    {
        public String SessionValue { get; set; }
        public Int32 AttemptsLeft { get; set; }
    }
}
