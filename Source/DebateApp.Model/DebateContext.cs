using DebateApp.DataAccess.Models;
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
			optionsBuilder.UseMySQL("server=localhost;UserId=root;Password=mypassword;database=usersdb2;");
		}
	}
}
