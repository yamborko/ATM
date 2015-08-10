using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATM.Backend
{
    public static class ConfigManager
    {
        public const String MaxInvalidRequestsNumber = "MaxInvalidRequestsNumber";
        public const String MaxInvalidRequestsPeriodMinutes = "MaxInvalidRequestsPeriodMinutes";
        public const String MaxCardNumberLength = "MaxCardNumberLength";
        public const String MaxPinLength = "MaxPinLength";
        public const String MaxAttemptsToAuthorizeCardNumber = "MaxAttemptsToAuthorizeCardNumber";
        public const String SweetHashSalt = "SweetHashSalt";
        public const String MaxSessionActivityMinutes = "MaxSessionActivityMinutes";
        public const String WithdrawLimit = "WithdrawLimit";
        public const String AesVectorSalt = "AesVectorSalt"; 

        public static String GetValue(String name)
        {
            return ConfigurationManager.AppSettings.Get(name);
        }

    }
}