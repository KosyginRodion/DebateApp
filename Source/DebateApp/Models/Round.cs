using DebateApp.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace DebateApp.Models
{
	public class Round : BaseModel
	{
		[Required]
		public string Motion { get; set; }

		public string Infoslide { get; set; }

		[Required]
		public Person Chair { get; set; }

		public DateTime DateTime { get; set; }

		public Language Language { get; set; }
	}
}
