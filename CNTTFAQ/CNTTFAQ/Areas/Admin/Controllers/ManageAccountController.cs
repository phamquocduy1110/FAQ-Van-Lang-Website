using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using CNTTFAQ.Models;

namespace CNTTFAQ.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManageAccountController : Controller
    {
        DIEUBANTHUONGHOIWEBSITEEntities model = new DIEUBANTHUONGHOIWEBSITEEntities();

        // GET: Load All List Questions / AdminManageQuestions
        public ActionResult Index()
        {
            var listaccount = model.AspNetUsers.ToList().OrderByDescending(x => x.Id).ToList();
            return View(listaccount);
        }

        // GET: DANH_MUC / AdminManageQuestions
        public ActionResult Delete(string id)
        {
            var listaccount = model.AspNetUsers.Find(id);
            if (listaccount == null)
            {
                return HttpNotFound();
            }

            return View(listaccount);
        }

        // POST: DANH_MUC / AdminManageQuestions
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(string id)
        {
            using (var scope = new TransactionScope())
            {
                var listaccount = model.AspNetUsers.Find(id);
                model.AspNetUsers.Remove(listaccount);
                model.SaveChanges();

                scope.Complete();
                return RedirectToAction("Index");
            }
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