using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using System.Web.Mvc;
using CNTTFAQ.Models;

namespace CNTTFAQ.Controllers
{
    public class QuestionsController : Controller
    {
        DIEUBANTHUONGHOIWEBSITEEntities model = new DIEUBANTHUONGHOIWEBSITEEntities();

        // GET: Questions / Questions
        [AllowAnonymous]
        public ActionResult Index(int? page, int? category)
        {
            var pageNumber = page ?? 1;
            var pageSize = 5;

            if (User.IsInRole("BCN Khoa") || User.IsInRole("Admin"))
            {
                return Redirect("/SEP24Team11/Admin/AdminHome/Index");
            }

            else if (category != null)
            {
                ViewBag.category = category;
                var quesionList = model.CAU_HOI.OrderByDescending(x => x.ID).Where(x => x.ID_DANH_MUC == category).ToPagedList(pageNumber, pageSize);
                return PartialView(quesionList);
            }
            else
            {
                var quesionList = model.CAU_HOI.OrderByDescending(x => x.ID).ToPagedList(pageNumber, pageSize);
                return PartialView(quesionList);
            }
        }

        // GET: Question by Category / Questions
        [AllowAnonymous]
        public PartialViewResult CategoryPartical(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 5;

            var categoryList = model.DANH_MUC.OrderByDescending(x => x.DANH_MUC1).ToPagedList(pageNumber, pageSize);
            return PartialView(categoryList);
        }

        [AllowAnonymous]
        public ActionResult Search(string keyword, int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 10; 
            var search = model.CAU_HOI.OrderByDescending(x => x.ID).Where(x => x.CAU_HOI1.ToLower().Contains(keyword.ToLower())).ToPagedList(pageNumber, pageSize);
            ViewBag.keyword = keyword;
            return View("Index", search);
        }

        public ActionResult Details(int id)
        {
            var question = model.CAU_HOI.Find(id);
            question.LUOT_XEM++;
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }
    }
}