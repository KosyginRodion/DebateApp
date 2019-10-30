using DebateApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DebateApp.DataAccess
{
	public class DebateContext : DbContext
	{
		public DbSet<Person> Persons { get; set; }

		public DbSet<Round> Rounds { get; set; }

		public DbSet<RoundResult> RoundResults { get; set; }

		public DbSet<RoundRegistration> RoundRegistrations { get; set; }

		public DebateContext()
		{
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-AO7NV33\\SQLEXPRESS;Database=myDataBase;Trusted_Connection=True;");
		}
	}
}
