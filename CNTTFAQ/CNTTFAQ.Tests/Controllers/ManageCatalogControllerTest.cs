using Microsoft.VisualStudio.TestTools.UnitTesting;
using CNTTFAQ.Areas.Admin.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using CNTTFAQ.Models;
using System.Linq;
using System.Transactions;
using System.Web;
using System;
using System.IO;

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

        [TestMethod]
        public void CreateG()
        {
            var controller = new ManageCatalogController();

            var result = controller.Create() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateP()
        {
            var rand = new Random();
            var question = new DANH_MUC
            {
                HINH_ANH = "~/SEP24Team11/Images/a.jpg",
                DANH_MUC1 = rand.NextDouble().ToString(),
                MO_TA = rand.NextDouble().ToString(),               
                NGAY_TAO = DateTime.Now,
                ID_TAI_KHOAN = "45efa018-f768-46bf-836c-59bafc776fc4"
            };

            var controller = new ManageQuestionsController();
            var result = controller.Create() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(question);
            controller.ModelState.Clear();
        }

        [TestMethod]
        public void EditG()
        {
            var controller = new ManageCatalogController();
            var r0 = controller.Edit(0) as HttpNotFoundResult;
            Assert.IsNotNull(r0);

            var db = new DIEUBANTHUONGHOIWEBSITEEntities();
            var category = db.DANH_MUC.First();
            var r1 = controller.Edit(category.ID) as ViewResult;
            Assert.IsNotNull(r1);

            var model = r1.Model as DANH_MUC;
            Assert.IsNotNull(model);
            Assert.AreEqual(category.DANH_MUC1, model.DANH_MUC1);
            Assert.AreEqual(category.MO_TA, model.MO_TA);
            Assert.AreEqual(category.HINH_ANH, model.HINH_ANH);
            Assert.AreEqual(category.NGAY_TAO, model.NGAY_TAO);
            Assert.AreEqual(category.ID_TAI_KHOAN, model.ID_TAI_KHOAN);
        }

        [TestMethod]
        public void DeleteG()
        {
            var controller = new ManageCatalogController();
            var r0 = controller.Delete(0) as HttpNotFoundResult;
            Assert.IsNotNull(r0);

            var db = new DIEUBANTHUONGHOIWEBSITEEntities();
            var category = db.DANH_MUC.First();
            var r1 = controller.Delete(category.ID) as ViewResult;
            Assert.IsNotNull(r1);

            var model = r1.Model as DANH_MUC;
            Assert.IsNotNull(model);
            Assert.AreEqual(category.DANH_MUC1, model.DANH_MUC1);
            Assert.AreEqual(category.MO_TA, model.MO_TA);
            Assert.AreEqual(category.HINH_ANH, model.HINH_ANH);
            Assert.AreEqual(category.NGAY_TAO, model.NGAY_TAO);
            Assert.AreEqual(category.ID_TAI_KHOAN, model.ID_TAI_KHOAN);
        }

        [TestMethod]
        public void DeleteP()
        {
            var db = new DIEUBANTHUONGHOIWEBSITEEntities();
            var category = db.DANH_MUC.AsNoTracking().First();

            var controller = new ManageQuestionsController();
            using (var scope = new TransactionScope())
            {
                var result1 = controller.DeleteConfirm(category.ID) as RedirectToRouteResult;
                Assert.IsNotNull(result1);
                Assert.AreEqual("Index", result1.RouteValues["action"]);
            }
        }

        [TestMethod]
        public void Details()
        {
            var controller = new ManageCatalogController();
            var r0 = controller.Edit(0) as HttpNotFoundResult;
            Assert.IsNotNull(r0);

            var db = new DIEUBANTHUONGHOIWEBSITEEntities();
            var category = db.DANH_MUC.First();
            var r1 = controller.Edit(category.ID) as ViewResult;
            Assert.IsNotNull(r1);

            var model = r1.Model as DANH_MUC;
            Assert.IsNotNull(model);
            Assert.AreEqual(category.DANH_MUC1, model.DANH_MUC1);
            Assert.AreEqual(category.MO_TA, model.MO_TA);
            Assert.AreEqual(category.HINH_ANH, model.HINH_ANH);
            Assert.AreEqual(category.NGAY_TAO, model.NGAY_TAO);
            Assert.AreEqual(category.ID_TAI_KHOAN, model.ID_TAI_KHOAN);
        }

        [TestMethod]
        public void TestDispose()
        {
            using (var controller = new ManageQuestionsController()) { }
        }

    }
}
