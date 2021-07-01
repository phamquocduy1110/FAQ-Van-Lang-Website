using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNTTFAQ.Models;

namespace CNTTFAQ.Areas.Admin.Controllers
{
    public class ManageCatalogController : Controller
    {
        DIEUBANTHUONGHOIWEBSITEEntities model = new DIEUBANTHUONGHOIWEBSITEEntities();

        // GET: List of data from DANH_MUC /AdminManageCatalog
        public ActionResult Index()
        {
            var category = model.DANH_MUC.ToList().OrderByDescending(x => x.ID).ToList();
            return View(category);
        }

        // GET: DANH_MUC / AdminManageCatalog
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.account_type = model.TAI_KHOAN.OrderByDescending(x => x.ID).ToList();
            return View();
        }

        // POST: DANH_MUC / AdminManageCatalog
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(DANH_MUC f, HttpPostedFileBase IMAGE_URL)
        {
            var category = new DANH_MUC();

            category.DANH_MUC1 = f.DANH_MUC1;
            category.MO_TA = f.MO_TA;
            category.HINH_ANH = f.HINH_ANH;
            category.NGAY_TAO = DateTime.Now;
            category.ID_TAI_KHOAN = f.ID_TAI_KHOAN;
            model.DANH_MUC.Add(category);
            model.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: List of data from DANH_MUC /AdminManageCatalog
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = model.DANH_MUC.FirstOrDefault(x => x.ID == id);
            ViewBag.account_type = model.TAI_KHOAN.OrderByDescending(x => x.ID).ToList();
            return View(category);
        }

        // POST: DANH_MUC / AdminManageCatalog
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int id, DANH_MUC f, HttpPostedFileBase IMAGE_URL)
        {
            var category = model.DANH_MUC.FirstOrDefault(x => x.ID == id);
            category.DANH_MUC1 = f.DANH_MUC1;
            category.MO_TA = f.MO_TA;
            category.HINH_ANH = f.HINH_ANH;
            category.NGAY_TAO = DateTime.Now;
            category.ID_TAI_KHOAN = f.ID_TAI_KHOAN;
            model.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: DANH_MUC / AdminManageCatalog
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var category = model.DANH_MUC.FirstOrDefault(x => x.ID == id);
            return View(category);
        }

        // POST: DANH_MUC / AdminManageCatalog
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var category = model.DANH_MUC.FirstOrDefault(x => x.ID == id);
            model.DANH_MUC.Remove(category);
            model.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: DANH_MUC / AdminManageCatalog
        [HttpGet, ValidateInput(false)]
        public ActionResult Details(int id)
        {
            var category = model.DANH_MUC.FirstOrDefault(x => x.ID == id);
            return View(category);
        }
    }
}