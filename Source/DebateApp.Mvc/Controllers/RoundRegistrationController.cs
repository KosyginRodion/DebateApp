using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebateApp.Mvc.Models.View;
using DebateApp.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DebateApp.Mvc.Controllers
{
	public class RoundRegistrationController : Controller
	{
		private readonly IRoundRegistrationService service;

		public RoundRegistrationController(IRoundRegistrationService service)
		{
			this.service = service;
		}

		public ActionResult GetRegistration()
		{
			var registrations = service.GetResentRegistration(DateTime.Now.Date);

			var registrationsView = new RoundRegistrationView()
			{
				Judges = registrations.Where(r => r.IsJudge),
				Players = registrations.Where(r => !r.IsJudge)
			};

			return View("AllRegistration", registrationsView);
		}
	}
}