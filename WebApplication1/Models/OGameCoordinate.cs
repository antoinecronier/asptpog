using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Utils.Generator;
using WebApplication1.Utils.Generator.Attributs;

namespace WebApplication1.Models
{
    /// <summary>
    /// Define position of an element in our univers.
    /// </summary>
    public class OGameCoordinate : DBBaseClass
    {
        #region Constants

        #endregion

        #region Attributs
        private int x;
        private int y;
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public OGameCoordinate()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Y coordinate.
        /// </summary>
        [Range(1,1000)]
        [FakerTyper(TypeEnumCustom.COORDINATE_Y)]
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
        /// X coordinate.
        /// </summary>
        [Range(1, 1000)]
        [FakerTyper(TypeEnumCustom.COORDINATE_X)]
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        #endregion

        #region Methods

        #endregion

        #region Events

        #endregion
    }
}