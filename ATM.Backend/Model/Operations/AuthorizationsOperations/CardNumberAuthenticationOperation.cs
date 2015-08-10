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

namespace ATM.Backend.Model.Operations.AuthorizationsOperations
{
    public class CardNumberAuthenticationOperation : BaseOperation<CardNumberAuthenticationRequest, BaseResponse>
    { 
        public CardNumberAuthenticationOperation(ApiObject request) : base(request)
        {

        }

        protected override void Prepare()
        {
            base.Prepare();

            if(String.IsNullOrEmpty(RequestObject.CardNumber) || RequestObject.CardNumber.Length > Int32.Parse(ConfigManager.GetValue(ConfigManager.MaxCardNumberLength)))
            {
                throw new BaseException(ErrorCodes.CardAuthenticationRequestedValue);
            }
        }

        protected override void Proceed()
        {
            base.Proceed();

            var cardNumber = DbHelper.Where<CardNumber>((x) => x.Number == RequestObject.CardNumber && !x.IsDeleted).FirstOrDefault();

            if(cardNumber == null)
            {
                throw new BaseException(ErrorCodes.CardNumberNotExists);
            }

            if (cardNumber.IsBlocked)
            {
                throw new BaseException(ErrorCodes.CardNumberIsBlocked);
            }
        }

        protected override void Finish()
        {
            base.Finish();
        }
    }
}