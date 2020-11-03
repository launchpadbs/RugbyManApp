using Microsoft.Extensions.Logging;
using RugbyManager.API.Engines;
using RugbyManager.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RugbyManager.API.Managers
{
    public class LeagueManager : ILeagueManager
    {
        private readonly ILogger<LeagueManager> _logger;
        private readonly ITournamentEngine _tournamentEngine;

        public LeagueManager(ILogger<LeagueManager> logger, ITournamentEngine tournamentEngine)
        {
            _logger = logger;
            _tournamentEngine = tournamentEngine;
        }

        public async Task<List<TournamentModel>> GetTournamentDrawForLeagueAsync(int leagueId)
        {
            return await _tournamentEngine.GetTournamentResultsForLeagueAsync(leagueId);
        }

        public async Task GenerateTournamentForLeagueAsync(int leagueId)
        {
            throw new NotImplementedException();
        }
    }
}
