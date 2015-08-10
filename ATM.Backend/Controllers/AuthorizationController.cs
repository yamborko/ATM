using ATM.ApiObjects.Requests;
using ATM.ApiObjects.Responses;
using ATM.Backend.DalSpecifications;
using ATM.Backend.Model.Operations.AuthorizationsOperations;
using ATM.Backend.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ATM.Backend.Controllers
{
    public class AuthorizationController : ApiController
    {
        [HttpPost]
        public ApiObject AuthenticateCardNumber(ApiObject request)
        {
            var operation = new CardNumberAuthenticationOperation(request);
            operation.Execute();

            return operation.Response;
        }

        [HttpPost]
        public ApiObject AuthorizePin(ApiObject request)
        {
            var operation = new PinAuthorizationOperation(request);
            operation.Execute();

            return operation.Response;
        }

        [HttpPost]
        public ApiObject CloseSession(ApiObject request)
        {
            var operation = new CloseSessionOperation(request);
            operation.Execute();

            return operation.Response;
        }
    }
}