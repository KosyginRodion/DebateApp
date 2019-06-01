using System;
using System.Collections.Generic;
using System.Linq;
using DebateApp.DataAccess.Models;
using DebateApp.DataAccess.Repository;
using DebateApp.Dto;

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

		public void AddTeammate(int registrationId, int teammate2Id)
		{
			var registration = registrationRepo.GetById(registrationId);
			var teammate = personRepo.GetById(teammate2Id);

			registration.Player2 = teammate;

			registrationRepo.Update(registration);
		}

		public IEnumerable<RoundRegistrationViewDto> GetAll()
		{
			var registrations = registrationRepo.GetAll()
				.Select(r => new RoundRegistrationViewDto
				{
					Player1 = new PersonDto
					{
						FirstName = r.Player1.FirstName,
						LastName = r.Player1.LastName,
						Email = r.Player1.Email,
						PhoneNumber = r.Player1.PhoneNumber,
						Role = r.Player1.Role
					},
					Player2 = new PersonDto
					{
						FirstName = r.Player2.FirstName,
						LastName = r.Player2.LastName,
						Email = r.Player2.Email,
						PhoneNumber = r.Player2.PhoneNumber,
						Role = r.Player2.Role
					},
					DateTimeRegistration = r.DateTimeRegistration,
					IsJudge = r.IsJudge,
					Language = r.Language,
					Comment = r.Comment
				});

			return registrations;
		}

		public IEnumerable<RoundRegistrationViewDto> GetResentRegistration(DateTime dateTime)
		{
			var resentRegistrations = registrationRepo.Find(r => r.DateTimeRegistration >= dateTime)
				.Select(r => new RoundRegistrationViewDto
				{
					Player1 = new PersonDto
					{
						FirstName = r.Player1.FirstName,
						LastName = r.Player1.LastName,
						Email = r.Player1.Email,
						PhoneNumber = r.Player1.PhoneNumber,
						Role = r.Player1.Role
					},
					Player2 = new PersonDto
					{
						FirstName = r.Player2.FirstName,
						LastName = r.Player2.LastName,
						Email = r.Player2.Email,
						PhoneNumber = r.Player2.PhoneNumber,
						Role = r.Player2.Role
					},
					DateTimeRegistration = r.DateTimeRegistration,
					IsJudge = r.IsJudge,
					Language = r.Language,
					Comment = r.Comment
				});

			return resentRegistrations;
		}

		public void Registr(RoundRegistrationDto roundRegistration)
		{
			var player1 = personRepo.GetById(roundRegistration.Player1Id);
			var player2 = personRepo.GetById(roundRegistration.Player2Id);

			var newRegistration = new RoundRegistration
			{
				Player1 = player1,
				Player2 = player2,
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
