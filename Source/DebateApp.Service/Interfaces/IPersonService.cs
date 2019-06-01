using DebateApp.Dto;
using System.Collections.Generic;

namespace DebateApp.Service
{
	interface IPersonService
	{
		/// <summary>
		/// Создать нового пользователя
		/// </summary>
		void Add(PersonDto person);

		/// <summary>
		/// Изменить данные о пользователе
		/// </summary>
		void EditInfo(int personId, PersonDto person);

		/// <summary>
		/// Отметить пользователя как удаленного
		/// </summary>
		void Remove(int personId);

		/// <summary>
		/// Получить всех пользователей (кроме помеченных на удаление)
		/// </summary>
		IEnumerable<PersonDto> GetAll();

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
