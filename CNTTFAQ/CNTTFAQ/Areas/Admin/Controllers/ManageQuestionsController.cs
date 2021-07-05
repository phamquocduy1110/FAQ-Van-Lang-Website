using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CNTTFAQ.Models;

namespace CNTTFAQ.Areas.Admin.Controllers
{
    public class ManageQuestionsController : Controller
    {

        DIEUBANTHUONGHOIWEBSITEEntities model = new DIEUBANTHUONGHOIWEBSITEEntities();

        // GET: Load All List Questions / AdminManageQuestions
        public ActionResult Index()
        {
            var question = model.CAU_HOI.ToList().OrderByDescending(x => x.ID).ToList();
            return View(question);
        }

        // GET: DANH_MUC / AdminManageQuestions
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.question_type = model.DANH_MUC.OrderByDescending(x => x.ID).ToList();
            ViewBag.account_type = model.AspNetUsers.OrderByDescending(x => x.Id).ToList();
            return View();
        }

        // POST: CAU_HOI / AdminManageQuestions
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(CAU_HOI f, HttpPostedFileBase IMAGE_URL)
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
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var question = model.CAU_HOI.FirstOrDefault(x => x.ID == id);
            ViewBag.question_type = model.DANH_MUC.OrderByDescending(x => x.ID).ToList();
            ViewBag.account_type = model.AspNetUsers.OrderByDescending(x => x.Id).ToList();
            return View(question);
        }

        // POST: CAU_HOI / AdminManageQuestions
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int id, CAU_HOI f, HttpPostedFileBase IMAGE_URL)
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
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var question = model.CAU_HOI.FirstOrDefault(x => x.ID == id);
            return View(question);
        }

        // POST: DANH_MUC / AdminManageQuestions
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var question = model.CAU_HOI.FirstOrDefault(x => x.ID == id);
            model.CAU_HOI.Remove(question);
            model.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: DANH_MUC / AdminManageQuestions
        [HttpGet, ValidateInput(false)]
        public ActionResult Details(int id)
        {
            var question = model.CAU_HOI.FirstOrDefault(x => x.ID == id);
            return View(question);
        }
    }
}