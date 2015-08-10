using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Backend.DalSpecifications.Entities
{
    public class Account : BaseEntity
    {
        public String Number { get; set; }

        public Decimal BalanceAmount { get; set; }
    }
}
