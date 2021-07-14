using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using CNTTFAQ.Models;

namespace CNTTFAQ.Controllers
{
    public class HomeController : Controller
    {
        DIEUBANTHUONGHOIWEBSITEEntities model = new DIEUBANTHUONGHOIWEBSITEEntities();

        public ActionResult Index()
        {
            if (User.IsInRole("BCN Khoa") || User.IsInRole("Admin"))
            {
                return Redirect("/SEP24Team11/Admin/AdminHome/Index");
            }
            var category = model.DANH_MUC.AsNoTracking().OrderByDescending(x => x.ID).ToList();
            return View(category);
        }
    }
}