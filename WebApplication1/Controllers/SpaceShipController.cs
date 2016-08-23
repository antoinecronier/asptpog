using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Database;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SpaceShipController : Controller
    {
        DatabaseManager<OGameSpaceShip> dbManager;

        public SpaceShipController()
        {
            dbManager = new DatabaseManager<OGameSpaceShip>();
        }

        // GET: SpaceShip
        public async Task<ActionResult> Index()
        {
            List<OGameSpaceShip> ships = (await dbManager.Get()).ToList();

            return View(ships);
        }
    }
}