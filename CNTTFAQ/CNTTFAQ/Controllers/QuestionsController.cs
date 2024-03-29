﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;
using System.Web.Helpers;
using CNTTFAQ.Areas.Admin.Controllers;
using Microsoft.AspNet.Identity;
using CNTTFAQ.Models;

namespace CNTTFAQ.Controllers
{
    [HandleError]
    public class QuestionsController : Controller
    {
        DIEUBANTHUONGHOIWEBSITEEntities model = new DIEUBANTHUONGHOIWEBSITEEntities();

        // GET: Questions / Questions
        public ActionResult Index(int? page, int? category)
        {
            var pageNumber = page ?? 1;
            var pageSize = 5;

            if (User.IsInRole("BCN Khoa") || User.IsInRole("Admin"))
            {
                return RedirectToRoute(new { action = "Index", controller = "AdminHome", area = "Admin" });
            }

            else if (category != null)
            {
                ViewBag.category = category;
                var quesionList = model.CAU_HOI.OrderByDescending(x => x.ID).Where(x => x.ID_DANH_MUC == category && x.DUYET_DANG != false).ToPagedList(pageNumber, pageSize);
                ViewBag.ResultMessage = TempData["ResultMessage"];
                return PartialView(quesionList);
            }
            else
            {
                var quesionList = model.CAU_HOI.OrderByDescending(x => x.ID).Where(x => x.DUYET_DANG != false).ToPagedList(pageNumber, pageSize);
                ViewBag.ResultMessage = TempData["ResultMessage"];
                return PartialView(quesionList);
            }
        }

        // POST: CAU_HOI / AdminManageQuestions
        [Authorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult Index(GUI_CAU_HOI f)
        {
            var askquestion = new GUI_CAU_HOI();

            askquestion.HO_TEN = f.HO_TEN;
            askquestion.ID_TAI_KHOAN = User.Identity.GetUserId();
            askquestion.CAU_HOI_MUON_HOI = f.CAU_HOI_MUON_HOI;
            askquestion.MO_TA = f.MO_TA;
            askquestion.NGAY_CHINH_SUA = DateTime.Now;
            model.GUI_CAU_HOI.Add(askquestion);
            TempData["ResultMessage"] = "Post successfully.";
            model.SaveChanges();
            return RedirectToAction("Index", "Questions");
        }

        // GET: Question by Category / Questions
        [AllowAnonymous]
        [OutputCache(Duration = 60)]
        public PartialViewResult CategoryPartical()
        {
            var categoryList = model.DANH_MUC.OrderByDescending(x => x.DANH_MUC1).ToList();
            return PartialView(categoryList);
        }

        [AllowAnonymous]
        [OutputCache(Duration = 60)]
        public ActionResult Search(string keyword, int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 5;

            var search = model.CAU_HOI.OrderByDescending(x => x.ID)
                                      .Where(x => x.CAU_HOI1.ToLower().Contains(keyword.ToLower()) || x.MO_TA.ToLower().Contains(keyword.ToLower()))
                                      .ToPagedList(pageNumber, pageSize);
            ViewBag.keyword = keyword;
            return View("Index", search);

        }

        public ActionResult Details(int id)
        {
            var question = model.CAU_HOI.Find(id);
            if (question == null)
            {
                return RedirectToAction("Error", "ErrorController");
            }
            question.LUOT_XEM++;
            model.SaveChanges();
            ViewBag.ResultMessage = TempData["ResultMessage"];
            return View(question);
        }

        [Authorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult Details(GUI_CAU_HOI f)
        {
            if (!ModelState.IsValid)
            {
                var askquestion = new GUI_CAU_HOI();

                askquestion.HO_TEN = f.HO_TEN;
                askquestion.ID_TAI_KHOAN = User.Identity.GetUserId();
                askquestion.CAU_HOI_MUON_HOI = f.CAU_HOI_MUON_HOI;
                askquestion.MO_TA = f.MO_TA;
                askquestion.NGAY_CHINH_SUA = DateTime.Now;
                model.GUI_CAU_HOI.Add(askquestion);
                model.SaveChanges();
                TempData["ResultMessage"] = "Post successfully.";
                return RedirectToAction("Details", "Questions");

            }

            return View(f);
        }
    }
}