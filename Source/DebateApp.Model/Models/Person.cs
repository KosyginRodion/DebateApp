﻿using DebateApp.DataAccess.Enum;
using System.ComponentModel.DataAnnotations;

namespace DebateApp.DataAccess.Models
{
	public class Person : BaseModel
	{
		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		public Role Role { get; set; } = Role.Member;

		public int PhoneNumber { get; set; }

		public string Email { get; set; }
	}
}
