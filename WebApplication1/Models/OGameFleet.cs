using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication1.Utils.Generator;
using WebApplication1.Utils.Generator.Attributs;

namespace WebApplication1.Models
{
    /// <summary>
    /// Define a fleet landing on a planet or traveling to a planet.
    /// </summary>
    public class OGameFleet : DBBaseClass
    {
        #region Constants

        #endregion

        #region Attributs
        private String name;
        private DateTime landingAt;
        private List<OGameSpaceShip> spaceShips;
        //private OGamePlanet destination;
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public OGameFleet()
        {

        }
        #endregion

        #region Properties
        ///// <summary>
        ///// Id reference for fleet
        ///// </summary>
        //[Column("DestinationId")]
        //public int? DestinationId { get; set; }

        ///// <summary>
        ///// Destination of fleet.
        ///// </summary>
        //[ForeignKey("DestinationId")]
        //public OGamePlanet Destination
        //{
        //    get { return destination; }
        //    set { destination = value; }
        //}

        /// <summary>
        /// Fleet space ships.
        /// </summary>
        //[InverseProperty("Fleet")]
        public List<OGameSpaceShip> SpaceShips
        {
            get { return spaceShips; }
            set { spaceShips = value; }
        }

        /// <summary>
        /// Define when fleet arrive to new planet.
        /// </summary>
        //[FakerTyper(TypeEnumCustom.DATETIME)]
        //public DateTime LandingAt
        //{
        //    get { return landingAt; }
        //    set { landingAt = value; }
        //}

        /// <summary>
        /// Name of the fleet.
        /// </summary>
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        #endregion

        #region Methods

        #endregion

        #region Events

        #endregion
    }
}