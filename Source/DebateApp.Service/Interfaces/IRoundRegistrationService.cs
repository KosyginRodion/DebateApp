using DebateApp.Models;
using System;
using System.Collections.Generic;

namespace DebateApp.Service
{
	public interface IRoundRegistrationService
	{
		/// <summary>
		/// Зарегистрироваться на раунд
		/// </summary>
		void Registr(RoundRegistration roundRegistration);

		/// <summary>
		/// Отменить регистрацию на раунд как удаленную
		/// </summary>
		void RemoveRegistration(int registrationId);

		/// <summary>
		/// Добавить тиммейта к себе в команду
		/// </summary>
		void AddTeammate(int registrationId, int teammateId);

		/// <summary>
		/// Получить все регистрации (кроме удаленных)
		/// </summary>
		IEnumerable<RoundRegistration> GetAll();

		/// <summary>
		/// Получить недавние регистрации
		/// </summary>
		/// <param name="dateTime">Дата, начиная с которой выбираются регистрации</param>
		IEnumerable<RoundRegistration> GetResentRegistration(DateTime dateTime);
	}
}
