using DebateApp.Enum;
using System;

namespace DebateApp.Dto
{
	public class RoundViewDto
	{
		public string Motion { get; set; }

		public string Infoslide { get; set; }

		public PersonDto Chair { get; set; }

		public DateTime DateTime { get; set; }

		public Language Language { get; set; }
	}
}
