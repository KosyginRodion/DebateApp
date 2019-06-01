using DebateApp.Enum;
using System;

namespace DebateApp.Dto
{
	public class RoundDto
	{
		public string Motion { get; set; }

		public string Infoslide { get; set; }

		public int ChairId { get; set; }

		public DateTime DateTime { get; set; }

		public Language Language { get; set; }
	}
}