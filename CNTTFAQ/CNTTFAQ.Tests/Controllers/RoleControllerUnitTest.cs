
using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CNTTFAQ.Areas.Admin.Controllers;
using CNTTFAQ.Models;
using System.Transactions;

namespace CNTTFAQ.Tests.Controllers
{
    [TestClass]
    public class RoleControllerUnitTest
    {
        [TestMethod]
        public void TestIndex()
        {

            var controller = new AspNetRoleController();

            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);

            var model = result.Model as List<AspNetRole>;
            Assert.IsNotNull(model);

            var db = new DIEUBANTHUONGHOIWEBSITEEntities();
            Assert.AreEqual(db.AspNetRoles.Count(), model.Count());

        }

       [TestMethod]
       public void TestCreateG()
        {
            var controller = new AspNetRoleController();

            var result = controller.Create() as ViewResult;

            Assert.IsNotNull(result);
        }
       
        [TestMethod]
        public void TestCreateP()
        {
            var rand = new Random();
            var roles = new AspNetRole
            {    
                Name = rand.NextDouble().ToString(),
            };
            var controller = new AspNetRoleController();
            var result0 = controller.Create(roles) as ViewResult;
            
        }


        [TestMethod]
        public void TestDeleteG()
        {
            var controller = new AspNetRoleController();
            var result0 = controller.Delete(ToString()) as HttpNotFoundResult;
            Assert.IsNotNull(result0);
        }

        [TestMethod]
        public void TestDeleteP()
        {
            var db = new DIEUBANTHUONGHOIWEBSITEEntities();
            var roless = db.AspNetRoles.AsNoTracking().First();

            var controller = new AspNetRoleController();
         
        }






    }
}
