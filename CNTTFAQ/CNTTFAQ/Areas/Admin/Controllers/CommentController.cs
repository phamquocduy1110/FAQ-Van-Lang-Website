using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Transactions;
using Microsoft.AspNet.Identity;
using CNTTFAQ.Models;
using System.Web.Mvc;

namespace CNTTFAQ.Areas.Admin.Controllers
{
    [HandleError]
    [Authorize(Roles = "BCN Khoa")]
    public class CommentController : Controller
    {
        DIEUBANTHUONGHOIWEBSITEEntities model = new DIEUBANTHUONGHOIWEBSITEEntities();

        // GET: CAU_TRA_LOI / Comment
        public ActionResult Index()
        {
            var comment = model.CAU_TRA_LOI.AsNoTracking().OrderByDescending(x => x.ID).ToList();
            return View(comment);
        }

        // GET: CAU_HOI / Comment
        public ActionResult Create()
        {
            ViewBag.ID_CAU_HOI = new SelectList(model.CAU_HOI, "ID", "CAU_HOI1");
            return View();
        }

        // POST: CAU_TRA_LOI / Comment
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(CAU_TRA_LOI f)
        {
            ViewBag.ID_CAU_HOI = new SelectList(model.CAU_HOI, "ID", "CAU_HOI1", f.CAU_HOI);

            if (ModelState.IsValid)
            {
                CAU_TRA_LOI comment = new CAU_TRA_LOI();

                comment.ID_CAU_HOI = f.ID_CAU_HOI;
                comment.CAU_TRA_LOI1 = f.CAU_TRA_LOI1;
                comment.NGAY_TRA_LOI = DateTime.Now;
                comment.ID_TAI_KHOAN = User.Identity.GetUserId();
                model.CAU_TRA_LOI.Add(comment);
                model.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(f);
        }

        // GET: CAU_TRA_LOI / Comment
        public ActionResult Edit(int id)
        {
            var comment = model.CAU_TRA_LOI.Find(id);
            if (comment == null)
            {
                return RedirectToAction("Error", "ErrorController");
            }
            ViewBag.ID_CAU_HOI = new SelectList(model.CAU_HOI, "ID", "CAU_HOI1", comment.CAU_HOI);

            return View(comment);
        }

        // POST: CAU_TRA_LOI / Comment
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int id, CAU_TRA_LOI f)
        {
            var comment = model.CAU_TRA_LOI.FirstOrDefault(x => x.ID == id);
            comment.ID_CAU_HOI = f.ID_CAU_HOI;
            comment.CAU_TRA_LOI1 = f.CAU_TRA_LOI1;
            comment.ID_TAI_KHOAN = User.Identity.GetUserId();
            model.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: CAU_TRA_LOI / Comment
        public ActionResult Delete(int id)
        {
            var comment = model.CAU_TRA_LOI.Find(id);
            if (comment == null)
            {
                return RedirectToAction("Error", "ErrorController");
            }

            return View(comment);
        }

        // POST: CAU_TRA_LOI / Comment
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            using (var scope = new TransactionScope())
            {
                var comment = model.CAU_TRA_LOI.Find(id);
                model.CAU_TRA_LOI.Remove(comment);
                model.SaveChanges();

                scope.Complete();
                return RedirectToAction("Index");
            }
        }

        // GET: CAU_TRA_LOI / Comment
        [OutputCache(CacheProfile = "Cache60Seconds")]
        public ActionResult Details(int id)
        {
            var comment = model.CAU_TRA_LOI.Find(id);
            if (comment == null)
            {
                return RedirectToAction("Error", "ErrorController");
            }
            return View(comment);
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