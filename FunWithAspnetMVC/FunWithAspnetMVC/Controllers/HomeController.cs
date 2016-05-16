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

        public ViewResult Index(string sortOrder,string currentFilter,string searchString, int? page)
        {
           ViewBag.CurrentSort = sortOrder;

           ViewBag.NameSortParm =  "name_asc";
           ViewBag.GenreSortParm =  "genre_asc";
           ViewBag.WriterNameSortParm =  "writername_asc";
           ViewBag.WriterLastNameSortParm = "writerlastame_asc";


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
                                                         || b.Writer.LastName.Contains(searchString));

                switch (sortOrder)
                {
                    case "name_desc":
                        searchingBooks = searchingBooks.OrderByDescending(b=>b.Name);
                        ViewBag.NameSortParm = "name_asc";
                        break;
                    case "name_asc":
                        searchingBooks = searchingBooks.OrderBy(b => b.Name);
                        ViewBag.NameSortParm = "name_desc";
                        break;
                    case "genre_desc":
                        searchingBooks = searchingBooks.OrderByDescending(b => b.Genre);
                        ViewBag.GenreSortParm = "genre_asc";
                        break;
                    case "genre_asc":
                        searchingBooks = searchingBooks.OrderBy(b => b.Genre);
                        ViewBag.GenreSortParm = "genre_desc";
                        break;
                    case "writername_desc":
                        searchingBooks = searchingBooks.OrderByDescending(b => b.Writer.FirstName);
                        ViewBag.WriterNameSortParm = "writername_asc";
                        break;
                    case "writername_asc":
                        searchingBooks = searchingBooks.OrderBy(b => b.Writer.FirstName);
                        ViewBag.WriterNameSortParm = "writername_desc";
                        break;
                    case "writerlastame_desc":
                        searchingBooks = searchingBooks.OrderByDescending(b => b.Writer.LastName);
                        ViewBag.WriterLastNameSortParm = "writerlastame_asc";
                        break;
                    case "writerlastame_asc":
                        searchingBooks = searchingBooks.OrderBy(b => b.Writer.LastName);
                        ViewBag.WriterLastNameSortParm = "writerlastame_desc";
                        break;
                    default:
                        searchingBooks = searchingBooks.OrderBy(b => b.Name);
                        ViewBag.NameSortParm = "name_desc";
                        break;
                }

                int pageSize = 2;
                int pageNumber = page ?? 1;

                var temp = searchingBooks.ToPagedList(pageNumber, pageSize);
                return View(temp);
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