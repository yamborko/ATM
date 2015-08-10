using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Backend.DalSpecifications.Entities
{
    public class AtmInstance : BaseEntity
    {
        public String IpAddress { get; set; }

        public Decimal CashAmount { get; set; }

        public Int32 NumberOfSuspiciousActivities { get; set; }

        public DateTime FirstSuspiciousActivityTime { get; set; }

        public Boolean IsBlocked { get; set; }

        public Guid AtmGuid { get; set; }

        public String RSAPublicKey { get; set; }
        public String RSAPrivateKey { get; set; }

        public virtual Session CurrentSession { get; set; }
    }
}
