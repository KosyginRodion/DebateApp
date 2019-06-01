using DebateApp.Enum;

namespace DebateApp.Dto
{
	public class RoundResultViewDto
	{
		public RoundViewDto Round { get; set; }

		public PersonDto Player { get; set; }

		public Position Position { get; set; }

		public int Runk { get; set; }

		public int SpeakerPoints { get; set; }
	}
}
