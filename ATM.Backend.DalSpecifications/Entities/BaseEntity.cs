using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Backend.DalSpecifications.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreationTime = DateTime.Now;
        }

        [Key]
        public Int32 Id { get; set; }

        public Boolean IsDeleted { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
