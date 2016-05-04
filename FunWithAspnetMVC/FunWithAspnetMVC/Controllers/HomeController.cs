using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FunWithAspnetMVC.DAL;
using PagedList;

namespace FunWithAspnetMVC.Controllers
{
    public class HomeController : Controller
    {
        private LibraryContext db = new LibraryContext();

        public ViewResult Index(string currentFilter,string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
               

                var searchingBooks = db.Books.Where(b => b.Genre.Contains(searchString)
                                                         || b.Name.Contains(searchString)
                                                         || b.Writer.FirstName.Contains(searchString)
                                                         || b.Writer.LastName.Contains(searchString)).OrderBy(b=>b.Name);

                int pageSize = 2;
                int pageNumber = (int)page;


                return View(searchingBooks.ToPagedList(pageNumber,pageSize));
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