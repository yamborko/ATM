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
            { ErrorCodes.Default, "Произошла ошибка" },
            { ErrorCodes.FailedConnection, "Невозможно подключиться к серверу" },
            { ErrorCodes.AccountNotExists, "Произошла ошибка" },
            { ErrorCodes.AtmIsBlocked, "Банкомат временно заблокирован" },
            { ErrorCodes.AtmNotExists, "Банкомата с таким ID не существует" },
            { ErrorCodes.CardAuthentication, "Такой номер карты не существует" },
            { ErrorCodes.CardAuthenticationRequestedValue, "Введите правильный номер карты" },
            { ErrorCodes.CardNumberIsBlocked, "Карта заблокирована" },
            { ErrorCodes.CardNumberNotExists, "Карта не существует" },
            { ErrorCodes.InvalidData, "Плохие данные" },
            { ErrorCodes.NotEnoughCash, "Недостаточно денег на счету" },
            { ErrorCodes.PinAuthorization, "Введите правильный пин-код" },
            { ErrorCodes.PinAuthorizationRequestedValue, "Введите правильный пин-код" },
            { ErrorCodes.TooLowBalance, "Слишком низкий баланс" },
            { ErrorCodes.WithdrawAmountRequestedValue, "Лимит снятия 50000" },
            { ErrorCodes.WrongPinCode, "Введите правильный пин-код" },

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
