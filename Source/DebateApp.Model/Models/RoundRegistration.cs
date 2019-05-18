using DebateApp.DataAccess.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace DebateApp.DataAccess.Models
{
	public class RoundRegistration : BaseModel
	{
		[Required]
		public Person Player1 { get; set; }

		public Person Player2 { get; set; }

		public DateTime DateTimeRegistration { get; set; }

		public bool IsJudge { get; set; }

		public string Comment { get; set; }

		public Language Language { get; set; }
	}
}
