using System.Web;
using System.Web.Optimization;

namespace ATM.Frontend
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/angular")
                //.Include("~/Scripts/angular.js")
                //.Include("~/Scripts/angular-ui-router.js")
                //.Include("~/Scripts/angular-resource.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/angularApp")
                .Include("~/Scripts/Controllers/NumPadController.js")
                .Include("~/Scripts/Controllers/SessionController.js")
                .Include("~/Scripts/Controllers/AuthenticationController.js")
                .Include("~/Scripts/Controllers/AuthorizationController.js")
                .Include("~/Scripts/Controllers/CardNumberBalanceController.js")
                .Include("~/Scripts/Controllers/CashWithdrawalController.js")
                .Include("~/Scripts/Controllers/ErrorsController.js")
                .IncludeDirectory("~/Scripts/Services/", "*.js")
                //.Include("~/Scripts/app.js")
                );

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/site.css"));
        }
    }
}
