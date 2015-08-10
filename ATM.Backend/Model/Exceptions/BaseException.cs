using ATM.ApiObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATM.Backend.Model.Exceptions
{
    public class BaseException : Exception
    {
        public ErrorCodes ErrorCode { get; set; }

        public BaseException(ErrorCodes errorCode)
        {
            ErrorCode = errorCode;
        }
    }
}