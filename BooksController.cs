using System;
using CrudBookDetailsApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudBookDetailsApp.Controllers
{
    public class BooksController : Controller
    {
        ASStudEntities db = new ASStudEntities();

        // GET: Books
        public ActionResult Index()
        {
            try
            {
                var books = db.TableBooks.ToList();
                return View(books);
            }
            catch (Exception ex)
            {
                // Log the exception (for example, to a file or monitoring system)
                Console.WriteLine("Error: " + ex.Message);
                TempData["ErrorMessage"] = "An error occurred while retrieving the books.";
                return View(new List<TableBook>());
            }
        }
       
        public ActionResult Create()
        {
            var books=new TableBook();
            return View(books);
        }



        [HttpPost]
        public ActionResult Create(TableBook b)
        {
            if (ModelState.IsValid == true)
            {
                db.TableBooks.Add(b);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["Insertmessage "] = "<script>alert ('Data Inserted !!')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Insertmessage "] = "<script>alert ('Data Not Inserted !!')</script>";
                }

            }
            return View(b);
        }
    }
}