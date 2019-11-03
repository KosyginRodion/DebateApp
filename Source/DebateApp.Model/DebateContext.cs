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

		public DebateContext(DbContextOptions<DebateContext> options)
			:base(options)
		{
			Database.EnsureCreated();
		}
	}
}
