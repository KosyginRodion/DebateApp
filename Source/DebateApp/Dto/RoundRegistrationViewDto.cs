using DebateApp.Enum;
using System;

namespace DebateApp.Dto
{
	public class RoundRegistrationViewDto
	{
		public PersonDto Player1 { get; set; }

		public PersonDto Player2 { get; set; }

		public DateTime DateTimeRegistration { get; set; }

		public bool IsJudge { get; set; }

		public string Comment { get; set; }

		public Language Language { get; set; }
	}
}
