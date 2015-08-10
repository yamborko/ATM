using ATM.ApiObjects.Requests;
using ATM.ApiObjects.Responses;
using ATM.Backend.Model.Operations.AccountsOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ATM.Backend.Controllers
{
    public class CardNumbersController : ApiController
    {

        [HttpPost]
        public ApiObject WithdrawCash(ApiObject request)
        {
            var operation = new WithdrawCashOperation(request);
            operation.Execute();

            return operation.Response;
        }

        [HttpPost]
        public ApiObject CheckAccountBalance(ApiObject request)
        {
            var operation = new CheckAccountBalanceOperation(request);
            operation.Execute();

            return operation.Response;
        }

    }
}
