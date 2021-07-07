using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Transactions;
using System.Web.Mvc;
using CNTTFAQ.Models;

namespace CNTTFAQ.Areas.Admin.Controllers
{
    public class ManageCatalogController : Controller
    {
        DIEUBANTHUONGHOIWEBSITEEntities model = new DIEUBANTHUONGHOIWEBSITEEntities();
        private const string PICTURE_PATH = "~/Upload/SanPhams/";

        // GET: List of data from DANH_MUC /AdminManageCatalog
        public ActionResult Index()
        {
            var category = model.DANH_MUC.ToList();
            return View(category);
        }


        // GET: DANH_MUC / AdminManageCatalog
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ID_TAI_KHOAN = new SelectList(model.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: DANH_MUC / AdminManageCatalog
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(DANH_MUC f, HttpPostedFileBase HINH_ANH)
        {
            var category = new DANH_MUC();
            if (HINH_ANH.ContentLength > 0)
            {
                f.HINH_ANH = HINH_ANH.FileName;
                string FolderPath = Path.Combine(Server.MapPath("~/Images"), f.HINH_ANH);
                HINH_ANH.SaveAs(FolderPath);
            }
            string path = "/Images/" + f.HINH_ANH;
            category.DANH_MUC1 = f.DANH_MUC1;
            category.MO_TA = f.MO_TA;
            category.HINH_ANH = path;
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
            var category = model.DANH_MUC.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_TAI_KHOAN = new SelectList(model.AspNetUsers, "Id", "Email", category.AspNetUser);

            return View(category);
        }

        // POST: DANH_MUC / AdminManageCatalog
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int id, DANH_MUC f, HttpPostedFileBase HINH_ANH)
        {
            var category = model.DANH_MUC.FirstOrDefault(x => x.ID == id);
            if (HINH_ANH.ContentLength > 0)
            {
                f.HINH_ANH = HINH_ANH.FileName;
                string FolderPath = Path.Combine(Server.MapPath("~/Images"), f.HINH_ANH);
                HINH_ANH.SaveAs(FolderPath);
            }
            string path = "/Images/" + f.HINH_ANH;
            category.DANH_MUC1 = f.DANH_MUC1;
            category.MO_TA = f.MO_TA;
            category.HINH_ANH = path;
            category.NGAY_TAO = DateTime.Now;
            category.ID_TAI_KHOAN = f.ID_TAI_KHOAN;
            model.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: DANH_MUC / AdminManageCatalog
        public ActionResult Delete(int id)
        {
            var category = model.DANH_MUC.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: DANH_MUC / AdminManageCatalog
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            using (var scope = new TransactionScope())
            {
                var category = model.DANH_MUC.Find(id);
                model.DANH_MUC.Remove(category);
                model.SaveChanges();

                scope.Complete();
                return RedirectToAction("Index");
            }
        }

        // GET: DANH_MUC / AdminManageCatalog
        public ActionResult Details(int id)
        {
            var category = model.DANH_MUC.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                model.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}