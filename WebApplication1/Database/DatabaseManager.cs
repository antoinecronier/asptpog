using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Database
{
    /// <summary>
    /// Allow to manage any elements from model to DB.
    /// </summary>
    public class DatabaseManager<T> : DbContext where T :  DBBaseClass
    {
        #region Constants
        /// <summary>
        /// Represent connection string in Web.config.
        /// </summary>
        public const string CONNECTION_NAME = "DefaultConnection";
        #endregion

        #region Attributs

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor.
        /// </summary>
        public DatabaseManager() : base(CONNECTION_NAME)
        {
            DBInitializer init = new DBInitializer(CONNECTION_NAME);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Represent DB table of T item.
        /// </summary>
        public DbSet<T> DbSetT { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Insert item in database replacing is id.
        /// </summary>
        /// <param name="item">Any item if it is a DBBaseClass.</param>
        /// <returns>async Task containing the T item.</returns>
        public async Task<T> Insert(T item)
        {
            this.DbSetT.Add(item);
            await this.SaveChangesAsync();
            return item;
        }

        /// <summary>
        /// Update item object in DB.
        /// </summary>
        /// <param name="item">Any item if it is a DBBaseClass.</param>
        /// <returns>async Task containing the T item.</returns>
        public async Task<T> Update(T item)
        {
            this.Entry<T>(item).State = EntityState.Modified;
            await this.SaveChangesAsync();
            return item;
        }

        /// <summary>
        /// Delete DB item.
        /// </summary>
        /// <param name="item">Any item if it is a DBBaseClass.</param>
        /// <returns>async Task containing integer value of suppress item.</returns>
        public async Task<Int32> Delete(T item)
        {
            this.DbSetT.Attach(item);
            this.DbSetT.Remove(item);
            return await this.SaveChangesAsync();
        }

        /// <summary>
        /// Get an item from is Id
        /// </summary>
        /// <param name="id">Id to select in DB.</param>
        /// <returns>Selected item as a task of item type.</returns>
        public async Task<T> Get(Int32 id)
        {
            return await this.DbSetT.FindAsync(id);
        }
        #endregion

        #region Events

        #endregion
    }
}