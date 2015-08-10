using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Backend.DalSpecifications.Entities
{
    public class LogItem : BaseEntity
    {
        public String Tag { get; set; }

        public Int32 ErrorCode { get; set; }

        public String Trace { get; set; }

        public String Description { get; set; }

    }
}
