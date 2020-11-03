using RugbyManager.API.DataAccessLayer;
using RugbyManager.ClassLibrary.Models;
using RugbyManager.ClassLibrary.Views;
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

        public async Task<List<TournamentModel>> GetTournamentDrawForLeagueAsync(int leagueId)
        {
            var results = await _managerAccess.GetTournamentDrawForLeagueAsync(leagueId);
            return results;
        }

        public async Task<TournamentResultsModel> GetTournamentResultsForLeagueAsync(int leagueId)
        {
            var results = await _managerAccess.GetTournamentDrawForLeagueAsync(leagueId);
            var processed = await CalculateTournamentResults(results);
            return processed;
        }

        private async Task<TournamentResultsModel> CalculateTournamentResults(List<TournamentModel> tournament)
        {
            var resultsModel = new TournamentResultsModel();

            //Todo

            return resultsModel;
        }
    }
}
