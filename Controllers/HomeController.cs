using SINEST.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SINEST.Controllers
{
    [Authenticated]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
