using DebateApp.Models;
using System;
using System.Collections.Generic;

namespace DebateApp.DataAccess.Repository
{
	public interface IRoundRepository
	{
		IEnumerable<Round> Where(Func<Round, Boolean> predicate);

		IEnumerable<Round> GetAll();

		Round GetById(int id);

		void Add(Round item);

		void Update(Round item);

		void Remove(int id);
	}
}
