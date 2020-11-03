using Microsoft.Extensions.Configuration;
using RugbyManager.API.ResourceAccess;
using RugbyManager.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RugbyManager.API.DataAccessLayer
{
    public class RugbyManagerAccess : BaseRepository, IRugbyManagerAccess
    {
        public RugbyManagerAccess(IConfiguration config) : base (config["SqlConfiguration:RMConnectionString"])
        {
        }

        public async Task AddPlayerAsync(PlayerModel player)
        {
            await ExecuteAsync("sp_InsertNewPlayer", player);
        }

        public async Task AddTeamAsync(TeamModel team)
        {
            throw new NotImplementedException();
        }

        public async Task AddLeagueAsync(LeagueModel league)
        {
            throw new NotImplementedException();
        }

        public async Task DeletePlayerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task DeletePlayerFromTeamAsync(int playerId, int teamId)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteTeamAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteTeamFromLeagueAsync(int teamId, int leagueId)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteLeagueAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetPlayerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetPlayersAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task GetTeamAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TeamModel>> GetTeamsForUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetLeagueAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetLeaguesForUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetLeaguesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<TournamentModel>> GetTournamentDrawForLeagueAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetTournamentDrawAsync()
        {
            throw new NotImplementedException();
        }

        public async Task GetStadiumsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task GetStadiumAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdatePlayerTeamAsync(PlayerTeamUpdateModel playerTeamUpdate)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateTeamStadiumAsync(TeamStadiumUpdateModel teamStadiumUpdate)
        {
            throw new NotImplementedException();
        }

        public async Task GenerateTournamentForLeagueAsync(int leagueId)
        {
            await ExecuteAsync("sp_GenerateTournamentForLeague", new { LeagueId = leagueId });
        }
    }
}
