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
    public class OGameResourcesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OGameResources
        public async Task<ActionResult> Index()
        {
            return View(await db.OGameResources.ToListAsync());
        }

        // GET: OGameResources/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OGameResource oGameResource = await db.OGameResources.FindAsync(id);
            if (oGameResource == null)
            {
                return HttpNotFound();
            }
            return View(oGameResource);
        }

        // GET: OGameResources/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OGameResources/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Type,Quantity")] OGameResource oGameResource)
        {
            if (ModelState.IsValid)
            {
                db.OGameResources.Add(oGameResource);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(oGameResource);
        }

        // GET: OGameResources/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OGameResource oGameResource = await db.OGameResources.FindAsync(id);
            if (oGameResource == null)
            {
                return HttpNotFound();
            }
            return View(oGameResource);
        }

        // POST: OGameResources/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Type,Quantity")] OGameResource oGameResource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oGameResource).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(oGameResource);
        }

        // GET: OGameResources/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OGameResource oGameResource = await db.OGameResources.FindAsync(id);
            if (oGameResource == null)
            {
                return HttpNotFound();
            }
            return View(oGameResource);
        }

        // POST: OGameResources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OGameResource oGameResource = await db.OGameResources.FindAsync(id);
            db.OGameResources.Remove(oGameResource);
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
