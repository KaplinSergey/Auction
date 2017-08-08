using ORM.Models;
using System.Data.Entity;


namespace ORM
{
    public class AuctionDbContext : DbContext
    {

        public DbSet<Lot> Lots { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<ExceptionInformation> ExceptionInformations { get; set; }

        public AuctionDbContext()
            : base("DbConnection")
        {
            Database.SetInitializer<AuctionDbContext>(new AuctionDbInitializer());
        }

    }
}
