using DebateApp.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace DebateApp.DataAccess.Repository
{
	public interface IRoundResultRepository
	{
		IEnumerable<RoundResult> Find(Func<RoundResult, Boolean> predicate);

		IEnumerable<RoundResult> GetAll();

		RoundResult GetById(int id);

		void Add(IEnumerable<RoundResult> items);

		void Update(RoundResult item);

		void Remove(int id);
	}
}
