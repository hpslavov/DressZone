using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DressZone.Server.Controllers
{
    public class ProductDetailsController : BaseController
    {

        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }
    }
}