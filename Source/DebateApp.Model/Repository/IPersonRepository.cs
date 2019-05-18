using DebateApp.DataAccess.Models;
using System;
using System.Collections.Generic;

namespace DebateApp.DataAccess.Repository
{
	public interface IPersonRepository
	{
		IEnumerable<Person> Find(Func<Person, Boolean> predicate);

		IEnumerable<Person> GetAll();

		Person GetById(int id);

		void Add(Person item);

		void Update(Person item);

		void Remove(int id);
	}
}
