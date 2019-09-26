using DebateApp.DataAccess.Repository;
using DebateApp.Dto;
using DebateApp.Enum;
using System.Linq;

namespace DebateApp.Service.Validation
{
	public class ValidationPerson
	{
		private readonly IPersonRepository personRepo;

		public ValidationPerson(IPersonRepository personRepo)
		{
			this.personRepo = personRepo;
		}

		/// <summary>
		/// Проверяем, что не существует пользователя с таким же электронным адресом
		/// </summary>
		public void Validate(PersonDto person)
		{
			var exist = personRepo.Find(p => p.Email == person.Email).Any();

			if (exist)
			{
				throw new ValidateException($"Пользователь с E-mail '{person.Email}' уже существует");
			}
		}

		/// <summary>
		/// Проверяем, что пользователю не назначена данная роль
		/// </summary>
		public void ValidateRole(PersonDto person, Role role)
		{
			if (person.Role == role)
			{
				var roleName = role == Role.Admin ? "Аднимистратор" : "Участник";

				throw new ValidateException($"Пользователю уже назначена роль '{roleName}'");
			}
		}
	}
}
