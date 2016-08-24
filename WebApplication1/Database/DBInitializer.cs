using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Utils.Generator;

namespace WebApplication1.Database
{
    /// <summary>
    /// Use to build DB first time it called.
    /// </summary>
    public class DBInitializer : DbContext
    {
        #region Constants

        #endregion

        #region Attributs

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="database">DB to target.</param>
        public DBInitializer(String database) : base(database)
        {
            //InitDB();
        }
        #endregion

        #region Properties
        private DbSet<OGameCoordinate> DbSetCoordinate { get; set; }
        private DbSet<OGameFleet> DbSetFleet { get; set; }
        private DbSet<OGamePlanet> DbSetPlanet { get; set; }
        private DbSet<OGameResource> DbSetResource { get; set; }
        private DbSet<OGameSpaceShip> DbSetSpaceShip { get; set; }
        private DbSet<OGameTypeBuilding> DbSetTypeBuilding { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Create database if not already exist.
        /// </summary>
        public async void InitDB()
        {
            DatabaseManager<OGameCoordinate> coorDB = new DatabaseManager<OGameCoordinate>();
            DatabaseManager<OGameFleet> fleetDB = new DatabaseManager<OGameFleet>();
            DatabaseManager<OGamePlanet> planetDB = new DatabaseManager<OGamePlanet>();
            DatabaseManager<OGameResource> resDB = new DatabaseManager<OGameResource>();
            DatabaseManager<OGameSpaceShip> shipDB = new DatabaseManager<OGameSpaceShip>();
            DatabaseManager<OGameTypeBuilding> buildingDB = new DatabaseManager<OGameTypeBuilding>();

            //if (this.Database.CreateIfNotExists())
            if ((await resDB.Get()).ToList().Count == 0)
            {
                EntityGeneratorFakerTyper<OGameCoordinate> coorGen = new EntityGeneratorFakerTyper<OGameCoordinate>();
                EntityGeneratorFakerTyper<OGameFleet> fleetGen = new EntityGeneratorFakerTyper<OGameFleet>();
                EntityGeneratorFakerTyper<OGamePlanet> planetGen = new EntityGeneratorFakerTyper<OGamePlanet>();
                EntityGeneratorFakerTyper<OGameResource> resGen = new EntityGeneratorFakerTyper<OGameResource>();
                EntityGeneratorFakerTyper<OGameSpaceShip> shipGen = new EntityGeneratorFakerTyper<OGameSpaceShip>();
                EntityGeneratorFakerTyper<OGameTypeBuilding> buildingGen = new EntityGeneratorFakerTyper<OGameTypeBuilding>();

                List<OGameCoordinate> coorList = coorGen.GenerateListItems(10,10).ToList();
                foreach (var item in coorList)
                {
                    await coorDB.Insert(item);
                }

                List<OGameSpaceShip> shipList = shipGen.GenerateListItems(3, 3).ToList();
                foreach (var item in shipList)
                {
                    await shipDB.Insert(item);
                }

                List<OGameFleet> fleetList = fleetGen.GenerateListItems(1,1).ToList();
                fleetList[0].SpaceShips = shipList;
                foreach (var item in fleetList)
                {
                    await fleetDB.Insert(item);
                }

                List<OGameTypeBuilding> buildingList = buildingGen.GenerateListItems(5, 5).ToList();
                foreach (var item in buildingList)
                {
                    await buildingDB.Insert(item);
                }

                List<OGameResource> resList = new List<OGameResource>();
                OGameResource res1 = new OGameResource();
                //res1.PlanetId = 1;
                res1.Quantity = 1000;
                res1.Type = "gold";

                resList.Add(res1);

                OGameResource res2 = new OGameResource();
                //res2.PlanetId = 1;
                res2.Quantity = 10;
                res2.Type = "bitcoin";

                resList.Add(res2);

                List<OGameResource> resList1 = new List<OGameResource>();
                OGameResource res3 = new OGameResource();
                //res3.PlanetId = 2;
                res3.Quantity = 200;
                res3.Type = "gold";

                resList1.Add(res3);

                OGameResource res4 = new OGameResource();
                //res4.PlanetId = 2;
                res4.Quantity = 1;
                res4.Type = "bitcoin";

                resList1.Add(res4);

                foreach (var item in resList)
                {
                    await resDB.Insert(item);
                }

                foreach (var item in resList1)
                {
                    await resDB.Insert(item);
                }

                List<OGamePlanet> planetList = planetGen.GenerateListItems(2, 2).ToList();
                planetList[0].Buildings = buildingList;
                planetList[1].Buildings = buildingList;
                planetList[0].CoordinateId = 1;
                planetList[0].Coordinate = coorList[0];
                planetList[1].CoordinateId = 2;
                planetList[1].Coordinate = coorList[2];
                planetList[0].Resources = resList;
                planetList[1].Resources = resList1;
                planetList[0].Fleet = fleetList[0];
                planetList[1].Fleet = null;

                await planetDB.Insert(planetList[0]);
            }
        }
        #endregion

        #region Events

        #endregion
    }
}