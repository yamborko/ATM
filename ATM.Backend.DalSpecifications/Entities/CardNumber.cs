using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Backend.DalSpecifications.Entities
{
    public class CardNumber : BaseEntity
    {
        public String Number { get; set; }

        public String Pin { get; set; }

        public Int32 AttemptsToAuthorize { get; set; }

        public Boolean IsBlocked { get; set; }

        public virtual List<Account> Accounts {get;set;}
    }
}
