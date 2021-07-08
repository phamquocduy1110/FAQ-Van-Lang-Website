using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Transactions;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CNTTFAQ.Models;

namespace CNTTFAQ.Areas.Admin.Controllers
{
    [Authorize (Roles = "BCN Khoa")]
    public class ManageQuestionsController : Controller
    {
        DIEUBANTHUONGHOIWEBSITEEntities model = new DIEUBANTHUONGHOIWEBSITEEntities();

        // GET: Load All List Questions / AdminManageQuestions
        public ActionResult Index()
        {
            var question = model.CAU_HOI.ToList();
            return View(question);
        }

        // GET: DANH_MUC / AdminManageQuestions
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ID_TAI_KHOAN = new SelectList(model.AspNetUsers, "Id", "Email");
            ViewBag.ID_DANH_MUC = new SelectList(model.DANH_MUC, "ID", "DANH_MUC1");
            return View();
        }

        // POST: CAU_HOI / AdminManageQuestions
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(CAU_HOI f)
        {
            var question = new CAU_HOI();

            question.CAU_HOI1 = f.CAU_HOI1;
            question.MO_TA = f.MO_TA;
            question.ID_DANH_MUC = f.ID_DANH_MUC;
            question.NGAY_TAO = DateTime.Now;
            question.ID_TAI_KHOAN = f.ID_TAI_KHOAN;
            model.CAU_HOI.Add(question);
            model.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: List of data from CAU_HOI /AdminManageQuestions
        public ActionResult Edit(int id)
        {
            var question = model.CAU_HOI.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_TAI_KHOAN = new SelectList(model.AspNetUsers, "Id", "Email", question.AspNetUser);
            ViewBag.ID_DANH_MUC = new SelectList(model.DANH_MUC, "ID", "DANH_MUC1", question.DANH_MUC);

            return View(question);
        }

        // POST: CAU_HOI / AdminManageQuestions
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int id, CAU_HOI f)
        {
            var question = model.CAU_HOI.FirstOrDefault(x => x.ID == id);
            question.CAU_HOI1 = f.CAU_HOI1;
            question.MO_TA = f.MO_TA;
            question.ID_DANH_MUC = f.ID_DANH_MUC;
            question.NGAY_TAO = DateTime.Now;
            question.ID_TAI_KHOAN = f.ID_TAI_KHOAN;
            model.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: DANH_MUC / AdminManageQuestions
        public ActionResult Delete(int id)
        {
            var question = model.CAU_HOI.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }

            return View(question);
        }

        // POST: DANH_MUC / AdminManageQuestions
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            using(var scope = new TransactionScope())
            {
                var question = model.CAU_HOI.Find(id);
                model.CAU_HOI.Remove(question);
                model.SaveChanges();

                scope.Complete();
                return RedirectToAction("Index");
            }
        }

        // GET: CAU_HOI / AdminManageQuestions
        public ActionResult Details(int id)
        {
            var question = model.CAU_HOI.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
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