using System;
using System.Collections.Generic;
using DebateApp.DataAccess.Models;
using DebateApp.DataAccess.Repository;

namespace DebateApp.Service
{
	public class RoundResultService : IRoundResultService
	{
		private readonly IRoundRepository roundRepo;
		private readonly IRoundResultRepository roundResultRepo;

		public RoundResultService(IRoundRepository roundRepo, IRoundResultRepository roundResultRepo)
		{
			this.roundRepo = roundRepo;
			this.roundResultRepo = roundResultRepo;
		}

		public void AddRound(Round round)
		{
			var newRound = new Round
			{
				Chair = round.Chair,
				DateTime = round.DateTime,
				Infoslide = round.Infoslide,
				Language = round.Language,
				Motion = round.Motion
			};

			roundRepo.Add(round);
		}

		public void AddResults(IEnumerable<RoundResult> roundResults)
		{
			foreach(var roundResult in roundResults)
			{
				var newRoundResult = new RoundResult
				{
					Player = roundResult.Player,
					Position = roundResult.Position,
					Round = roundResult.Round,
					Runk =  roundResult.Runk,
					SpeakerPoints = roundResult.SpeakerPoints
				};

				roundResultRepo.Add(newRoundResult);
			}
		}

		public IEnumerable<RoundResult> GetAll()
		{
			var roundResults = roundResultRepo.GetAll();

			return roundResults;
		}

		public IEnumerable<RoundResult> GetWithCondition(Func<RoundResult, bool> condition)
		{
			var roundResults = roundResultRepo.Find(condition);

			return roundResults;
		}
	}
}
