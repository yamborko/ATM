using ATM.ApiObjects.Requests;
using ATM.ApiObjects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Frontend.ModelSpecifications.Interfaces
{
    public interface ICardNumberModel
    {
        CheckAccountBalanceResponse CheckAccountBalance(CheckAccountBalanceRequest request);
        CashWithdrawalResponse WithdrawCash(CashWithdrawalRequest request);
    }
}
