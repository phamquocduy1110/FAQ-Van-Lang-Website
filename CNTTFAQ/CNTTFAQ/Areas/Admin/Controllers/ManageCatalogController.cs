﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNTTFAQ.Models;

namespace CNTTFAQ.Areas.Admin.Controllers
{
    public class ManageCatalogController : Controller
    {
        QUANLYCAUHOIEntities model = new QUANLYCAUHOIEntities();

        // GET: Admin/AdminManageCatalog
        public ActionResult Index()
        {
            var catalog = model.CATEGORies.ToList().OrderByDescending(x => x.ID).ToList();
            return View(catalog);
        }
    }
}