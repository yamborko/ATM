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
    public class AuthorizationModel : ApiHelper, IAuthorizationModel
    {
        public BaseResponse AuthenticateCardNumber(CardNumberAuthenticationRequest request)
        {
            return Send<CardNumberAuthenticationRequest, BaseResponse>(request, "/api/Authorization/AuthenticateCardNumber");
        }

        public AuthorizedResponse AuthorizePin(PinAuthorizationRequest request)
        {
            return Send<PinAuthorizationRequest, AuthorizedResponse>(request, "/api/Authorization/AuthorizePin");
        }

        public BaseResponse CloseSession(AuthorizedRequest request)
        {
            return Send<AuthorizedRequest, BaseResponse>(request, "/api/Authorization/CloseSession");
        }
    }
}
