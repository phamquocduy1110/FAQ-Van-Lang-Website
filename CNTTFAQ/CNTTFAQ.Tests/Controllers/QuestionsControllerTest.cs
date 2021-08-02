using System;
using CNTTFAQ.Models;
using System.Linq;
using CNTTFAQ.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using PagedList;
using System.Collections.Generic;
using System.Web.UI;

namespace CNTTFAQ.Tests.Controllers
{
    [TestClass]
    public class QuestionsControllerTest
    {
        [TestMethod]
        public void Index()
        {
            DIEUBANTHUONGHOIWEBSITEEntities model = new DIEUBANTHUONGHOIWEBSITEEntities();

            var model1 = model.AspNetUsers.Count();
            var model2 = model.CAU_HOI.Count();
            var model3 = model.DANH_MUC.Count();
            var model4 = model.CAU_HOI.Sum(x => x.LUOT_XEM);
            var model5 = model.CAU_TRA_LOI.Count();
            var model6 = model.GUI_CAU_HOI.Count();
            var model7 = model.CAU_HOI.Where(x => x.DUYET_DANG != false).Count();
            var model8 = model.CAU_HOI.Where(x => x.DUYET_DANG != true).Count();
            var model9 = model.GUI_CAU_HOI.Where(x => x.TRANG_THAI != false).Count();
            var model10 = model.GUI_CAU_HOI.Where(x => x.TRANG_THAI != true).Count();

            var db = new DIEUBANTHUONGHOIWEBSITEEntities();
            Assert.AreEqual(db.AspNetUsers.Count(), model1);
            Assert.AreEqual(db.CAU_HOI.Count(), model2);
            Assert.AreEqual(db.DANH_MUC.Count(), model3);
            Assert.AreEqual(db.CAU_HOI.Sum(x => x.LUOT_XEM), model4);
            Assert.AreEqual(db.CAU_TRA_LOI.Count(), model5);
            Assert.AreEqual(db.GUI_CAU_HOI.Count(), model6);
            Assert.AreEqual(db.CAU_HOI.Where(x => x.DUYET_DANG != false).Count(), model7);
            Assert.AreEqual(db.CAU_HOI.Where(x => x.DUYET_DANG != true).Count(), model8);
            Assert.AreEqual(db.GUI_CAU_HOI.Where(x => x.TRANG_THAI != false).Count(), model9);
            Assert.AreEqual(db.GUI_CAU_HOI.Where(x => x.TRANG_THAI != true).Count(), model10);
        }

        [TestMethod]
        public void Search(int? page)
        {
            var db = new DIEUBANTHUONGHOIWEBSITEEntities();
            var question = db.CAU_HOI.ToList();
            var keyword = question.First().CAU_HOI1.Split().First();
            question = question.Where(p => p.CAU_HOI1.ToLower().Contains(keyword.ToLower())).ToList();


            var controller = new QuestionsController();
            var result = controller.Search(keyword, page) as ViewResult;
            Assert.IsNotNull(result);

            var model = result.Model as List<CAU_HOI>;
            Assert.IsNotNull(model);


            Assert.AreEqual(question.Count(), model.Count);
            Assert.AreEqual("Index", result.ViewName);
            Assert.AreEqual(keyword, result.ViewData["keyword"]);
        }
    }
}
