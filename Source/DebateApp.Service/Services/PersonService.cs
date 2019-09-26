using System.Collections.Generic;
using System.Linq;
using DebateApp.DataAccess.Models;
using DebateApp.DataAccess.Repository;
using DebateApp.Enum;

namespace DebateApp.Service
{
	public class PersonService : IPersonService
	{
		private readonly IPersonRepository personRepo;


		public PersonService(IPersonRepository personRepo)
		{
			this.personRepo = personRepo;
		}

		public void Add (Person person)
		{
			var newPerson = new Person
			{
				FirstName = person.FirstName,
				LastName = person.LastName,
				Email = person.Email
			};

			personRepo.Add(newPerson);
		}

		public void EditInfo (int personId, Person personEdit)
		{
			var person = personRepo.GetById(personId);

			person.FirstName = personEdit.FirstName;
			person.LastName = personEdit.LastName;
			person.Email = personEdit.Email;

			personRepo.Update(person);
		}

		public void Remove (int personId)
		{
			personRepo.Remove(personId);
		}

		public IEnumerable<Person> GetAll()
		{
			var persons = personRepo.GetAll().Where(p => !p.Deleted)
				.Select(p => new Person
				{
					FirstName = p.FirstName,
					LastName = p.LastName,
					Email = p.Email,
					Role = p.Role
				});

			return persons;
		}

		public void AppointAdmin (int personId)
		{
			var person = personRepo.GetById(personId);

			person.Role = Role.Admin;

			personRepo.Update(person);
		}

		public void DisrateAdmin (int personId)
		{
			var person = personRepo.GetById(personId);

			person.Role = Role.Member;

			personRepo.Update(person);
		}
	}
}
