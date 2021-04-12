using Salud.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Salud.Controllers
{
    [SessionExpire]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

 
    }
}