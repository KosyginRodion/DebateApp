using DebateApp.DataAccess.Enum;
using System.ComponentModel.DataAnnotations;

namespace DebateApp.DataAccess.Models
{
	public class RoundResult : BaseModel
	{
		[Required]
		public Round Round { get; set; }

		[Required]
		public Person Player { get; set; }

		public Position Position { get; set; }

		public int Runk { get; set; }

		public int SpeakerPoints { get; set; }
	}
}
