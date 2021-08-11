using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Microsoft.AspNet.Identity;
using CNTTFAQ.Models;

namespace CNTTFAQ.Controllers
{
    public class HomeController : Controller
    {
        DIEUBANTHUONGHOIWEBSITEEntities model = new DIEUBANTHUONGHOIWEBSITEEntities();

        public ActionResult Index()
        {
            if (User.IsInRole("BCN Khoa") || User.IsInRole("Admin"))
            {
                return RedirectToRoute(new { action = "Index", controller = "AdminHome", area = "Admin" });
            }
            else
            { 
                var category = model.DANH_MUC.OrderByDescending(x => x.ID).ToList();

                var maxquestions = model.CAU_HOI
                                .OrderByDescending(p => p.LUOT_XEM)
                                .Take(6);
                ViewBag.MaxQuestion = maxquestions;
                ViewBag.ResultMessage = TempData["ResultMessage"];
                return View(category);
            }
        }

        // POST: CAU_HOI / AdminManageQuestions
        [Authorize]
        [HttpPost, ValidateInput(false)]
        public ActionResult Index(GUI_CAU_HOI f)
        {
            if (ModelState.IsValid)
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
                return RedirectToAction("Index", "Home");
            }

            return View(f);
        }
    }
}