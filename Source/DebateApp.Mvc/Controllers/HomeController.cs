using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DebateApp.Mvc.Models;
using DebateApp.Service;
using DebateApp.Models;
using DebateApp.Enum;

namespace DebateApp.Mvc.Controllers
{
	public class HomeController : Controller
	{
		private readonly IRoundRegistrationService roundRegistrationService;
		private readonly IPersonService personService;

		public HomeController(/*IRoundRegistrationService roundRegistrationService*/)
		{
			//this.roundRegistrationService = roundRegistrationService;
		}

		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
        public void Registr(RoundRegistrationDto roundRegistrationDto)
		{
			Language lang = Language.Russian;
			if (roundRegistrationDto.Language == "Русский")
			{
				lang = Language.Russian;
			}
			else if (roundRegistrationDto.Language == "Английский")
			{
				lang = Language.English;
			}
			var roundRegistration = new RoundRegistration
			{
				Player1 = personService.GetById(roundRegistrationDto.Player1_Id),
				Player2 = personService.GetById(roundRegistrationDto.Player2_Id),
				DateTimeRegistration = DateTime.Parse(roundRegistrationDto.DateTimeRegistration),
				IsJudge = roundRegistrationDto.IsJudge,
				Comment = roundRegistrationDto.Comment,
				Language = lang
			};

			roundRegistrationService.Registr(roundRegistration);
		}
    }
}
