using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Backend.DalSpecifications.Entities
{
    public class Transaction : BaseEntity
    {
        public Int32 Code { get; set; }

        public virtual CardNumber CardNumber {get;set;}

        public virtual List<TransactionParam> Params { get; set; }
    }
}
