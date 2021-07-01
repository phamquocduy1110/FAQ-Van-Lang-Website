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

        // GET: Admin/AdminManageQuestions
        public ActionResult Index()
        {
/*            var question = model.QUESTIONS.ToList().OrderByDescending(x => x.ID).ToList();
*/            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = model.QUESTIONS.FirstOrDefault(x => x.ID == id);
            ViewBag.product_type = model.CATEGORies.OrderByDescending(x => x.ID).ToList();
            return View(product);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int id, QUESTION f, HttpPostedFileBase IMAGE_URL)
        {
            var product = model.QUESTIONS.FirstOrDefault(x => x.ID == id);
            product.QUESTION_CODE = f.QUESTION_CODE;
            product.QUESTION_NAME = f.QUESTION_NAME;
            product.CATEGORY = f.CATEGORY;
            product.CONTENT = f.CONTENT;
            product.STATUS = f.STATUS;
            model.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Test(int id, QUESTION f, HttpPostedFileBase IMAGE_URL)
        {
            var product = model.QUESTIONS.FirstOrDefault(x => x.ID == id);
            product.QUESTION_CODE = f.QUESTION_CODE;
            product.QUESTION_NAME = f.QUESTION_NAME;
            product.CATEGORY = f.CATEGORY;
            product.CONTENT = f.CONTENT;
            product.STATUS = f.STATUS;
            model.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}