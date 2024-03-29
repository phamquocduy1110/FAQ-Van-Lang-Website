﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Transactions;
using Microsoft.AspNet.Identity;
using CNTTFAQ.Models;
using System.Web.Mvc;

namespace CNTTFAQ.Areas.Admin.Controllers
{
    [HandleError]
    [Authorize(Roles = "BCN Khoa")]
    public class StudentQuestionController : Controller
    {
        DIEUBANTHUONGHOIWEBSITEEntities model = new DIEUBANTHUONGHOIWEBSITEEntities();

        // GET: Admin/StudentQuestion
        public ActionResult Index()
        {
            var studentquestion = model.GUI_CAU_HOI.AsNoTracking().OrderByDescending(x => x.ID).ToList();
            return View(studentquestion);
        }

        // GET: List of data from CAU_HOI /AdminManageQuestions
        public ActionResult Edit(int id)
        {
            var askquestion = model.GUI_CAU_HOI.Find(id);
            if (askquestion == null)
            {
                return RedirectToAction("Error", "ErrorController");
            }

            return View(askquestion);
        }

        // POST: CAU_HOI / AdminManageQuestions
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int id, GUI_CAU_HOI f)
        {
            var askquestion = model.GUI_CAU_HOI.FirstOrDefault(x => x.ID == id);
            askquestion.HO_TEN = f.HO_TEN;
            askquestion.CAU_HOI_MUON_HOI = f.CAU_HOI_MUON_HOI;
            askquestion.TRANG_THAI = f.TRANG_THAI;
            askquestion.MO_TA = f.MO_TA;
            model.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: CAU_HOI_TU_SINH_VIEN / StudentQuestion
        public ActionResult Delete(int id)
        {
            var studentquestion = model.GUI_CAU_HOI.Find(id);
            if (studentquestion == null)
            {
                return RedirectToAction("Error", "ErrorController");
            }

            return View(studentquestion);
        }

        // POST: CAU_HOI / AdminManageQuestions
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            using (var scope = new TransactionScope())
            {
                var studentquestion = model.GUI_CAU_HOI.Find(id);
                model.GUI_CAU_HOI.Remove(studentquestion);
                model.SaveChanges();

                scope.Complete();
                return RedirectToAction("Index");
            }
        }

        // GET: CAU_HOI_TU_SINH_VIEN / AdminStudentQuestion
        public ActionResult Details(int id)
        {
            var studentquestion = model.GUI_CAU_HOI.Find(id);
            if (studentquestion == null)
            {
                return RedirectToAction("Error", "ErrorController");
            }
            return View(studentquestion);
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