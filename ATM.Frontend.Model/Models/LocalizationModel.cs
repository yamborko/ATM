using ATM.ApiObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Frontend.Model.Models
{
    public static class LocalizationModel
    {
        private static Dictionary<ErrorCodes, String> Errors = new Dictionary<ErrorCodes, string> {
            { ErrorCodes.Default, "Error" },
            { ErrorCodes.FailedConnection, "Connection problems" },
            { ErrorCodes.AccountNotExists, "Error" },
            { ErrorCodes.AtmIsBlocked, "ATM is blocked" },
            { ErrorCodes.AtmNotExists, "ATM is not exists" },
            { ErrorCodes.CardAuthentication, "Card is not exists" },
            { ErrorCodes.CardAuthenticationRequestedValue, "Wrond card number" },
            { ErrorCodes.CardNumberIsBlocked, "Card number is blocked" },
            { ErrorCodes.CardNumberNotExists, "Card is not exists" },
            { ErrorCodes.InvalidData, "Invalid data" },
            { ErrorCodes.NotEnoughCash, "Low balance" },
            { ErrorCodes.PinAuthorization, "Wrong pin-code" },
            { ErrorCodes.PinAuthorizationRequestedValue, "Wrong pin-code" },
            { ErrorCodes.TooLowBalance, "Low balance" },
            { ErrorCodes.WithdrawAmountRequestedValue, "Limit 50000" },
            { ErrorCodes.WrongPinCode, "Wrong pin-code" },

        };

        public static String GetError(Int32 code)
        {
            return Errors[(ErrorCodes)code];
        }

        public static String GetValue(String name)
        {
            return "";
        }
    }
}
