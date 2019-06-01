using DebateApp.Enum;

namespace DebateApp.Dto
{
	public class RoundResultDto
	{
		public int RoundId { get; set; }

		public int PlayerId { get; set; }

		public Position Position { get; set; }

		public int Runk { get; set; }

		public int SpeakerPoints { get; set; }
	}
}