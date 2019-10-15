<<<<<<< Updated upstream
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebateApp.DataAccess.Repository;
using DebateApp.Models;
using DebateApp.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DebateApp.Mvc.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
			var persons = GetPersons();

            return View(persons);
        }

		private IEnumerable<Person> GetPersons()
		{
			var persons = new List<Person>();
			persons.Add(new Person
			{
				FirstName = "Рома",
				LastName = "Зоренко",
				Id = 3,
				Email = "wkbwkefbqwfhqwojf"
			});
			persons.Add(new Person
			{
				FirstName = "Родион",
				LastName = "Косыгин",
				Id = 1,
				Email = "тулатутцрацпца"
			});
			persons.Add(new Person
			{
				FirstName = "Саша",
				LastName = "Соколовский",
				Id = 2,
				Email = "уацацуафыасфаы"
			});

			return persons.OrderBy(p => p.Id);
		}

		// GET: Person/Create
		public ActionResult Create()
        {
            return View();
        }
    }
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DebateApp.Mvc.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }
    }
>>>>>>> Stashed changes
}