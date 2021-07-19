using CNTTFAQ;
using CNTTFAQ.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CNTTFAQ.Models;
using CNTTFAQ.Areas.Admin.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace CNTTFAQ.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {

        [TestMethod]
        public void Index()
        {
            DIEUBANTHUONGHOIWEBSITEEntities model = new DIEUBANTHUONGHOIWEBSITEEntities();

            var model1 = model.AspNetUsers.Count();
            var model2 = model.CAU_HOI.Count();
            var model3 = model.DANH_MUC.Count();

            var db = new DIEUBANTHUONGHOIWEBSITEEntities();
            Assert.AreEqual(db.AspNetUsers.Count(), model1);
            Assert.AreEqual(db.CAU_HOI.Count(), model2);
            Assert.AreEqual(db.DANH_MUC.Count(), model3);
        }
    }
}
