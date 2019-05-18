using DebateApp.DataAccess.Enum;

namespace DebateApp.DataAccess.Models
{
	public class Person : BaseModel
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public Role Role { get; set; } = Role.Member;

		public int PhoneNumber { get; set; }

		public string Email { get; set; }
	}
}
