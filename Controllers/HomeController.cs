using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class HomeController : Controller
    {
        DevPortfolioDP DP = new DevPortfolioDP();

        public ActionResult Index()
        {
            ViewBag.Opinion = DP.Opinions.ToList();
            ViewBag.Portfolio = DP.Portfolios.ToList();
            ViewBag.ServicesCounters = DP.ServicesCounters.ToList();
            ViewBag.Services = DP.Services.ToList();
            ViewBag.AboutSkill = DP.AboutSkills.ToList();
            ViewBag.About = DP.AboutMes.ToList();
            ViewBag.header = DP.Headers.First();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}