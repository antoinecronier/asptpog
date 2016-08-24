using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication1.Utils.Generator;
using WebApplication1.Utils.Generator.Attributs;

namespace WebApplication1.Models
{
    /// <summary>
    /// Define a user planet where landing building.
    /// </summary>
    public class OGamePlanet : DBBaseClass
    {
        #region Constants

        #endregion

        #region Attributs
        private String name;
        private int slot;
        private String image;
        private OGameCoordinate coordinate;
        private List<OGameTypeBuilding> buildings;
        private List<OGameResource> resources;
        private OGameFleet fleet;
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public OGamePlanet()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Override default DBBaseClass id to setup new properties.
        /// </summary>
        [Key, ForeignKey("Fleet")]
        public new int Id { get; set; }

        /// <summary>
        /// Current landing planet fleet.
        /// </summary>
        public OGameFleet Fleet
        {
            get { return fleet; }
            set { fleet = value; }
        }

        /// <summary>
        /// Different resources contains by planet.
        /// </summary>
        //[InverseProperty("Planet")]
        public List<OGameResource> Resources
        {
            get { return resources; }
            set { resources = value; }
        }

        /// <summary>
        /// Planet buildings.
        /// </summary>
        //[InverseProperty("Planet")]
        public List<OGameTypeBuilding> Buildings
        {
            get { return buildings; }
            set { buildings = value; }
        }

        /// <summary>
        /// Link Coordinate item with is id.
        /// </summary>
        public int CoordinateId { get; set; }

        /// <summary>
        /// Planet position in univers.
        /// </summary>
        [ForeignKey("CoordinateId")]
        public OGameCoordinate Coordinate
        {
            get { return coordinate; }
            set { coordinate = value; }
        }

        /// <summary>
        /// Picture of current planet.
        /// </summary>
        public String Image
        {
            get { return image; }
            set { image = value; }
        }

        /// <summary>
        /// Define number of building for current planet.
        /// </summary>
        [FakerTyper(TypeEnumCustom.PLANET_SLOT)]
        [Range(20,200)]
        public int Slot
        {
            get { return slot; }
            set { slot = value; }
        }

        /// <summary>
        /// Current name given by player to his planet.
        /// </summary>
        [FakerTyper(TypeEnumCustom.USERLASTNAME)]
        [StringLength(20)]
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