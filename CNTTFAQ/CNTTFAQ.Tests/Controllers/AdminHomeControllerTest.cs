using Microsoft.VisualStudio.TestTools.UnitTesting;
using CNTTFAQ.Areas.Admin.Controllers;
using System.Web.Mvc;

namespace CNTTFAQ.Tests.Controllers
{
    [TestClass]
    public class AdminHomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            AdminHomeController controller = new AdminHomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Calendar()
        {
            // Arrange
            AdminHomeController controller = new AdminHomeController();

            // Act
            ViewResult result = controller.Calendar() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
