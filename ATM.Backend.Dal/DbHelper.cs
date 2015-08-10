using ATM.Backend.DalSpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Backend.DalSpecifications.Entities;
using System.Linq.Expressions;
using ATM.Backend.Dal.Context;

namespace ATM.Backend.Dal
{
    public class DbHelper : IDbHelper
    {
        private DatabaseContext _context;

        public DbHelper()
        {
            _context = new DatabaseContext();
        }

        public T Create<T>(T entity) where T : BaseEntity
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public List<T> Remove<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            var set = _context.Set<T>();
            var list = set.RemoveRange(set.Where(expression));

            _context.SaveChanges();

            return list.ToList();
        }

        public T Update<T>(T entity) where T : BaseEntity
        {
            var entry = _context.Entry(entity);
            entry.State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        public List<T> Where<T>(Expression<Func<T, bool>> expression) where T : BaseEntity
        {
            return _context.Set<T>().Where(expression).ToList();
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
