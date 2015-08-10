using ATM.ApiObjects.Requests;
using ATM.ApiObjects.Responses;
using ATM.Backend.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATM.Backend.Model.Operations.AuthorizationsOperations
{
    public class CloseSessionOperation : BaseOperation<BaseRequest, BaseResponse>
    {
        public CloseSessionOperation(ApiObject request) : base(request)
        {

        }

        protected override void Proceed()
        {
            base.Proceed();

            Atm.CurrentSession = null;
            DbHelper.Update(Atm);
        }
    }
}