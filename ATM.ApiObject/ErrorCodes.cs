using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.ApiObjects
{
    public enum ErrorCodes
    {
        Default,
        CardAuthentication,
        CardAuthenticationRequestedValue,
        PinAuthorization,
        PinAuthorizationRequestedValue,
        TooLowBalance,
        WithdrawAmountRequestedValue,
        AccountNotExists,
        NotEnoughCash,
        AtmNotExists,
        AtmIsBlocked,
        InvalidData,
        CardNumberNotExists,
        CardNumberIsBlocked,
        WrongPinCode,
        FailedConnection
    }
}
