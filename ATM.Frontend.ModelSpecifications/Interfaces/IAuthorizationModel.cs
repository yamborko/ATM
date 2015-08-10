using ATM.ApiObjects.Requests;
using ATM.ApiObjects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Frontend.ModelSpecifications.Interfaces
{
    public interface IAuthorizationModel
    {
        BaseResponse AuthenticateCardNumber(CardNumberAuthenticationRequest request);
        AuthorizedResponse AuthorizePin(PinAuthorizationRequest request);
        BaseResponse CloseSession(AuthorizedRequest request);
    }
}
