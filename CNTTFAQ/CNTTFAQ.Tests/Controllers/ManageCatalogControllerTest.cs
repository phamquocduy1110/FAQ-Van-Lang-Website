using Microsoft.VisualStudio.TestTools.UnitTesting;
using CNTTFAQ.Areas.Admin.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using CNTTFAQ.Models;
using System.Linq;
using System.Transactions;
using System.Web;
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

        [TestMethod]
        public void CreateG()
        {
            var controller = new ManageCatalogController();

            var result = controller.Create() as ViewResult;

            Assert.IsNotNull(result);
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
            Assert.AreEqual(category.DANH_MUC1, model.ID);
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
        }

        [TestMethod]
        public void Details()
        {
            var controller = new ManageQuestionsController();
            var result0 = controller.Details(0) as HttpNotFoundResult;
            Assert.IsNotNull(result0);

            var db = new DIEUBANTHUONGHOIWEBSITEEntities();
            var category = db.DANH_MUC.First();
            var result1 = controller.Details(category.ID) as ViewResult;
            Assert.IsNotNull(result1);

            var model = result1.Model as DANH_MUC;
            Assert.IsNotNull(model);
            Assert.AreEqual(category.DANH_MUC1, model.DANH_MUC1);
            Assert.AreEqual(category.MO_TA, model.MO_TA);
            Assert.AreEqual(category.NGAY_TAO, model.NGAY_TAO);
            Assert.AreEqual(category.ID_TAI_KHOAN, model.ID_TAI_KHOAN);

            /*var controller = new ProductsController();
            var result0 = controller.Delete(0) as HttpNotFoundResult;
            Assert.IsNotNull(result0);

            var db = new CsK24T26Entities();
            var product = db.Products.First();
            var result1 = controller.Details(product.id) as ViewResult;
            Assert.IsNotNull(result1);

            var model = result1.Model as Product;
            Assert.IsNotNull(model);
            Assert.AreEqual(product.name, model.name);
            Assert.AreEqual(product.price, model.price);
            Assert.AreEqual(product.product_description, model.product_description);*/
        }

        [TestMethod]
        public void TestDispose()
        {
            using (var controller = new ManageQuestionsController()) { }
        }

    }
}
