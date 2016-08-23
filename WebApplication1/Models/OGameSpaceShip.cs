using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApplication1.Utils.Generator;
using WebApplication1.Utils.Generator.Attributs;

namespace WebApplication1.Models
{
    /// <summary>
    /// Default class to create specialized space ship.
    /// </summary>
    public class OGameSpaceShip : DBBaseClass
    {
        #region Constants

        #endregion

        #region Attributs
        private String name;
        private int attack;
        private int defence;
        private int speed;
        private int bay;
        private int quantity;
        private int shipType;
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public OGameSpaceShip()
        {

        }
        #endregion

        #region Properties
        //public int FleetId { get; set; }

        //[ForeignKey("FleetId")]
        //public OGameFleet Fleet { get; set; }

        /// <summary>
        /// Allow to reconize the different ship type in DB.
        /// </summary>
        [FakerTyper(TypeEnumCustom.SHIP_TYPE)]
        public int ShipType
        {
            get { return shipType; }
            set { shipType = value; }
        }
        /// <summary>
        /// Number of this ship type.
        /// </summary>
        [FakerTyper(TypeEnumCustom.SHIP_QUANTITY)]
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        /// <summary>
        /// Quantity of carriable resources.
        /// </summary>
        [FakerTyper(TypeEnumCustom.SHIP_QUANTITY)]
        public int Bay
        {
            get { return bay; }
            set { bay = value; }
        }

        /// <summary>
        /// Speed to navigate between planet.
        /// </summary>
        [FakerTyper(TypeEnumCustom.SHIP_QUANTITY)]
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        /// <summary>
        /// Defence that reduce other space ship damage.
        /// </summary>
        [FakerTyper(TypeEnumCustom.SHIP_QUANTITY)]
        public int Defence
        {
            get { return defence; }
            set { defence = value; }
        }

        /// <summary>
        /// Attack to destroy other space ship
        /// </summary>
        [FakerTyper(TypeEnumCustom.SHIP_QUANTITY)]
        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        /// <summary>
        /// Name of space ship class.
        /// </summary>
        [FakerTyper(TypeEnumCustom.USERFIRSTNAME)]
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