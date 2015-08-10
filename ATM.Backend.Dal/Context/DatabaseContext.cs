using ATM.Backend.DalSpecifications.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Backend.Dal.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Session> Sessions { get; set; }
        public DbSet<CardNumber> CardNumbers { get; set; }
        public DbSet<AtmInstance> AtmInstances { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<LogItem> LogItems { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public DatabaseContext() : base("DefaultConnection")
        {
            Database.SetInitializer<DatabaseContext>(new MigrateDatabaseToLatestVersion<DatabaseContext, Configuration>());
        }


    }
}
