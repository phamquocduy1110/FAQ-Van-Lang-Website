using Microsoft.VisualStudio.TestTools.UnitTesting;
using CNTTFAQ.Areas.Admin.Controllers;
using CNTTFAQ.Models;
using System.Linq;
using System.Web.Mvc;

namespace CNTTFAQ.Tests.Controllers
{
    [TestClass]
    public class AdminHomeControllerTest
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
        public void Calendar()
        {
            AdminHomeController controller = new AdminHomeController();

            ViewResult result = controller.Calendar() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}
