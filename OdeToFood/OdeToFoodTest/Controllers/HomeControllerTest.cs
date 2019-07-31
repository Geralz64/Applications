using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeToFood.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OdeToFoodTest.Controllers
{
    [TestClass]
    class HomeControllerTest
    {

        [TestMethod]
        public void MyTestMethod()
         {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;

            //Assert.AreEqual("This will fail", result.ViewBag.Message);

        }


    }
}
