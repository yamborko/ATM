using ATM.Backend.DalSpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Backend.DalSpecifications.Entities;
using ATM.Backend.Dal.Context;

namespace ATM.Backend.Dal
{
    public class LogHelper : ILogHelper
    {
        private DatabaseContext _context;

        public LogHelper()
        {
            _context = new DatabaseContext();
        }

        public void LogItem(LogItem item)
        {
            _context.LogItems.Add(item);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
