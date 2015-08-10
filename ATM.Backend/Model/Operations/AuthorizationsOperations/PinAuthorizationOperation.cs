using ATM.ApiObjects;
using ATM.ApiObjects.Requests;
using ATM.ApiObjects.Responses;
using ATM.Backend.DalSpecifications.Entities;
using ATM.Backend.Model.Exceptions;
using ATM.Backend.Model.Helpers;
using ATM.Backend.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATM.Backend.Model.Operations.AuthorizationsOperations
{
    public class PinAuthorizationOperation : BaseOperation<PinAuthorizationRequest, AuthorizedResponse>
    {
        public PinAuthorizationOperation(ApiObject request) : base(request)
        {

        }

        protected override void Prepare()
        {
            base.Prepare();

            if (String.IsNullOrEmpty(RequestObject.CardNumber) || RequestObject.CardNumber.Length > Int32.Parse(ConfigManager.GetValue(ConfigManager.MaxCardNumberLength)))
            {
                throw new BaseException(ErrorCodes.CardAuthenticationRequestedValue);
            }

            if (String.IsNullOrEmpty(RequestObject.Pin) || RequestObject.Pin.Length > Int32.Parse(ConfigManager.GetValue(ConfigManager.MaxPinLength)))
            {
                throw new BaseException(ErrorCodes.PinAuthorizationRequestedValue);
            }
        }

        protected override void Proceed()
        {
            base.Proceed();

            var cardNumber = DbHelper.Where<CardNumber>((x) => x.Number == RequestObject.CardNumber && !x.IsDeleted).FirstOrDefault();

            if (cardNumber == null)
            {
                throw new BaseException(ErrorCodes.CardNumberNotExists);
            }
            if (cardNumber.IsBlocked)
            {
                throw new BaseException(ErrorCodes.CardNumberIsBlocked);
            }

            if (cardNumber.Pin != RequestObject.Pin)
            {
                cardNumber.AttemptsToAuthorize++;
                DbHelper.Update(cardNumber);

                if (cardNumber.AttemptsToAuthorize > Int32.Parse(ConfigManager.GetValue(ConfigManager.MaxAttemptsToAuthorizeCardNumber)))
                {
                    cardNumber.IsBlocked = true;
                    DbHelper.Update(cardNumber);

                    throw new BaseException(ErrorCodes.CardNumberIsBlocked);
                }

                ResponseObject.AttemptsLeft = Int32.Parse(ConfigManager.GetValue(ConfigManager.MaxAttemptsToAuthorizeCardNumber)) - cardNumber.AttemptsToAuthorize;

                throw new BaseException(ErrorCodes.WrongPinCode);
            }

            cardNumber.AttemptsToAuthorize = 0;

            var session = DbHelper.Where<Session>((x) => x.CardNumber.Id == cardNumber.Id && !x.IsDeleted).FirstOrDefault();
            var lastActivity = DateTime.Now;

            if (session == null)
            {
                session = DbHelper.Create(new Session { LastActivity = lastActivity });
            }

            session.CardNumber = cardNumber;
            session.LastActivity = lastActivity;
            session.SessionValue = HMACHelper.Hash(cardNumber.Number + cardNumber.Pin + lastActivity + ConfigManager.GetValue(ConfigManager.SweetHashSalt));

            Atm.CurrentSession = session;

            DbHelper.Update(cardNumber);
            DbHelper.Update(session);
            DbHelper.Update(Atm);
        }

        protected override void Finish()
        {
            base.Finish();

            ResponseObject.SessionValue = Atm.CurrentSession.SessionValue;
        }
    }
}