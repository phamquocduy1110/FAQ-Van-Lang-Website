using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNTTFAQ.Models;

namespace CNTTFAQ.Areas.Admin.Controllers
{
    public class ManageCatalogController : Controller
    {
<<<<<<< HEAD
        DIEUBANTHUONGHOIWEBSITEEntities model = new DIEUBANTHUONGHOIWEBSITEEntities();
=======
>>>>>>> 56fbbedbc75c134afb30dd7d86177d41dd806aa3

        // GET: Admin/AdminManageCatalog
        public ActionResult Index()
        {
<<<<<<< HEAD
            var catalog = model.DANH_MUC.ToList().OrderByDescending(x => x.ID).ToList();
            return View(catalog);
=======
            return View();
>>>>>>> 56fbbedbc75c134afb30dd7d86177d41dd806aa3
        }
    }
}