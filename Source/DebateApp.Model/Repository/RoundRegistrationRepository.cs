using DebateApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DebateApp.DataAccess.Repository
{
	public class RoundRegistrationRepository : IRoundRegistrationRepository
	{
		DebateContext db;

		public RoundRegistrationRepository(DebateContext context)
		{
			db = context;
		}

		public void Add(RoundRegistration item)
		{
			item.CreatedDate = DateTime.Now;

			db.Add(item);

			db.SaveChanges();
		}

		public IEnumerable<RoundRegistration> Where(Func<RoundRegistration, bool> predicate)
		{
			var roundRegistrations = db.RoundRegistrations
				.Include(r => r.Player1).Include(r => r.Player2).Where(predicate);

			return roundRegistrations;
		}

		public IEnumerable<RoundRegistration> GetAll()
		{
			var roundRegistrations = db.RoundRegistrations
				.Include(r => r.Player1).Include(r => r.Player2).ToList();

			return roundRegistrations;
		}

		public RoundRegistration GetById(int id)
		{
			var roundRegistrations = db.RoundRegistrations
				.Include(r => r.Player1).Include(r => r.Player2).Single(t => t.Id == id);

			return roundRegistrations;
		}

		public void Remove(int id)
		{
			var registrationRound = db.RoundRegistrations.Single(t => t.Id == id);

			registrationRound.ModifiedDate = DateTime.Now;
			registrationRound.Deleted = true;

			db.RoundRegistrations.Update(registrationRound);

			db.SaveChanges();
		}

		public void Update(RoundRegistration registrationRound)
		{
			registrationRound.ModifiedDate = DateTime.Now;

			db.RoundRegistrations.Update(registrationRound);

			db.SaveChanges();
		}
	}
}
