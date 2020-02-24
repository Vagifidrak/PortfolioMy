using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Areas.PortAdmin.Controllers
{

    public class PortHomeController : Controller
    {
        DevPortfolioDP DP = new DevPortfolioDP();

        // GET: PortAdmin/PortHome
        public ActionResult Index()
        {
            return View();
        }
    }
}