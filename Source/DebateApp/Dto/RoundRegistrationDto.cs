using DebateApp.Enum;
using System;

namespace DebateApp.Dto
{
	public class RoundRegistrationDto
	{
		public int Player1Id { get; set; }

		public int Player2Id { get; set; }

		public DateTime DateTimeRegistration { get; set; }

		public bool IsJudge { get; set; }

		public string Comment { get; set; }

		public Language Language { get; set; }
	}
}