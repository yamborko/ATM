using ATM.ApiObjects.Requests;
using ATM.Frontend.ModelSpecifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATM.Frontend.Controllers
{
    public class CardNumberController : BaseController
    {

        protected ICardNumberModel CardNumberModel { get; set; }

        public CardNumberController(ICardNumberModel cardNumberModel)
        {
            CardNumberModel = cardNumberModel;
        }

        public ActionResult Navigation()
        {
            return PartialView();
        }

        public ActionResult CheckCardNumberBalance()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult CheckCardNumberBalance(CheckAccountBalanceRequest request)
        {
            var response = CardNumberModel.CheckAccountBalance(PrepareRequest(request));
            response.Date = DateTime.Now.ToString("dd/MM/yy");
            return Json(response);
        }

        public ActionResult WithdrawCash()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult WithdrawCash(CashWithdrawalRequest request)
        {
            var response = CardNumberModel.WithdrawCash(PrepareRequest(request));

            return Json(response);
        }

        public ActionResult CashWithdrawalReport()
        {
            return PartialView();
        }
    }
}