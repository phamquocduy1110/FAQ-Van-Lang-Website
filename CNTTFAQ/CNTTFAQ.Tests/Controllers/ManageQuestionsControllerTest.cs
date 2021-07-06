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
    public class ManageQuestionsControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var controller = new ManageQuestionsController();

            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);

            var model = result.Model as List<CAU_HOI>;
            Assert.IsNotNull(model);

            var db = new DIEUBANTHUONGHOIWEBSITEEntities();
            Assert.AreEqual(db.CAU_HOI.Count(), model.Count());
        }

        [TestMethod]
        public void CreateG()
        {
            var controller = new ManageCatalogController();

            var result = controller.Create() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}
