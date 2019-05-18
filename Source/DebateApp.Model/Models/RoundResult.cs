using DebateApp.DataAccess.Enum;

namespace DebateApp.DataAccess.Models
{
	public class RoundResult : BaseModel
	{
		public Round Round { get; set; }

		public Person Player { get; set; }

		public Position Position { get; set; }

		public int Runk { get; set; }

		public int SpeakerPoints { get; set; }
	}
}
