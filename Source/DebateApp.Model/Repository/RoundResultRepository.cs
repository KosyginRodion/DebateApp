using DebateApp.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DebateApp.DataAccess.Repository
{
	public class RoundResultRepository : IRoundResultRepository
	{
		DebateContext db;

		public RoundResultRepository(DebateContext context)
		{
			db = context;
		}

		public void Add(RoundResult item)
		{
			item.CreatedDate = DateTime.Now;

			db.Add(item);

			db.SaveChanges();
		}

		public IEnumerable<RoundResult> Find(Func<RoundResult, bool> predicate)
		{
			var roundResults = db.RoundResults
				.Include(r => r.Player).Include(r => r.Round)
				.ThenInclude(r => r.Chair).Where(predicate);

			return roundResults;
		}

		public IEnumerable<RoundResult> GetAll()
		{
			var roundResults = db.RoundResults
				.Include(r => r.Player).Include(r => r.Round)
				.ThenInclude(r => r.Chair).ToList();

			return roundResults;
		}

		public RoundResult GetById(int id)
		{
			var roundResult = db.RoundResults
				.Include(r => r.Player).Include(r => r.Round)
				.ThenInclude(r => r.Chair).Single(t => t.Id == id);

			return roundResult;
		}

		public void Remove(int id)
		{
			var roundResult = db.RoundResults.Single(t => t.Id == id);

			roundResult.ModifiedDate = DateTime.Now;
			roundResult.Deleted = true;

			db.RoundResults.Update(roundResult);

			db.SaveChanges();
		}

		public void Update(RoundResult roundResult)
		{
			roundResult.ModifiedDate = DateTime.Now;

			db.RoundResults.Update(roundResult);

			db.SaveChanges();
		}
	}
}
