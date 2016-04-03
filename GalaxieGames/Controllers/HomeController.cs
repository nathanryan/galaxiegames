using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GalaxieGames.DAL;
using GalaxieGames.ViewModel;

namespace GalaxieGames.Controllers
{
    public class HomeController : Controller
    {
        private StoreContext db = new StoreContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<VideoGameGroup> data = from videogame in db.VideoGames
                                              group videogame by videogame.Year into yearGroup
                                         select new VideoGameGroup()
                                         {
                                             Year = yearGroup.Key,
                                             VideoGameCount = yearGroup.Count()
                                         };
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}