using DebateApp.Enum;

namespace DebateApp.Dto
{
	public class PersonDto
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public Role Role { get; set; }

		public int PhoneNumber { get; set; }

		public string Email { get; set; }
	}
}