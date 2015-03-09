#region References

using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LoLStats.Data.Context;
using LoLStats.Shared.Interfaces;
using LoLStats.Shared.Models.Entities;

#endregion

namespace LoLStats.Web.Controllers
{
    public class ChampionController : Controller
    {
        #region Fields

        private readonly IChampionManager _championManager;
        private readonly LoLDBContext db = new LoLDBContext();

        #endregion

        #region Constructors

        ///Dependency injection using the NinjectWebCommon.cs file to bind the User manager classes
        public ChampionController(IChampionManager manager)
        {
            _championManager = manager;
        }

        #endregion

        // GET: Champion

        // GET: Champion/Create

        #region Methods

        public ActionResult Create()
        {
            return View();
        }

        // POST: Champion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "Id,Active,Key,Name,RiotId,Title,CreatedOn,ModifiedOn")] Champion champion)
        {
            if (ModelState.IsValid)
            {
                db.Champions.Add(champion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(champion);
        }

        // GET: Champion/Edit/5

        // GET: Champion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var champion = db.Champions.Find(id);
            if (champion == null)
            {
                return HttpNotFound();
            }
            return View(champion);
        }

        // POST: Champion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var champion = db.Champions.Find(id);
            db.Champions.Remove(champion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var champion = db.Champions.Find(id);
            if (champion == null)
            {
                return HttpNotFound();
            }
            return View(champion);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var champion = db.Champions.Find(id);
            if (champion == null)
            {
                return HttpNotFound();
            }
            return View(champion);
        }

        // POST: Champion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id,Active,Key,Name,RiotId,Title,CreatedOn,ModifiedOn")] Champion champion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(champion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(champion);
        }

        public ActionResult Index()
        {
            return View(db.Champions.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}