using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GalaxieGames.DAL;
using GalaxieGames.Models;
using PagedList;


namespace GalaxieGames.Controllers
{
    public class VideoGamesController : Controller
    {
        private StoreContext db = new StoreContext();

        private static readonly IList<CommentModel> _comments;

        static VideoGamesController()
        {
            _comments = new List<CommentModel>
            {
               
            };
        }

        public ActionResult Comments()
        {
            return Json(_comments, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddComment(CommentModel comment)
        {
            _comments.Add(comment);
            return Content("Success :)");
        }

        // GET: VideoGames
        public ViewResult Index(string sortOrder, int? page)
        {

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";

            var videoGames = from a in db.VideoGames.Include(v => v.Genre).Include(v => v.Studio)
                         select a;
            
            switch (sortOrder)
            {
                case "name_desc":
                    videoGames = videoGames.OrderByDescending(a => a.Title);
                    break;
                case "Price":// Price ascending
                    videoGames = videoGames.OrderBy(a => a.Price);
                    break;
                case "price_desc":
                    videoGames = videoGames.OrderByDescending(a => a.Price);
                    break;
                default: // Name ascending
                    videoGames = videoGames.OrderBy(a => a.Title);
                    break;
            }
            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return View(videoGames.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Search()
        {
            return View();
        }

        // GET: VideoGames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return HttpNotFound();
            }
            return View(videoGame);
        }

        // GET: VideoGames/Details/5
        public ActionResult _details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return HttpNotFound();
            }
            return View(videoGame);
        }

        // GET: VideoGames/Create
        public ActionResult Create()
        {
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName");
            ViewBag.StudioID = new SelectList(db.Studios, "ID", "StudioName");
            return View();
        }

        // POST: VideoGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VideoGameID,Title,Year,Price,Platform,StudioID,GenreID")] VideoGame videoGame)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.VideoGames.Add(videoGame);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", videoGame.GenreID);
            ViewBag.StudioID = new SelectList(db.Studios, "ID", "StudioName", videoGame.StudioID);
            return View(videoGame);
        }

        // GET: VideoGames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", videoGame.GenreID);
            ViewBag.StudioID = new SelectList(db.Studios, "ID", "StudioName", videoGame.StudioID);
            return View(videoGame);
        }

        // POST: VideoGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideoGameID,Title,Year,Price,Platform,StudioID,GenreID")] VideoGame videoGame)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(videoGame).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", videoGame.GenreID);
            ViewBag.StudioID = new SelectList(db.Studios, "ID", "StudioName", videoGame.StudioID);
            return View(videoGame);
        }

        // GET: VideoGames/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            VideoGame videoGame = db.VideoGames.Find(id);
            if (videoGame == null)
            {
                return HttpNotFound();
            }
            return View(videoGame);
        }

        // POST: VideoGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
            VideoGame videoGame = db.VideoGames.Find(id);
            db.VideoGames.Remove(videoGame);
            db.SaveChanges();
            
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
        return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
