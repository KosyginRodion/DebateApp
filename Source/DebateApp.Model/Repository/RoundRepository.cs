using DebateApp.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DebateApp.DataAccess.Repository
{
	public class RoundRepository : IRoundRepository
	{
		DebateContext db;

		public RoundRepository(DebateContext context)
		{
			db = context;
		}

		public void Add(Round item)
		{
			item.CreatedDate = DateTime.Now;

			db.Add(item);

			db.SaveChanges();
		}

		public IEnumerable<Round> Find(Func<Round, bool> predicate)
		{
			var rounds = db.Rounds.Include(r => r.Chair).Where(predicate);

			return rounds;
		}

		public IEnumerable<Round> GetAll()
		{
			var rounds = db.Rounds.Include(r => r.Chair).ToList();

			return rounds;
		}

		public Round GetById(int id)
		{
			var round = db.Rounds.Include(r => r.Chair).Single(t => t.Id == id);

			return round;
		}

		public void Remove(int id)
		{
			var round = db.Rounds.Single(t => t.Id == id);

			round.ModifiedDate = DateTime.Now;
			round.Deleted = true;

			db.Rounds.Update(round);

			db.SaveChanges();
		}

		public void Update(Round round)
		{
			round.ModifiedDate = DateTime.Now;

			db.Rounds.Update(round);

			db.SaveChanges();
		}
	}
}
