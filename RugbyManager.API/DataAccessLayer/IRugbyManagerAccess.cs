using RugbyManager.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RugbyManager.API.DataAccessLayer
{
    public interface IRugbyManagerAccess
    {
        Task AddPlayerAsync(PlayerModel player);
        Task AddTeamAsync(TeamModel team);
        Task AddLeagueAsync(LeagueModel league);
        Task DeletePlayerAsync(int id);
        Task DeleteTeamAsync(int id);
        Task DeleteLeagueAsync(int id);
        Task GetPlayerAsync(int id);
        Task GetPlayersAsync(int userId);
        Task GetTeamAsync(int id);
        Task<List<TeamModel>> GetTeamsForUserAsync(int id);
        Task GetLeagueAsync(int id);
        Task GetLeaguesForUserAsync(int id);
        Task GetLeaguesAsync();
        Task<List<TournamentModel>> GetTournamentDrawForLeagueAsync(int id);
        Task GetTournamentDrawAsync();
        Task GetStadiumsAsync();
        Task GetStadiumAsync(int id);
        Task UpdatePlayerTeamAsync(PlayerTeamUpdateModel playerTeamUpdate);
        Task UpdateTeamStadiumAsync(TeamStadiumUpdateModel teamStadiumUpdate);
        Task GenerateTournamentForLeagueAsync(int leagueId);
    }
}
