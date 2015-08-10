using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATM.Backend.DalSpecifications;
using ATM.Backend.Dal;
using ATM.Backend.DalSpecifications.Entities;
using System.Linq.Expressions;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IDbHelper worker = new DbHelper();

            worker.Create(new Account { BalanceAmount = 1, Number = "1" });

            var list = worker.Where<Account>((x) => true);

            list.FirstOrDefault().BalanceAmount = 34534;

            worker.Remove<Account>((x) => x.Id == 1);

            var entity = worker.Update<Account>(list[0]);

            worker.Dispose();
        }
    }
}
