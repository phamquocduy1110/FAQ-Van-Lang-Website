using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CNTTFAQ.Models;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Net.Configuration;

namespace CNTTFAQ.Areas.Admin.Controllers
{
    [Authorize(Roles = "BCN Khoa")]
    public class EmailSetupController : Controller
    {
        // GET: Admin/EmailSetup
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CNTTFAQ.Models.MailModel _objModelMail)
        {
            SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(_objModelMail.To);
                mail.From = new MailAddress(_objModelMail.From);
                mail.Subject = _objModelMail.Subject;
                string Body = _objModelMail.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = smtpSection.Network.Host;
                smtp.Port = smtpSection.Network.Port;
                smtp.UseDefaultCredentials = smtpSection.Network.DefaultCredentials;
                NetworkCredential networkCred = new NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password);
                smtp.Credentials = networkCred;
                smtp.EnableSsl = smtpSection.Network.EnableSsl;
                smtp.Send(mail);
                return RedirectToAction("Index", "StudentQuestion", _objModelMail);
            }
            else
            {
                return View();
            }
        }
    }
}