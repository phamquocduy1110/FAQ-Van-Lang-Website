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
                return RedirectToRoute(new { action = "Index", controller = "AdminHome", area = "Admin" });
            }
            else
            { 
                var category = model.DANH_MUC.OrderByDescending(x => x.ID).ToList();

                var maxquestions = model.CAU_HOI
                                .OrderByDescending(p => p.LUOT_XEM)
                                .Take(6);
                ViewBag.MaxQuestion = maxquestions;

                return View(category);
            }
        }
    }
}