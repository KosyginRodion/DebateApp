﻿using System.Collections.Generic;
using DebateApp.Models;
using DebateApp.DataAccess.Repository;
using System.Linq;

namespace DebateApp.Service
{
	public class RoundResultService : IRoundResultService
	{
		private readonly IRoundRepository roundRepo;
		private readonly IRoundResultRepository roundResultRepo;
		private readonly IPersonRepository personRepo;

		public RoundResultService(IRoundRepository roundRepo, 
			IRoundResultRepository roundResultRepo, IPersonRepository personRepo)
		{
			this.roundRepo = roundRepo;
			this.roundResultRepo = roundResultRepo;
			this.personRepo = personRepo;
		}

		public void AddRound(Round round)
		{
			// TODO: Сделать проверку, что раунда с такими параметрами не существует
			roundRepo.Add(round);
		}

		public void AddResults(IEnumerable<RoundResult> roundResults)
		{
			// TODO: Сделать проверку, что введенные данные результатов соотвествуют правилам судейства
			roundResultRepo.Add(roundResults);
		}

		public IEnumerable<RoundResult> GetAll()
		{
			var roundResults = roundResultRepo.GetAll()
				.Where(r => !r.Deleted);

			return roundResults;
		}
	}
}
