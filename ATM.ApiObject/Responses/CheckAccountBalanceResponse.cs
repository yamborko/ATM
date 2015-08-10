using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.ApiObjects.Responses
{
    public class CheckAccountBalanceResponse : AuthorizedResponse
    {
        public Decimal Amount { get; set; }
        public String CardNumber { get; set; }
        public String Date { get; set; }
    }
}
