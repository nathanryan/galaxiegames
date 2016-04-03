using GalaxieGames.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

/*
* StoreContext.cs
*
* v1.0
*
* 08/12/2015
*
* @author Nathan Ryan, x13448212
*/

namespace GalaxieGames.DAL
{
    public class StoreContext : DbContext
    {
        public StoreContext()
            : base("StoreContext")
        {
        }

        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}