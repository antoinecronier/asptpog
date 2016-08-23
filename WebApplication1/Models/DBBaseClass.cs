using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    #region Constants

    #endregion

    #region Attributs

    #endregion

    #region Constructors

    #endregion

    #region Properties

    #endregion

    #region Methods

    #endregion

    #region Events

    #endregion

    /// <summary>
    /// Manage id for item DB relations.
    /// </summary>
    public abstract class DBBaseClass
    {
        #region Constants

        #endregion

        #region Attributs
        private int id;
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public DBBaseClass()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// DB id.
        /// </summary>
        [Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        #endregion

        #region Methods

        #endregion

        #region Events

        #endregion
    }
}