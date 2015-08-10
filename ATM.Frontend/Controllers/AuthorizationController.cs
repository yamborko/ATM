using ATM.ApiObjects.Requests;
using ATM.Frontend.ModelSpecifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATM.Frontend.Controllers
{
    public class AuthorizationController : BaseController
    {
        protected IAuthorizationModel AuthorizationModel { get; set; }

        public AuthorizationController(IAuthorizationModel authorizationModel)
        {
            AuthorizationModel = authorizationModel;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AuthenticateCardNumber()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult AuthenticateCardNumber(CardNumberAuthenticationRequest request)
        {
            var response = AuthorizationModel.AuthenticateCardNumber(PrepareRequest(request));

            return Json(response);
        }

        public ActionResult AuthorizePin()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult AuthorizePin(PinAuthorizationRequest request)
        {
            var response = AuthorizationModel.AuthorizePin(PrepareRequest(request));

            return Json(response);
        }

        public ActionResult SessionControls()
        {
            return PartialView();
        }
    }
}