using Microsoft.VisualStudio.TestTools.UnitTesting;
using CNTTFAQ.Areas.Admin.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using CNTTFAQ.Models;
using System.Linq;
using System;

namespace CNTTFAQ.Tests.Controllers
{
    [TestClass]
    public class ManageCatalogControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var controller = new ManageCatalogController();

            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);

            var model = result.Model as List<DANH_MUC>;
            Assert.IsNotNull(model);

            var db = new DIEUBANTHUONGHOIWEBSITEEntities();
            Assert.AreEqual(db.DANH_MUC.Count(), model.Count());
        }
    }
}
