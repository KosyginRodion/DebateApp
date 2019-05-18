﻿using System;
using System.Collections.Generic;
using DebateApp.DataAccess.Models;
using DebateApp.DataAccess.Repository;

namespace DebateApp.Service
{
	public class RegistrationRoundService : IRegistrationRoundService
	{
		private readonly IRoundRegistrationRepository registrationRepo;
		private readonly IPersonRepository personRepo;

		public RegistrationRoundService(IRoundRegistrationRepository registrationRepo,
			IPersonRepository personRepo)
		{
			this.registrationRepo = registrationRepo;
			this.personRepo = personRepo;
		}

		public void AddTeammate(int registrationId, int player2Id)
		{
			var registration = registrationRepo.GetById(registrationId);
			var teammate = personRepo.GetById(player2Id);

			registration.Player2 = teammate;

			registrationRepo.Update(registration);
		}

		public IEnumerable<RoundRegistration> GetAll()
		{
			var registrations = registrationRepo.GetAll();

			return registrations;
		}

		public IEnumerable<RoundRegistration> GetResentRegistration(DateTime dateTime)
		{
			var resentRegistrations = registrationRepo.Find(r => r.DateTimeRegistration >= dateTime);

			return resentRegistrations;
		}

		public void Registr(RoundRegistration roundRegistration)
		{
			var newRegistration = new RoundRegistration
			{
				Player1 = roundRegistration.Player1,
				Player2 = roundRegistration.Player2,
				DateTimeRegistration = roundRegistration.DateTimeRegistration,
				IsJudge = roundRegistration.IsJudge,
				Language = roundRegistration.Language,
				Comment = roundRegistration.Comment
			};

			registrationRepo.Add(newRegistration);
		}

		public void RemoveRegistration(int registrationId)
		{
			registrationRepo.Remove(registrationId);
		}
	}
}
