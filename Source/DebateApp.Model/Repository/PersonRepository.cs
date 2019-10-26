using DebateApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DebateApp.DataAccess.Repository
{
	public class PersonRepository : IPersonRepository
	{
		private DebateContext db;

		public PersonRepository(DebateContext context)
		{
			db = context;
		}

		public void Add(Person item)
		{
			item.CreatedDate = DateTime.Now;

			db.Add(item);

			db.SaveChanges();
		}

		public IEnumerable<Person> Where(Func<Person, bool> predicate)
		{
			var persons = db.Persons.Where(predicate);

			return persons;
		}

		public IEnumerable<Person> GetAll()
		{
			var persons = db.Persons.ToList();

			return persons;
		}

		public Person GetById(int id)
		{
			var person = db.Persons.Single(t => t.Id == id);

			return person;
		}

		public void Remove(int id)
		{
			var person = db.Persons.Single(t => t.Id == id);

			person.ModifiedDate = DateTime.Now;
			person.Deleted = true;

			db.Persons.Update(person);

			db.SaveChanges();
		}

		public void Update(Person person)
		{
			person.ModifiedDate = DateTime.Now;

			db.Persons.Update(person);

			db.SaveChanges();
		}
	}
}
