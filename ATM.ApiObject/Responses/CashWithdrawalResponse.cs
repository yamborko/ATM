using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.ApiObjects.Responses
{
    public class CashWithdrawalResponse : AuthorizedResponse
    {
        public String TransactionTime { get; set; }
        public Int32 TransactionId { get; set; }
        public String CardNumber { get; set; }
        public Decimal Amount { get; set; }
        public Decimal Balance { get; set; }
    }
}
