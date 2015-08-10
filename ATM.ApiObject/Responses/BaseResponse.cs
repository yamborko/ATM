using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.ApiObjects.Responses
{
    public class BaseResponse
    {
        public Int32 ErrorCode { get; set; }

        public String ErrorMessage { get; set; }

        public String DebugMessage { get; set; }
    }
}
