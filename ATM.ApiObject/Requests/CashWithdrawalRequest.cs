using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.ApiObjects.Requests
{
    public class CashWithdrawalRequest : AuthorizedRequest
    {
        public Decimal Amount { get; set; }
    }
}
