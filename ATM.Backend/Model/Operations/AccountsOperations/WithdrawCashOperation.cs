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
    public class WithdrawCashOperation : AuthorizedOperation<CashWithdrawalRequest, CashWithdrawalResponse>
    {
        public const Int32 OperationCode = 2;

        public WithdrawCashOperation(ApiObject request) : base(request)
        {

        }

        protected override void Prepare()
        {
            base.Prepare();

            if(RequestObject.Amount > Int32.Parse(ConfigManager.GetValue(ConfigManager.WithdrawLimit)))
            {
                throw new BaseException(ErrorCodes.WithdrawAmountRequestedValue);
            }

            if (CardNumber.Accounts.Count((x) => !x.IsDeleted) == 0)
            {
                throw new BaseException(ErrorCodes.AccountNotExists);
            }

            var account = CardNumber.Accounts.First((x) => !x.IsDeleted);

            if(account.BalanceAmount < RequestObject.Amount)
            {
                throw new BaseException(ErrorCodes.TooLowBalance);
            }

            if(RequestObject.Amount > Atm.CashAmount)
            {
                throw new BaseException(ErrorCodes.NotEnoughCash);
            }
        }

        protected override void Proceed()
        {
            base.Proceed();

            var account = CardNumber.Accounts.First((x) => !x.IsDeleted);

            account.BalanceAmount -= RequestObject.Amount;
            Atm.CashAmount -= RequestObject.Amount;

            var transaction = new Transaction
            {
                CardNumber = CardNumber,
                Code = OperationCode,
                Params = new List<TransactionParam>()
                {
                    new TransactionParam { Name = "Amount", Value = RequestObject.Amount.ToString() }
                }
            };
            DbHelper.Create(transaction);

            ResponseObject.TransactionId = transaction.Id;
            ResponseObject.TransactionTime = transaction.CreationTime.ToString("dd.MM.yy H:mm:ss");

            DbHelper.Update(account);
            DbHelper.Update(Atm);
        }

        protected override void Finish()
        {
            base.Finish();

            ResponseObject.CardNumber = CardNumber.Number;
            ResponseObject.Balance = CardNumber.Accounts.FirstOrDefault().BalanceAmount;
            ResponseObject.Amount = RequestObject.Amount;

        }
    }
}