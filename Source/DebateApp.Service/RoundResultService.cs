using System.Collections.Generic;
using System.Linq;
using DebateApp.DataAccess.Models;
using DebateApp.DataAccess.Repository;
using DebateApp.Dto;

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

		public void AddRound(RoundDto round)
		{
			var chair = personRepo.GetById(round.ChairId);

			var newRound = new Round
			{
				Chair = chair,
				DateTime = round.DateTime,
				Infoslide = round.Infoslide,
				Language = round.Language,
				Motion = round.Motion
			};

			roundRepo.Add(newRound);
		}

		public void AddResults(IEnumerable<RoundResultDto> roundResults)
		{
			foreach(var roundResult in roundResults)
			{
				var round = roundRepo.GetById(roundResult.RoundId);
				var player = personRepo.GetById(roundResult.PlayerId);

				var newRoundResult = new RoundResult
				{
					Player = player,
					Position = roundResult.Position,
					Round = round,
					Runk =  roundResult.Runk,
					SpeakerPoints = roundResult.SpeakerPoints
				};

				roundResultRepo.Add(newRoundResult);
			}
		}

		public IEnumerable<RoundResultViewDto> GetAll()
		{
			var roundResults = roundResultRepo.GetAll()
				.Select(r => new RoundResultViewDto
				{
					Player = new PersonDto
					{
						Email = r.Player.Email,
						FirstName = r.Player.FirstName,
						LastName = r.Player.LastName,
						Role = r.Player.Role
					},
					Round = new RoundViewDto
					{
						Chair = new PersonDto
						{
							Email = r.Round.Chair.Email,
							FirstName = r.Round.Chair.FirstName,
							LastName = r.Round.Chair.LastName,
							Role = r.Round.Chair.Role
						},
						DateTime = r.Round.DateTime,
						Infoslide = r.Round.Infoslide,
						Language = r.Round.Language,
						Motion = r.Round.Motion
					},
					Position = r.Position,
					Runk = r.Runk,
					SpeakerPoints = r.SpeakerPoints
				});

			return roundResults;
		}
	}
}
