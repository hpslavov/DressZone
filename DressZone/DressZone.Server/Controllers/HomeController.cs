using DressZone.Context.Contracts;
using DressZone.Models.Shop;
using DressZone.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DressZone.Server.Models;
using DressZone.Server.Infrastructure.Mapping.Contracts;

namespace DressZone.Server.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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