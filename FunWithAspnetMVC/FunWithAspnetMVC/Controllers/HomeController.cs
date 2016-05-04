using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FunWithAspnetMVC.DAL;

namespace FunWithAspnetMVC.Controllers
{
    public class HomeController : Controller
    {
        private LibraryContext db = new LibraryContext();

        public ViewResult Index(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var searchingBooks = db.Books.Where(b => b.Genre.Contains(searchString)
                                                         || b.Name.Contains(searchString)
                                                         || b.Writer.FirstName.Contains(searchString)
                                                         || b.Writer.LastName.Contains(searchString)).ToList();
                return View(searchingBooks);
            }

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}