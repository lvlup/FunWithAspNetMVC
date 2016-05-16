using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FunWithAspnetMVC.Controllers;
using FunWithAspnetMVC.DAL;
using FunWithAspnetMVC.Models;
using Moq;
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


        [TestMethod]
        public void Index_SearchStringNovel_SearchOneBook()
        {
            // Arrange
            var writer = new Writer() {FirstName = "example1", LastName = "example2", ID = 1};

            var data = new List<Book>
            {
                new Book() {Genre = "Роман", Name = "testname1", Writer = writer},
                new Book() {Genre = "Стих", Name = "testname2", Writer = writer}
            }.AsQueryable();

            var bookDbSetMock = new Mock<IDbSet<Book>>();
            bookDbSetMock.Setup(m => m.Provider).Returns(data.Provider);
            bookDbSetMock.Setup(m => m.Expression).Returns(data.Expression);
            bookDbSetMock.Setup(m => m.ElementType).Returns(data.ElementType);
            bookDbSetMock.Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
           
            var mockContext = new Mock<LibraryContext>();
            mockContext.Setup(m => m.Books).Returns(bookDbSetMock.Object);


            HomeController controller = new HomeController(mockContext.Object);

            // Act
            ViewResult result = controller.Index(null, null, "Роман", null);

            // Assert
            var model = (PagedList<Book>) result.Model;
            Assert.IsTrue(model.Count == 1);
        }
    }
}
