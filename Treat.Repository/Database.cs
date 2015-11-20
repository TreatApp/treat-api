using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Treat.Model;

namespace Treat.Repository
{
    public class Database : DbContext
    {
        public Database() : base("name=treat")
        {
        }

        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventLog> EventLogs { get; set; }
        public virtual DbSet<EventRating> EventRatings { get; set; }
        public virtual DbSet<EventRequest> EventRequests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Event>()
                .HasMany(e => e.EventLogs);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.EventRatings);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.EventRequests);
        }
    }
}
