using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Backend.DalSpecifications.Entities
{
    public class TransactionParam : BaseEntity
    {
        public String Name { get; set; }
        public String Value { get; set; }

        public virtual Transaction Transaction { get; set; }
    }
}
