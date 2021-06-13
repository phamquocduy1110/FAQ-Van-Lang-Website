using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dieubanthuonghoi.Areas.Admin.Controllers
{
    public class ManageQuestionsController : Controller
    {
        // GET: Admin/ListQuestionsAdmin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/ListQuestionsAdmin Create Question
        public ActionResult CreateQuestion()
        {
            return View();
        }
    }
}