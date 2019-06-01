using DebateApp.Dto;
using System.Collections.Generic;

namespace DebateApp.Service
{
	interface IRoundResultService
	{
		/// <summary>
		/// Добавить раунд
		/// </summary>
		/// <param name="round"></param>
		void AddRound(RoundDto round);

		/// <summary>
		/// Добавить результат раунда
		/// </summary>
		void AddResults(IEnumerable<RoundResultDto> roundResult);

		/// <summary>
		/// Получить все результаты раундов
		/// </summary>
		IEnumerable<RoundResultViewDto> GetAll();
	}
}
