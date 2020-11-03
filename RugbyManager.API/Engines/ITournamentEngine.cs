using RugbyManager.ClassLibrary.Models;
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
        Task<List<TournamentModel>> GetTournamentResultsForLeagueAsync(int leagueId);
    }
}
