using ATM.ApiObjects.Requests;
using ATM.Frontend.Model.Models;
using ATM.Frontend.ModelSpecifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATM.Frontend.Controllers
{
    public class BaseController : Controller
    {
        protected T PrepareRequest<T>(T request) where T : BaseRequest
        {
            request.IpAddress = "127.0.0.1";

            return request;
        }

        public ActionResult Error()
        {
            return PartialView("");
        }
    }
}