using DebateApp.DataAccess.Enum;
using System;

namespace DebateApp.DataAccess.Models
{
	public class Round : BaseModel
	{
		public string Motion { get; set; }

		public string Infoslide { get; set; }

		public Person Chair { get; set; }

		public DateTime DateTime { get; set; }

		public Language Language { get; set; }
	}
}
