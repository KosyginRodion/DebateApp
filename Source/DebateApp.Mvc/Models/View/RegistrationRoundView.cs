using DebateApp.Enum;
using DebateApp.Models;
using System;
using System.Collections.Generic;

namespace DebateApp.Mvc.Models.View
{
	public class RoundRegistrationView
	{
		public IEnumerable<RoundRegistration> Judges;

		public IEnumerable<RoundRegistration> Players;
	}
}
