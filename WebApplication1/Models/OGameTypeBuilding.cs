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
    /// Define base building functionnalities.
    /// </summary>
    public class OGameTypeBuilding : DBBaseClass
    {
        #region Constants

        #endregion

        #region Attributs
        private String name;
        private int level;
        private int typeBuilding;

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public OGameTypeBuilding()
        {

        }
        #endregion

        #region Properties
        ///// <summary>
        ///// Reference DB id of linked planet.
        ///// </summary>
        //public int PlanetId { get; set; }

        ///// <summary>
        ///// Reference OGamePlanet for relation mapping.
        ///// </summary>
        //[ForeignKey("PlanetId")]
        //public OGamePlanet Planet { get; set; }

        /// <summary>
        /// DB management of item sub type.
        /// </summary>
        [Range(1,3)]
        [FakerTyper(TypeEnumCustom.BUILDING_TYPE)]
        public int TypeBuilding
        {
            get { return typeBuilding; }
            set { typeBuilding = value; }
        }
        /// <summary>
        /// Reference building identity.
        /// </summary>
        [StringLength(20)]
        [FakerTyper(TypeEnumCustom.LOREUMONEWORD)]
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Define current building level.
        /// </summary>
        [Range(0,20)]
        [FakerTyper(TypeEnumCustom.LEVEL)]
        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        #endregion

        #region Methods

        #endregion

        #region Events

        #endregion
    }
}