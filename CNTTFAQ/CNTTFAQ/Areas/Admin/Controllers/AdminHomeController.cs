using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using CNTTFAQ.Models;

namespace CNTTFAQ.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminHomeController : Controller
    {
        DIEUBANTHUONGHOIWEBSITEEntities model = new DIEUBANTHUONGHOIWEBSITEEntities();

        // GET: Admin Index/AdminHome
        public ActionResult Index()
        {
            var clients = model.AspNetUsers.OrderByDescending(x => x.Id).Count();
            ViewBag.client = clients;

            var questions = model.CAU_HOI.OrderByDescending(x => x.ID).Count();
            ViewBag.question = questions;

            var categories = model.DANH_MUC.OrderByDescending(x => x.ID).Count();
            ViewBag.category = categories;

            var views = model.CAU_HOI.Sum(x => x.LUOT_XEM);
            ViewBag.view = views;

            var questionAnswers = model.CAU_TRA_LOI.OrderByDescending(x => x.ID).Count();
            ViewBag.questionAnswer = questionAnswers;

            var askQuestions = model.GUI_CAU_HOI.OrderByDescending(x => x.ID).Count();
            ViewBag.askQuestion = askQuestions;

            var QuestionsApproved = model.CAU_HOI.OrderByDescending(x => x.ID).Where(x => x.DUYET_DANG != false).Count();
            ViewBag.QuestionApproved = QuestionsApproved;

            var QuestionsNotApproved = model.CAU_HOI.OrderByDescending(x => x.ID).Where(x => x.DUYET_DANG != true).Count();
            ViewBag.QuestionNotApproved = QuestionsNotApproved;

            var QuestionsSeen = model.GUI_CAU_HOI.OrderByDescending(x => x.ID).Where(x => x.TRANG_THAI != false).Count();
            ViewBag.QuestionSeen = QuestionsSeen;

            var QuestionsNotSeen = model.GUI_CAU_HOI.OrderByDescending(x => x.ID).Where(x => x.TRANG_THAI != true).Count();
            ViewBag.QuestionNotSeen = QuestionsNotSeen;

            return View();
        }

        public ActionResult ColumnChart()
        {
            var _context = model;
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();

            var result = (from c in _context.CAU_HOI select c);
            result.ToList().ForEach(rs => xValue.Add(rs.CAU_HOI1));
            result.ToList().ForEach(rs => yValue.Add(rs.LUOT_XEM));

            new Chart(width: 600, height: 400, theme:ChartTheme.Vanilla)
            .AddSeries("Default", chartType: "Column", xValue: xValue, yValues: yValue)
            .Write("bmp");

            return null;
        }

        // GET: Admin Calendar/AdminHome
        public ActionResult Calendar()
        {
            return View();
        }
    }
}