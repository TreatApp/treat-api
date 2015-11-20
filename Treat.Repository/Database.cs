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

            modelBuilder.Entity<Category>()
               .HasMany(e => e.Events)
               .WithMany(e => e.Categories)
               .Map(m => m.ToTable("EventCategory").MapLeftKey("CategoryId").MapRightKey("EventId"));

            modelBuilder.Entity<Event>()
                .HasMany(e => e.EventLogs)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.EventRatings)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.EventRequests)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Events)
                .WithRequired(e => e.Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Events)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.EventLogs)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.EventRatings)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.EventRequests)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
