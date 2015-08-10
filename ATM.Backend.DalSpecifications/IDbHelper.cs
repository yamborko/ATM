using ATM.Backend.DalSpecifications.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Backend.DalSpecifications
{
    public interface IDbHelper : IDisposable
    {
        T Create<T>(T entity) where T : BaseEntity;

        T Update<T>(T entity) where T : BaseEntity;

        List<T> Where<T>(Expression<Func<T, Boolean>> expression) where T : BaseEntity;

        List<T> Remove<T>(Expression<Func<T, Boolean>> expression) where T : BaseEntity;
    }
}
