using RugbyManager.ClassLibrary.Models;
using RugbyManager.ClassLibrary.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RugbyManager.API.Engines
{
    public interface ITournamentEngine
    {
        Task GenerateTournamentForLeagueAsync(int leagueId);
        Task StartTournamentForLeagueAsync(int leagueId);
        Task<List<TournamentModel>> GetTournamentDrawForLeagueAsync(int leagueId);
        Task<TournamentResultsModel> GetTournamentResultsForLeagueAsync(int leagueId);
    }
}
