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
    [HandleError]
    [Authorize(Roles = "Admin")]
    public class AspNetRoleController : Controller
    {
        private DIEUBANTHUONGHOIWEBSITEEntities db = new DIEUBANTHUONGHOIWEBSITEEntities();

        // GET: AspNetRole
        public ActionResult Index()
        {
            return View(db.AspNetRoles.ToList());
        }

        // GET: AspNetRole/Details/5
        [OutputCache(CacheProfile = "Cache60Seconds")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetRole aspNetRole = db.AspNetRoles.Find(id);
            if (aspNetRole == null)
            {
                return RedirectToAction("Error", "ErrorController");
            }
            return View(aspNetRole);
        }

        // GET: AspNetRole/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AspNetRole/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( AspNetRole aspNetRole)
        {
            if (ModelState.IsValid)
            {
                var RoleAlreadyExists = db.AspNetRoles.Any(x => x.Name == aspNetRole.Name);

                if(RoleAlreadyExists)
                {
                    ModelState.AddModelError("Name", "Quyền này đã tồn tại. Mời bạn nhập quyền khác");
                    return View(aspNetRole);
                }

                aspNetRole.Id = Guid.NewGuid().ToString();
                db.AspNetRoles.Add(aspNetRole);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(aspNetRole);
        }

        // GET: AspNetRole/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetRole aspNetRole = db.AspNetRoles.Find(id);
            if (aspNetRole == null)
            {
                return RedirectToAction("Error", "ErrorController");
            }
            return View(aspNetRole);
        }

        // POST: AspNetRole/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] AspNetRole aspNetRole)
        {
            if (ModelState.IsValid)
            {
                var RoleAlreadyExists = db.AspNetRoles.Any(x => x.Name == aspNetRole.Name);
                if(RoleAlreadyExists)
                {
                    ModelState.AddModelError("Name", "Quyền này đã tồn tại. Mời bạn nhập quyền khác");
                    return View(aspNetRole);
                }
                else
                {
                    db.Entry(aspNetRole).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(aspNetRole);
        }

        // GET: AspNetRole/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetRole aspNetRole = db.AspNetRoles.Find(id);
            if (aspNetRole == null)
            {
                return RedirectToAction("Error", "ErrorController");
            }
            return View(aspNetRole);
        }

        // POST: AspNetRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AspNetRole aspNetRole = db.AspNetRoles.Find(id);
            db.AspNetRoles.Remove(aspNetRole);
            db.SaveChanges();
            return RedirectToAction("Index");
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
