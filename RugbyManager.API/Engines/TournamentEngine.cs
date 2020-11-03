using RugbyManager.API.DataAccessLayer;
using RugbyManager.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RugbyManager.API.Engines
{
    public class TournamentEngine : ITournamentEngine
    {
        private readonly IRugbyManagerAccess _managerAccess;

        public TournamentEngine(IRugbyManagerAccess managerAccess)
        {
            _managerAccess = managerAccess;
        }

        public async Task GenerateTournamentForLeagueAsync(int leagueId)
        {
            await _managerAccess.GenerateTournamentForLeagueAsync(leagueId);
        }

        public async Task StartTournamentForLeagueAsync(int leagueId)
        {
            //TODO - apply logic
        }

        public async Task<List<TournamentModel>> GetTournamentResultsForLeagueAsync(int leagueId)
        {
            return await _managerAccess.GetTournamentDrawForLeagueAsync(leagueId);
        }
    }
}
