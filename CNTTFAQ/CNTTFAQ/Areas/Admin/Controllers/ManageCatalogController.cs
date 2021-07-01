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
        DIEUBANTHUONGHOIWEBSITEEntities model = new DIEUBANTHUONGHOIWEBSITEEntities();

        // GET: Admin/AdminManageCatalog
        public ActionResult Index()
        {
            var catalog = model.DANH_MUC.ToList().OrderByDescending(x => x.ID).ToList();
            return View(catalog);
        }
    }
}