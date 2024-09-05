using Microsoft.EntityFrameworkCore;
using PickMeUp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Repository
{
	public class PickMeUpDbContext : DbContext
	{
		public PickMeUpDbContext(DbContextOptions<PickMeUpDbContext> contextOptions)
			: base(contextOptions)
		{	}
		public PickMeUpDbContext() { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			
			base.OnConfiguring(optionsBuilder);
		}

		public DbSet<Car> Cars { get;set; }
		public DbSet<Contact> Contacts { get;set; }
		public DbSet<DriverRatings> DriverRatings { get;set; }
		public DbSet<Gender> Genders { get;set; }
		public DbSet<Order> Orders { get;set; }
		public DbSet<OrderStatus> OrderStatuses { get;set; }
		public DbSet<Report> Reports { get;set; }
		public DbSet<ReportType> ReportTypes { get;set; }
		public DbSet<Reviews> Reviews { get;set; }
		public DbSet<Roles> Roles { get;set; }
		public DbSet<RoleUser> RoleUsers { get;set; }
		public DbSet<Shift> Shifts { get;set; }
		public DbSet<Taxi> Taxis { get;set; }
		public DbSet<TaxiContact> TaxiContacts { get;set; }
		public DbSet<TaxiDriverCar> taxiDriverCars { get;set; }
		public DbSet<User> Users { get;set; }
		public DbSet<UserAccount> UserAccounts { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TaxiContact>()
                .HasKey(x => new { x.contactId, x.taxiId });
            modelBuilder.Entity<RoleUser>()
                .HasKey(x => new { x.userId, x.roleId });
            modelBuilder.Entity<TaxiDriverCar>()
                .HasKey(x => new { x.carId, x.taxiDriverId });
        }
    }
}
