using System;
using System.Collections.Generic;
using DebateApp.Models;
using DebateApp.DataAccess.Repository;
using System.Linq;

namespace DebateApp.Service
{
	public class RoundRegistrationService : IRoundRegistrationService
	{
		private readonly IRoundRegistrationRepository registrationRepo;
		private readonly IPersonRepository personRepo;

		public RoundRegistrationService(IRoundRegistrationRepository registrationRepo,
			IPersonRepository personRepo)
		{
			this.registrationRepo = registrationRepo;
			this.personRepo = personRepo;
		}

		public void AddTeammate(int registrationId, int teammate2Id)
		{
			// TODO: Сделать проверку, что у игрока еще нет тиммейта
			var registration = registrationRepo.GetById(registrationId);
			var teammate = personRepo.GetById(teammate2Id);

			registration.Player2 = teammate;

			registrationRepo.Update(registration);
		}

		public IEnumerable<RoundRegistration> GetAll()
		{
			var registrations = registrationRepo.GetAll()
				.Where(r => !r.Deleted);

			return registrations;
		}

		public IEnumerable<RoundRegistration> GetResentRegistration(DateTime dateTime)
		{
			var resentRegistrations = registrationRepo
				.Where(r => r.DateTimeRegistration >= dateTime);

			return resentRegistrations;
		}

		public void Registr(RoundRegistration roundRegistration)
		{
			// TODO: Сделать проверку, что игроки еще не зарегистрированы
			registrationRepo.Add(roundRegistration);
		}

		public void RemoveRegistration(int registrationId)
		{
			registrationRepo.Remove(registrationId);
		}
	}
}
