using DebateApp.Models;
using System;
using System.Collections.Generic;

namespace DebateApp.DataAccess.Repository
{
	public interface IRoundRegistrationRepository
	{
		IEnumerable<RoundRegistration> Find(Func<RoundRegistration, Boolean> predicate);

		IEnumerable<RoundRegistration> GetAll();

		RoundRegistration GetById(int id);

		void Add(RoundRegistration item);

		void Update(RoundRegistration item);

		void Remove(int id);
	}
}
