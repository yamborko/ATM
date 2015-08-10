using ATM.ApiObjects;
using ATM.ApiObjects.Requests;
using ATM.ApiObjects.Responses;
using ATM.Backend.DalSpecifications.Entities;
using ATM.Backend.Model.Exceptions;
using ATM.Backend.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATM.Backend.Model.Operations.AccountsOperations
{
    public class CheckAccountBalanceOperation : AuthorizedOperation<CheckAccountBalanceRequest, CheckAccountBalanceResponse>
    {
        public const Int32 OperationCode = 1;

        public CheckAccountBalanceOperation(ApiObject request) : base(request)
        {

        }

        protected override void Prepare()
        {
            base.Prepare();

            CardNumber = Session.CardNumber;

            if(CardNumber.Accounts.Count == 0)
            {
                throw new BaseException(ErrorCodes.AccountNotExists);
            }
        }

        protected override void Proceed()
        {
            base.Proceed();

            DbHelper.Create(new Transaction { CardNumber = CardNumber, Code = OperationCode });
        }

        protected override void Finish()
        {
            base.Finish();

            ResponseObject.Amount = CardNumber.Accounts.First((x) => !x.IsDeleted).BalanceAmount;
            ResponseObject.CardNumber = CardNumber.Number;
        }
    }
}