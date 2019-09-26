using DebateApp.DataAccess.Models;
using DebateApp.DataAccess.Repository;
using System.Text;

namespace DebateApp.Service.Validation
{
	public class ValidationRegistrationRound
	{
		private readonly IRoundRegistrationRepository registrationRepo;

		public ValidationRegistrationRound(IRoundRegistrationRepository registrationRepo)
		{
			this.registrationRepo = registrationRepo;
		}

		public void ValidateNewTeammate(RoundRegistration registration, Person teammate)
		{
			var message = new StringBuilder();

			if (registration.Player2 != null)
			{
				var playerName = registration.Player1.FirstName + registration.Player1.LastName;
				var teammateName = registration.Player2.FirstName + registration.Player2.LastName;

				message.AppendLine($"Нельзя добавить тиммейта. У игрока {playerName} уже есть тиммейт {teammateName}");
			}
		}
	}
}
