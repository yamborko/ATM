using ATM.Backend.DalSpecifications.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Backend.DalSpecifications
{
    public interface ILogHelper : IDisposable
    {
        void LogItem(LogItem item);
    }
}
