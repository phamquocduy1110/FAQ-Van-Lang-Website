using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CNTTFAQ.Models;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace CNTTFAQ.Controllers
{
    [Authorize]
    public class AskQuestionController : Controller
    {
        DIEUBANTHUONGHOIWEBSITEEntities model = new DIEUBANTHUONGHOIWEBSITEEntities();

        // GET: DANH_MUC / AdminManageQuestions
        public ActionResult Create()
        {
            if (User.IsInRole("BCN Khoa") || User.IsInRole("Admin"))
            {
                return Redirect("/SEP24Team11/Admin/AdminHome/Index");
            }
            else
            {
                return View();
            }
        }

        // POST: CAU_HOI / AdminManageQuestions
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(GUI_CAU_HOI f)
        {
            var askquestion = new GUI_CAU_HOI();

            askquestion.HO_TEN = f.HO_TEN;
            askquestion.ID_TAI_KHOAN = User.Identity.GetUserId();
            askquestion.CAU_HOI_MUON_HOI = f.CAU_HOI_MUON_HOI;
            askquestion.MO_TA = f.MO_TA;
            askquestion.NGAY_CHINH_SUA = DateTime.Now;
            model.GUI_CAU_HOI.Add(askquestion);
            model.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}