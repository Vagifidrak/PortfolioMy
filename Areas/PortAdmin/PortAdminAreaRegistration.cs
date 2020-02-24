using System.Web.Mvc;

namespace MyPortfolio.Areas.PortAdmin
{
    public class PortAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PortAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PortAdmin_default",
                "PortAdmin/{controller}/{action}/{id}",
                new { action = "Index",controller="PortHome", id = UrlParameter.Optional },
                new string[] { "MyPortfolio.Areas.PortAdmin.Controllers" }
            );
        }
    }
}