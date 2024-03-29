﻿using System;
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
    [HandleError]
    [Authorize (Roles = "BCN Khoa")]
    public class ManageQuestionsController : Controller
    {
        DIEUBANTHUONGHOIWEBSITEEntities model = new DIEUBANTHUONGHOIWEBSITEEntities();

        // GET: Load All List Questions / AdminManageQuestions
        public ActionResult Index()
        {
            var question = model.CAU_HOI.AsNoTracking().OrderByDescending(x => x.ID).ToList();
            return View(question);
        }

        // GET: DANH_MUC / AdminManageQuestions
        public ActionResult Create()
        {
            ViewBag.ID_DANH_MUC = new SelectList(model.DANH_MUC, "ID", "DANH_MUC1");
            ViewBag.ID_TAI_KHOAN = new SelectList(model.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: CAU_HOI / AdminManageQuestions
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(CAU_HOI f)
        {
            ViewBag.ID_DANH_MUC = new SelectList(model.DANH_MUC, "ID", "DANH_MUC1", f.DANH_MUC);

            if (ModelState.IsValid)
            {
                var QuestionAlreadyExists = model.CAU_HOI.Any(x => x.CAU_HOI1 == f.CAU_HOI1);
                if (QuestionAlreadyExists)
                {
                    ModelState.AddModelError("CAU_HOI1", "Câu hỏi này đã tồn tại. Mời bạn nhập câu hỏi khác");
                    return View(f);
                }

                CAU_HOI question = new CAU_HOI();

                question.CAU_HOI1 = f.CAU_HOI1;
                question.MO_TA = f.MO_TA;
                question.ID_DANH_MUC = f.ID_DANH_MUC;
                question.NGAY_TAO = DateTime.Now;
                question.ID_TAI_KHOAN = User.Identity.GetUserId();
                question.DUYET_DANG = f.DUYET_DANG;
                model.CAU_HOI.Add(question);
                model.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(f);
        }

        // GET: List of data from CAU_HOI /AdminManageQuestions
        public ActionResult Edit(int id)
        {
            var question = model.CAU_HOI.Find(id);
            if (question == null)
            {
                return RedirectToAction("Error", "ErrorController");
            }
            ViewBag.ID_DANH_MUC = new SelectList(model.DANH_MUC, "ID", "DANH_MUC1", question.DANH_MUC);
            return View(question);
        }

        // POST: CAU_HOI / AdminManageQuestions
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int id, CAU_HOI f)
        {
            var question = model.CAU_HOI.FirstOrDefault(x => x.ID == id);
            question.MO_TA = f.MO_TA;
            question.ID_DANH_MUC = f.ID_DANH_MUC;
            question.ID_TAI_KHOAN = User.Identity.GetUserId();
            question.DUYET_DANG = f.DUYET_DANG;
            model.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: CAU_HOI / AdminManageQuestions
        public ActionResult Delete(int id)
        {
            var question = model.CAU_HOI.Find(id);
            if (question == null)
            {
                return RedirectToAction("Error", "ErrorController");
            }

            ViewBag.ResultMessage = TempData["ResultMessage"];
            return View(question);
        }

        // POST: CAU_HOI / AdminManageQuestions
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var CheckExitstsQuestion = model.CAU_TRA_LOI.OrderByDescending(x => x.ID).Where(x => x.ID_CAU_HOI == id).Count();
            if (CheckExitstsQuestion != 0)
            {
                TempData["ResultMessage"] = "This catalog cannot be deleted because there is an existing question comment. Please change status if you want to hide";
                return RedirectToAction("Delete", "ManageQuestions");
            }
            else
            {
                using (var scope = new TransactionScope())
                {
                    var question = model.CAU_HOI.Find(id);
                    model.CAU_HOI.Remove(question);
                    model.SaveChanges();

                    scope.Complete();
                    return RedirectToAction("Index");
                }
            }
        }

        // GET: CAU_HOI / AdminManageQuestions
        [OutputCache(CacheProfile = "Cache60Seconds")]
        public ActionResult Details(int id)
        {
            var question = model.CAU_HOI.Find(id);
            if (question == null)
            {
                return RedirectToAction("Error", "ErrorController");
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