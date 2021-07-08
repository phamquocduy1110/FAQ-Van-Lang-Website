using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CNTTFAQ.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: Admin Index/AdminHome
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin Calendar/AdminHome
        public ActionResult Calendar()
        {
            return View();
        }
    }
}