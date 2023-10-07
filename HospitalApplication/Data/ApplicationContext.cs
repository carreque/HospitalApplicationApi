using HospitalApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalApplication.Data
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext() { }

		public ApplicationContext(DbContextOptions options) : base(options) { }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				IConfigurationRoot configuration = new ConfigurationBuilder()
			   .SetBasePath(Directory.GetCurrentDirectory())
			   .AddJsonFile("appsettings.json")
			   .Build();
				var connectionString = configuration.GetConnectionString("HotelDb");
				optionsBuilder.UseSqlServer(connectionString);
			}
		}

		public DbSet<Person> People { get; set; }
		public DbSet<Patient> Patients { get; set; }
		public DbSet<Nurse> Nurses { get; set; }
		public DbSet<Doctor> Doctors { get; set; }
		public DbSet<Administrator> Administrators { get; set; }
		public DbSet<Car> Cars { get; set; }
		public DbSet<Floor> Floors { get; set; }
		public DbSet<Parking> Parking { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<WorkersFloorsRelated> Workers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Car>()
						.HasOne(c => c.driver)
						.WithOne(u => u.car)
						.HasForeignKey<Car>(c => c.Id)
						.OnDelete(DeleteBehavior.Restrict);

		}
	}
}
