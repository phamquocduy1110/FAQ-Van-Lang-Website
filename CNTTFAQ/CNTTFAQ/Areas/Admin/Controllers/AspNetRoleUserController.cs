using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CNTTFAQ.Models;

namespace CNTTFAQ.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AspNetRoleUserController : Controller
    {
        private DIEUBANTHUONGHOIWEBSITEEntities db = new DIEUBANTHUONGHOIWEBSITEEntities();

        public ActionResult Create(string roleId)
        {
            ViewBag.Role = db.AspNetRoles.Find(roleId);
            ViewBag.Users = new SelectList(db.AspNetUsers, "Id", "UserName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string roleId, string userId)
        {
            var role = db.AspNetRoles.Find(roleId);
            var user = db.AspNetUsers.Find(userId);

            role.AspNetUsers.Add(user);
            db.Entry(role).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", "AspNetRole");
        }

        public ActionResult Delete(string roleId, string userId)
        {
            var role = db.AspNetRoles.Find(roleId);
            var user = db.AspNetUsers.Find(userId);

            role.AspNetUsers.Remove(user);
            db.Entry(role).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", "AspNetRole");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}