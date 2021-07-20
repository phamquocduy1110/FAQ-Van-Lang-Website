using Microsoft.VisualStudio.TestTools.UnitTesting;
using CNTTFAQ.Areas.Admin.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using CNTTFAQ.Models;
using System.Transactions;
using System.Linq;
using System;

namespace CNTTFAQ.Tests.Controllers
{
    [TestClass]
    public class CommentControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var controller = new CommentController();

            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);

            var model = result.Model as List<CAU_TRA_LOI>;
            Assert.IsNotNull(model);

            var db = new DIEUBANTHUONGHOIWEBSITEEntities();
            Assert.AreEqual(db.CAU_TRA_LOI.Count(), model.Count());
        }

        [TestMethod]
        public void CreateG()
        {
            var controller = new CommentController();

            var result = controller.Create() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateP()
        {
            var rand = new Random();
            var comment = new CAU_TRA_LOI
            {
                ID_CAU_HOI = rand.Next(),
                CAU_TRA_LOI1 = rand.NextDouble().ToString(),
                NGAY_TRA_LOI = DateTime.Now,
                ID_TAI_KHOAN = "45efa018-f768-46bf-836c-59bafc776fc4"
            };

            var controller = new CommentController();
            var result = controller.Create() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(comment);
            controller.ModelState.Clear();
        }

        [TestMethod]
        public void EditG()
        {
            var controller = new CommentController();
            var result0 = controller.Edit(0) as HttpNotFoundResult;
            Assert.IsNotNull(result0);

            var db = new DIEUBANTHUONGHOIWEBSITEEntities();
            var comment = db.CAU_TRA_LOI.First();
            var result1 = controller.Edit(comment.ID) as ViewResult;
            Assert.IsNotNull(result1);

            var model = result1.Model as CAU_TRA_LOI;
            Assert.IsNotNull(model);
            Assert.AreEqual(comment.ID_CAU_HOI, model.ID_CAU_HOI);
            Assert.AreEqual(comment.CAU_TRA_LOI1, model.CAU_TRA_LOI1);
        }

        [TestMethod]
        public void EditP()
        {
            var db = new DIEUBANTHUONGHOIWEBSITEEntities();
            var controller = new CommentController();

            var cautraloi = db.CAU_TRA_LOI.First();
            var result = controller.Edit(cautraloi.ID) as ViewResult;

            var Models = result.Model as CAU_TRA_LOI;
            Assert.IsNotNull(result);
            Assert.AreEqual(cautraloi.ID_CAU_HOI, Models.ID_CAU_HOI);
            Assert.AreEqual(cautraloi.CAU_TRA_LOI1, Models.CAU_TRA_LOI1);
        }

        [TestMethod]
        public void DeleteG()
        {
            var controller = new CommentController();
            var result0 = controller.Delete(0) as HttpNotFoundResult;
            Assert.IsNotNull(result0);

            var db = new DIEUBANTHUONGHOIWEBSITEEntities();
            var comment = db.CAU_TRA_LOI.First();
            var result1 = controller.Delete(comment.ID) as ViewResult;
            Assert.IsNotNull(result1);

            var model = result1.Model as CAU_TRA_LOI;
            Assert.IsNotNull(model);
            Assert.AreEqual(comment.ID_CAU_HOI, model.ID_CAU_HOI);
            Assert.AreEqual(comment.CAU_TRA_LOI1, model.CAU_TRA_LOI1);
            Assert.AreEqual(comment.NGAY_TRA_LOI, model.NGAY_TRA_LOI);
            Assert.AreEqual(comment.ID_TAI_KHOAN, model.ID_TAI_KHOAN);
        }

        [TestMethod]
        public void DeleteP()
        {
            var db = new DIEUBANTHUONGHOIWEBSITEEntities();
            var comment = db.CAU_TRA_LOI.AsNoTracking().First();

            var controller = new CommentController();
            using (var scope = new TransactionScope())
            {
                var result1 = controller.DeleteConfirm(comment.ID) as RedirectToRouteResult;
                Assert.IsNotNull(result1);
                Assert.AreEqual("Index", result1.RouteValues["action"]);
            }
        }

        [TestMethod]
        public void Details()
        {
            var controller = new CommentController();
            var result0 = controller.Details(0) as HttpNotFoundResult;
            Assert.IsNotNull(result0);

            var db = new DIEUBANTHUONGHOIWEBSITEEntities();
            var question = db.CAU_TRA_LOI.First();
            var result1 = controller.Details(question.ID) as ViewResult;
            Assert.IsNotNull(result1);

            var model = result1.Model as CAU_TRA_LOI;
            Assert.IsNotNull(model);
            Assert.AreEqual(question.ID_CAU_HOI, model.ID_CAU_HOI);
            Assert.AreEqual(question.CAU_TRA_LOI1, model.CAU_TRA_LOI1);
            Assert.AreEqual(question.NGAY_TRA_LOI, model.NGAY_TRA_LOI);
            Assert.AreEqual(question.ID_TAI_KHOAN, model.ID_TAI_KHOAN);
        }

        [TestMethod]
        public void TestDispose()
        {
            using (var controller = new ManageQuestionsController()) { }
        }


    }
}
