using ATM.Frontend.ModelSpecifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.ApiObjects.Requests;
using ATM.ApiObjects.Responses;

namespace ATM.Frontend.Model.Models
{
    public class CardNumberModel : ApiHelper, ICardNumberModel
    {
        public CashWithdrawalResponse WithdrawCash(CashWithdrawalRequest request)
        {
            return Send<CashWithdrawalRequest, CashWithdrawalResponse>(request, "/api/CardNumbers/WithdrawCash");
        }

        public CheckAccountBalanceResponse CheckAccountBalance(CheckAccountBalanceRequest request)
        {
            return Send<CheckAccountBalanceRequest, CheckAccountBalanceResponse>(request, "/api/CardNumbers/CheckAccountBalance");
        }
    }
}
