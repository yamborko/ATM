using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATM.Frontend
{
    public static class NinjectWrapper
    {
        public static IKernel NinjectKernel = new StandardKernel();
    }
}