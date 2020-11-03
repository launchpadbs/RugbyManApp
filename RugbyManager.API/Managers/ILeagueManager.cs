using RugbyManager.ClassLibrary.Models;
using RugbyManager.ClassLibrary.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RugbyManager.API.Managers
{
    public interface ILeagueManager
    {
        Task<List<TournamentModel>> GetTournamentDrawForLeagueAsync(int leagueId);
        Task GenerateTournamentForLeagueAsync(int leagueId);
        Task<TournamentResultsModel> GetTournamentResultsForLeague(int leagueId);
    }
}
