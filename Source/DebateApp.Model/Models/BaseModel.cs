using System;

namespace DebateApp.DataAccess
{
	public class BaseModel
	{
		public int Id { get; set; }

		public DateTime CreatedDate { get; set; }

		public DateTime ModifiedDate { get; set; }

		public bool Deleted { get; set; }
	}
}