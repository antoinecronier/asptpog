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
using WebApplication1.Database;

namespace WebApplication1.Controllers
{
    public class OGamePlanetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OGamePlanets
        public async Task<ActionResult> Index()
        {
            var oGamePlanets = db.OGamePlanets.Include(o => o.Coordinate).Include(o => o.Fleet);
            return View(await oGamePlanets.ToListAsync());
        }

        // GET: OGamePlanets/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            OGamePlanet oGamePlanet = await db.OGamePlanets.FindAsync(id);

            oGamePlanet.Buildings = db.OGameTypeBuildings.SqlQuery("Select * from dbo.OGameTypeBuildings where OGamePlanet_Id = " + oGamePlanet.Id).ToList();
            oGamePlanet.Resources = db.OGameResources.SqlQuery("Select * from dbo.OGameResources where OGamePlanet_Id = " + oGamePlanet.Id).ToList();
            oGamePlanet.Coordinate = await db.OGameCoordinates.FindAsync(oGamePlanet.CoordinateId);

            if (oGamePlanet == null)
            {
                return HttpNotFound();
            }

            this.ViewBag.Planet = oGamePlanet;

            return View(oGamePlanet);
        }

        // GET: OGamePlanets/Create
        public ActionResult Create()
        {
            ViewBag.CoordinateId = new SelectList(db.OGameCoordinates, "Id", "Id");
            ViewBag.Id = new SelectList(db.OGameFleets, "Id", "Name");
            return View();
        }

        // POST: OGamePlanets/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CoordinateId,Image,Slot,Name")] OGamePlanet oGamePlanet)
        {
            if (ModelState.IsValid)
            {
                oGamePlanet.Buildings = new List<OGameTypeBuilding>(await BaseBuildingsInit());
                oGamePlanet.Resources = new List<OGameResource>(await BaseResourcesInit());

                db.OGamePlanets.Add(oGamePlanet);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CoordinateId = new SelectList(db.OGameCoordinates, "Id", "Id", oGamePlanet.CoordinateId);
            ViewBag.Id = new SelectList(db.OGameFleets, "Id", "Name", oGamePlanet.Id);
            return View(oGamePlanet);
        }

        private async Task<List<OGameResource>> BaseResourcesInit()
        {
            DatabaseManager<OGameResource> dbManager = new DatabaseManager<OGameResource>();

            List<OGameResource> result = new List<OGameResource>();
            OGameResource bitcoin = new OGameResource();
            bitcoin.Type = "Bitcoin";
            bitcoin.Quantity = 100;
            result.Add(bitcoin);

            OGameResource gold = new OGameResource();
            gold.Type = "Gold";
            gold.Quantity = 100;
            result.Add(gold);

            foreach (var item in result)
            {
                await dbManager.Insert(item);
            }

            return result;
        }

        private async Task<IEnumerable<OGameTypeBuilding>> BaseBuildingsInit()
        {
            DatabaseManager<OGameTypeBuilding> dbManager = new DatabaseManager<OGameTypeBuilding>();

            List<OGameTypeBuilding> result = new List<OGameTypeBuilding>();
            OGameTypeBuilding bitcoinMine = new OGameTypeBuilding();
            bitcoinMine.Level = 0;
            bitcoinMine.Name = "BitCoinMine";
            bitcoinMine.TypeBuilding = 1;
            result.Add(bitcoinMine);
            OGameTypeBuilding goldMine = new OGameTypeBuilding();
            goldMine.Level = 0;
            goldMine.Name = "GoldMine";
            goldMine.TypeBuilding = 2;
            result.Add(goldMine);
            OGameTypeBuilding starPort = new OGameTypeBuilding();
            starPort.Level = 0;
            starPort.Name = "Starport";
            starPort.TypeBuilding = 3;
            result.Add(starPort);

            foreach (var item in result)
            {
                await dbManager.Insert(item);
            }

            return result;
        }

        // GET: OGamePlanets/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OGamePlanet oGamePlanet = await db.OGamePlanets.FindAsync(id);
            if (oGamePlanet == null)
            {
                return HttpNotFound();
            }
            ViewBag.CoordinateId = new SelectList(db.OGameCoordinates, "Id", "Id", oGamePlanet.CoordinateId);
            ViewBag.Id = new SelectList(db.OGameFleets, "Id", "Name", oGamePlanet.Id);
            return View(oGamePlanet);
        }

        // POST: OGamePlanets/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CoordinateId,Image,Slot,Name")] OGamePlanet oGamePlanet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oGamePlanet).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CoordinateId = new SelectList(db.OGameCoordinates, "Id", "Id", oGamePlanet.CoordinateId);
            ViewBag.Id = new SelectList(db.OGameFleets, "Id", "Name", oGamePlanet.Id);
            return View(oGamePlanet);
        }

        // GET: OGamePlanets/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OGamePlanet oGamePlanet = await db.OGamePlanets.FindAsync(id);
            if (oGamePlanet == null)
            {
                return HttpNotFound();
            }
            return View(oGamePlanet);
        }

        // POST: OGamePlanets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OGamePlanet oGamePlanet = await db.OGamePlanets.FindAsync(id);
            db.OGamePlanets.Remove(oGamePlanet);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Evolve(int buildingId, int planetId)
        {
            DatabaseManager<OGameResource> dbResManager = new DatabaseManager<OGameResource>();
            DatabaseManager<OGameTypeBuilding> dbBuildManager = new DatabaseManager<OGameTypeBuilding>();
            DatabaseManager<OGamePlanet> dbPlanetManager = new DatabaseManager<OGamePlanet>();
            var planet = await dbPlanetManager.Get(planetId);
            planet.Resources = db.OGameResources.SqlQuery("Select * from dbo.OGameResources where OGamePlanet_Id = " + planet.Id).ToList();
            var building = await dbBuildManager.Get(buildingId);

            var gold = planet.Resources.Find(x => x.Type.Equals("Gold"));
            var bitcoin = planet.Resources.Find(x => x.Type.Equals("Bitcoin"));

            if (gold.Quantity >= (100* building.Level)
                && bitcoin.Quantity >= (20 * building.Level))
            {
                gold.Quantity -= 100 * building.Level;
                await dbResManager.Update(gold);

                bitcoin.Quantity -= 20 * building.Level;
                await dbResManager.Update(bitcoin);

                building.Level += 1;
                await dbBuildManager.Update(building);
            }

            return RedirectToAction("Details/"+planet.Id);
        }

        [HttpPost]
        public async Task<int> UpdateResources(String data)
        {
            var res = data.Split(';');

            DatabaseManager<OGameResource> dbManager = new DatabaseManager<OGameResource>();

            OGameResource res0 = await dbManager.Get(Int32.Parse(res[0]));
            OGameResource res1 = await dbManager.Get(Int32.Parse(res[2]));

            res0.Quantity = Int32.Parse(res[1]);
            res1.Quantity = Int32.Parse(res[3]);

            await dbManager.Update(res0);
            await dbManager.Update(res1);

            return res.Count();
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
