using System.Collections.Generic;
using DebateApp.Models;

namespace DebateApp.Service
{
	interface IPersonService
	{
		/// <summary>
		/// Создать нового пользователя
		/// </summary>
		void Add(Person person);

		/// <summary>
		/// Изменить данные о пользователе
		/// </summary>
		void EditInfo(Person person);

		/// <summary>
		/// Отметить пользователя как удаленного
		/// </summary>
		void Remove(int personId);

		/// <summary>
		/// Получить всех пользователей (кроме помеченных на удаление)
		/// </summary>
		IEnumerable<Person> GetAll();

		/// <summary>
		/// Назначить пользователя аднимистратором
		/// </summary>
		void AppointAdmin(int personId);

		/// <summary>
		/// Расжаловать пользователя
		/// </summary>
		void DisrateAdmin(int personId);
	}
}
