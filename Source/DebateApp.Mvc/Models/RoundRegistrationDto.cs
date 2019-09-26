using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebateApp.Mvc.Models
{
	public class RoundRegistrationDto
	{
		public int Player1_Id { get; set; }

		public int Player2_Id { get; set; }

		public string DateTimeRegistration { get; set; }

		public bool IsJudge { get; set; }

		public string Comment { get; set; }

		public string Language { get; set; }
	}
}
