using System.Collections.Generic;
using System.Linq;
using DebateApp.DataAccess.Models;
using DebateApp.DataAccess.Repository;


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
			roundRepo.Add(round);
		}

		public void AddResults(IEnumerable<RoundResult> roundResults)
		{
			foreach(var roundResult in roundResults)
			{
				roundResultRepo.Add(roundResult);
			}
		}

		public IEnumerable<RoundResult> GetAll()
		{
			var roundResults = roundResultRepo.GetAll();

			return roundResults;
		}
	}
}
