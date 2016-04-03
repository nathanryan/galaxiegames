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

namespace GalaxieGames.Controllers
{
    public class AdminController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Admin
        public ActionResult Index(string searchString)
        {
            var videoGames = db.VideoGames.Include(v => v.Genre).Include(v => v.Studio);

            if (!String.IsNullOrEmpty(searchString)) { videoGames = videoGames.Where(s => s.Title.ToUpper().Contains(searchString.ToUpper())); }

            return View(videoGames.ToList());
        }

        // GET: Admin/Details/5
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

        // GET: Admin/Create
        public ActionResult Create()
        {
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName");
            ViewBag.StudioID = new SelectList(db.Studios, "ID", "StudioName");
            ViewBag.PlatformID = new SelectList(db.Platforms, "PlatformID", "PlatformName");
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VideoGameID,Title,Year,Price,PlatformID,StudioID,GenreID")] VideoGame videoGame)
        {
            if (ModelState.IsValid)
            {
                db.VideoGames.Add(videoGame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", videoGame.GenreID);
            ViewBag.StudioID = new SelectList(db.Studios, "ID", "StudioName", videoGame.StudioID);
            ViewBag.PlatformID = new SelectList(db.Platforms, "PlatformID", "PlatformName", videoGame.PlatformID);
            return View(videoGame);
        }

        // GET: Admin/Edit/5
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
            ViewBag.PlatformID = new SelectList(db.Platforms, "PlatformID", "PlatformName", videoGame.PlatformID);
            return View(videoGame);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideoGameID,Title,Year,Price,PlatformID,StudioID,GenreID")] VideoGame videoGame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoGame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "GenreName", videoGame.GenreID);
            ViewBag.StudioID = new SelectList(db.Studios, "ID", "StudioName", videoGame.StudioID);
            ViewBag.PlatformID = new SelectList(db.Platforms, "PlatformID", "PlatformName", videoGame.PlatformID);
            return View(videoGame);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoGame videoGame = db.VideoGames.Find(id);
            db.VideoGames.Remove(videoGame);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
