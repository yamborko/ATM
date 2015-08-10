using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Backend.DalSpecifications.Entities
{
    public class Session : BaseEntity
    {
        public DateTime LastActivity { get; set; }

        public String SessionValue { get; set; }

        public virtual CardNumber CardNumber {get;set;}
    }
}
