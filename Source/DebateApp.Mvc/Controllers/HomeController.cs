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

		public ActionResult Index()
		{
			return View();
		}
	}
}
