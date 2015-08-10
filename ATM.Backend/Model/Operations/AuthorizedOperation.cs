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

namespace ATM.Backend.Model.Operations
{
    public class AuthorizedOperation<TReq, TResp> : BaseOperation<TReq, TResp>
        where TReq : AuthorizedRequest
        where TResp : AuthorizedResponse, new()
    {
        protected Session Session { get; set; }
        protected CardNumber CardNumber { get; set; }

        public AuthorizedOperation(ApiObject request) : base(request)
        {

        }

        protected override void Prepare()
        {
            base.Prepare();

            Session = Atm.CurrentSession;

            if (String.IsNullOrEmpty(RequestObject.SessionValue) || RequestObject.SessionValue != Session.SessionValue
                || Session.LastActivity.AddMinutes(Int32.Parse(ConfigManager.GetValue(ConfigManager.MaxSessionActivityMinutes))) < DateTime.Now
                || Session.CardNumber.IsDeleted)
            {
                Atm.CurrentSession = null;
                DbHelper.Update(Atm);

                throw new BaseException(ErrorCodes.PinAuthorization);
            }

            CardNumber = Session.CardNumber;

            Session.LastActivity = DateTime.Now;
            Session.SessionValue = HMACHelper.Hash(Session.CardNumber.Number + Session.CardNumber.Pin + Session.LastActivity + ConfigManager.GetValue(ConfigManager.SweetHashSalt));

            DbHelper.Update(Session);

            ResponseObject.SessionValue = Session.SessionValue;
        }
    }
}