using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryProject.Controllers
{

    using Models;

    public class HomeController : Controller
    {
        LIBRARYEntities2 db = new LIBRARYEntities2();


        public ActionResult Index()
        {

            return View();
 
        }



        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            
            Books model = new Books();
            Publishers model1 = new Publishers();

            model.BookName = form["bookName"];
            model.Writer = form["writer"];
            model1.PublisherName = form["publisher"];

            model.PublishDate=Convert.ToDateTime( form["publishDate"]);

           
          

            db.Books.Add(model);
            db.Publishers.Add(model1);
            db.SaveChanges();

            return View();

        }

        public ActionResult Create()
        {

   
            return View();

        }
          

       

        public ActionResult List()
        {
            
            return View(db.Books.ToList());

        }



        public ActionResult Detail(int? id)
        {


            Books bk = db.Books.Find(id);

            if (bk == null)
            {
                return HttpNotFound();
            }

            return View(bk);

        }

        public ActionResult Delete(int? id)
             

        {
            Books bk = db.Books.Find(id);
            db.Books.Remove(bk);
            db.SaveChanges();

            return RedirectToAction("List");

        }
        

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}