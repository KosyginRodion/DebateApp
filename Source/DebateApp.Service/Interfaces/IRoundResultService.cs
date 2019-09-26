using DebateApp.Models;
using System.Collections.Generic;

namespace DebateApp.Service
{
	public interface IRoundResultService
	{
		/// <summary>
		/// Добавить раунд
		/// </summary>
		/// <param name="round"></param>
		void AddRound(Round round);

		/// <summary>
		/// Добавить результат раунда
		/// </summary>
		void AddResults(IEnumerable<RoundResult> roundResult);

		/// <summary>
		/// Получить все результаты раундов
		/// </summary>
		IEnumerable<RoundResult> GetAll();
	}
}
