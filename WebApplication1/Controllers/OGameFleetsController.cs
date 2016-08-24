using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OGameFleetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OGameFleets
        public async Task<ActionResult> Index()
        {
            return View(await db.OGameFleets.ToListAsync());
        }

        // GET: OGameFleets/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OGameFleet oGameFleet = await db.OGameFleets.FindAsync(id);
            if (oGameFleet == null)
            {
                return HttpNotFound();
            }
            return View(oGameFleet);
        }

        // GET: OGameFleets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OGameFleets/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] OGameFleet oGameFleet)
        {
            if (ModelState.IsValid)
            {
                db.OGameFleets.Add(oGameFleet);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(oGameFleet);
        }

        // GET: OGameFleets/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OGameFleet oGameFleet = await db.OGameFleets.FindAsync(id);
            if (oGameFleet == null)
            {
                return HttpNotFound();
            }
            return View(oGameFleet);
        }

        // POST: OGameFleets/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] OGameFleet oGameFleet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oGameFleet).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(oGameFleet);
        }

        // GET: OGameFleets/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OGameFleet oGameFleet = await db.OGameFleets.FindAsync(id);
            if (oGameFleet == null)
            {
                return HttpNotFound();
            }
            return View(oGameFleet);
        }

        // POST: OGameFleets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OGameFleet oGameFleet = await db.OGameFleets.FindAsync(id);
            db.OGameFleets.Remove(oGameFleet);
            await db.SaveChangesAsync();
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
