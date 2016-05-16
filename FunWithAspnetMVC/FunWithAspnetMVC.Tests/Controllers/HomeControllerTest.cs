using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FunWithAspnetMVC.Controllers;
using FunWithAspnetMVC.Models;
using PagedList;

namespace FunWithAspnetMVC.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index(string.Empty,String.Empty, string.Empty, 0) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void Index_SearchStringNovel_ResultNotNull()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index(null, null, "Роман", null);

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void Index_SearchStringNovel_ModelNotNull()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index(null, null, "Роман", null) as ViewResult;

            // Assert
            var model = result.Model as PagedList<Book>;
            Assert.IsNotNull(model);
        }
    }
}
