using System.Collections.Generic;
using System.Linq;
using DebateApp.DataAccess.Models;
using DebateApp.DataAccess.Repository;

namespace DebateApp.Service
{
	public class PersonService : IPersonService
	{
		private readonly IPersonRepository personRepo;

		public PersonService(IPersonRepository personRepository)
		{
			this.personRepo = personRepository;
		}

		public void Add (Person person)
		{
			var newPerson = new Person
			{
				FirstName = person.FirstName,
				LastName = person.LastName,
				PhoneNumber = person.PhoneNumber,
				Email = person.Email
			};

			personRepo.Add(person);
		}

		public void EditInfo (int personOldId, Person personEdit)
		{
			var person = personRepo.GetById(personOldId);

			person.FirstName = personEdit.FirstName;
			person.LastName = personEdit.LastName;
			person.PhoneNumber = personEdit.PhoneNumber;
			person.Email = personEdit.Email;

			personRepo.Update(person);
		}

		public void Remove (int personId)
		{
			personRepo.Remove(personId);
		}

		public IEnumerable<Person> GetAll()
		{
			var persons = personRepo.GetAll().Where(p => !p.Deleted);

			return persons;
		}

		public void AppointAdmin (int personId)
		{
			var person = personRepo.GetById(personId);

			person.Role = DataAccess.Enum.Role.Admin;

			personRepo.Update(person);
		}

		public void DisrateAdmin (int personId)
		{
			var person = personRepo.GetById(personId);

			person.Role = DataAccess.Enum.Role.Member;

			personRepo.Update(person);
		}
	}
}
