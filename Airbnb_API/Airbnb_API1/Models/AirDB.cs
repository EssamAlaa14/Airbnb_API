using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Airbnb_API1.Models
{
    public partial class AirDB : DbContext
    {
        public AirDB()
            : base("name=AirDB")
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .Property(e => e.Location_Des)
                .IsUnicode(false);

            modelBuilder.Entity<Location>()
                .Property(e => e.Loc_longtiute)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Location>()
                .Property(e => e.Loc_latitude)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.Images)
                .WithRequired(e => e.Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Locations)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_ID);
        }
    }
}
