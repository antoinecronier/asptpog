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
    public class OGameSpaceShipsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OGameSpaceShips
        public async Task<ActionResult> Index()
        {
            return View(await db.OGameSpaceShips.ToListAsync());
        }

        // GET: OGameSpaceShips/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OGameSpaceShip oGameSpaceShip = await db.OGameSpaceShips.FindAsync(id);
            if (oGameSpaceShip == null)
            {
                return HttpNotFound();
            }
            return View(oGameSpaceShip);
        }

        // GET: OGameSpaceShips/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OGameSpaceShips/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ShipType,Quantity,Bay,Speed,Defence,Attack,Name")] OGameSpaceShip oGameSpaceShip)
        {
            if (ModelState.IsValid)
            {
                db.OGameSpaceShips.Add(oGameSpaceShip);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(oGameSpaceShip);
        }

        // GET: OGameSpaceShips/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OGameSpaceShip oGameSpaceShip = await db.OGameSpaceShips.FindAsync(id);
            if (oGameSpaceShip == null)
            {
                return HttpNotFound();
            }
            return View(oGameSpaceShip);
        }

        // POST: OGameSpaceShips/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ShipType,Quantity,Bay,Speed,Defence,Attack,Name")] OGameSpaceShip oGameSpaceShip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oGameSpaceShip).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(oGameSpaceShip);
        }

        // GET: OGameSpaceShips/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OGameSpaceShip oGameSpaceShip = await db.OGameSpaceShips.FindAsync(id);
            if (oGameSpaceShip == null)
            {
                return HttpNotFound();
            }
            return View(oGameSpaceShip);
        }

        // POST: OGameSpaceShips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OGameSpaceShip oGameSpaceShip = await db.OGameSpaceShips.FindAsync(id);
            db.OGameSpaceShips.Remove(oGameSpaceShip);
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
