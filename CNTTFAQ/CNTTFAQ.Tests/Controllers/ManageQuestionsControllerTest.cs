using Microsoft.VisualStudio.TestTools.UnitTesting;
using CNTTFAQ.Areas.Admin.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using CNTTFAQ.Models;
using System.Transactions;
using System.Linq;
using System;
using System.Web;

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
            var controller = new ManageQuestionsController();

            var result = controller.Create() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateP()
        {
            var rand = new Random();
            var question = new CAU_HOI
            {
                CAU_HOI1 = rand.NextDouble().ToString(),
                MO_TA = rand.NextDouble().ToString(),
                ID_DANH_MUC = rand.Next(),
                NGAY_TAO = DateTime.Now,
                ID_TAI_KHOAN = "Id"
            };
            
            var controller = new ManageQuestionsController();
            var result = controller.Create(question) as ViewResult;
            Assert.IsNotNull(result);
            controller.ModelState.Clear();
        }

        [TestMethod]
        public void EditG()
        {
            var controller = new ManageQuestionsController();
            var result0 = controller.Edit(0) as HttpNotFoundResult;
            Assert.IsNotNull(result0);

            var db = new DIEUBANTHUONGHOIWEBSITEEntities();
            var question = db.CAU_HOI.First();
            var result1 = controller.Edit(question.ID) as ViewResult;
            Assert.IsNotNull(result1);

            var model = result1.Model as CAU_HOI;
            Assert.IsNotNull(model);
            Assert.AreEqual(question.CAU_HOI1, model.CAU_HOI1);
            Assert.AreEqual(question.MO_TA, model.MO_TA);
            Assert.AreEqual(question.ID_DANH_MUC, model.ID_DANH_MUC);
            Assert.AreEqual(question.NGAY_TAO, model.NGAY_TAO);
            Assert.AreEqual(question.ID_TAI_KHOAN, model.ID_TAI_KHOAN);
            Assert.AreEqual(question.LUOT_XEM, model.LUOT_XEM);
            Assert.AreEqual(question.DUYET_DANG, model.DUYET_DANG);
        }

        [TestMethod]
        public void DeleteG()
        {
            var controller = new ManageQuestionsController();
            var result0 = controller.Delete(0) as HttpNotFoundResult;
            Assert.IsNotNull(result0);

            var db = new DIEUBANTHUONGHOIWEBSITEEntities();
            var question = db.CAU_HOI.First();
            var result1 = controller.Delete(question.ID) as ViewResult;
            Assert.IsNotNull(result1);

            var model = result1.Model as CAU_HOI;
            Assert.IsNotNull(model);
            Assert.AreEqual(question.CAU_HOI1, model.CAU_HOI1);
            Assert.AreEqual(question.MO_TA, model.MO_TA);
            Assert.AreEqual(question.ID_DANH_MUC, model.ID_DANH_MUC);
            Assert.AreEqual(question.NGAY_TAO, model.NGAY_TAO);
            Assert.AreEqual(question.ID_TAI_KHOAN, model.ID_TAI_KHOAN);
            Assert.AreEqual(question.LUOT_XEM, model.LUOT_XEM);
            Assert.AreEqual(question.DUYET_DANG, model.DUYET_DANG);
        }

        [TestMethod]
        public void DeleteP()
        {
            var db = new DIEUBANTHUONGHOIWEBSITEEntities();
            var question = db.CAU_HOI.AsNoTracking().First();

            var controller = new ManageQuestionsController();
            using (var scope = new TransactionScope())
            {
                var result1 = controller.DeleteConfirm(question.ID) as RedirectToRouteResult;
                Assert.IsNotNull(result1);
                Assert.AreEqual("Index", result1.RouteValues["action"]);

                var entity = db.CAU_HOI.Find(question.ID);
                Assert.IsNull(entity);
            }
        }

        [TestMethod]
        public void Details()
        {
            var controller = new ManageQuestionsController();
            var result0 = controller.Details(0) as HttpNotFoundResult;
            Assert.IsNotNull(result0);

            var db = new DIEUBANTHUONGHOIWEBSITEEntities();
            var question = db.CAU_HOI.First();
            var result1 = controller.Details(question.ID) as ViewResult;
            Assert.IsNotNull(result1);

            var model = result1.Model as CAU_HOI;
            Assert.IsNotNull(model);
            Assert.AreEqual(question.CAU_HOI1, model.CAU_HOI1);
            Assert.AreEqual(question.MO_TA, model.MO_TA);
            Assert.AreEqual(question.ID_DANH_MUC, model.ID_DANH_MUC);
            Assert.AreEqual(question.NGAY_TAO, model.NGAY_TAO);
            Assert.AreEqual(question.ID_TAI_KHOAN, model.ID_TAI_KHOAN);
            Assert.AreEqual(question.LUOT_XEM, model.LUOT_XEM);
            Assert.AreEqual(question.DUYET_DANG, model.DUYET_DANG);
        }

        [TestMethod]
        public void TestDispose()
        {
            using (var controller = new ManageQuestionsController()) { }
        }
    }
}
