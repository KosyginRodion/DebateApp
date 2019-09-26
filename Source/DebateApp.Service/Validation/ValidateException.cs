using System;

namespace DebateApp.Service.Validation
{
	public class ValidateException : ApplicationException
	{
		public ValidateException(string message) : base(message) { }
	}
}
