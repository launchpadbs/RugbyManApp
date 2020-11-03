using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RugbyManager.API.Managers;
using RugbyManager.ClassLibrary.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RugbyManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RugbyManagerController : ControllerBase
    {
        private readonly ILogger<RugbyManagerController> _logger;
        private readonly IPlayerManager _playerManager;
        private readonly ITeamManager _teamManager;
        private readonly ILeagueManager _leagueManager;

        public RugbyManagerController(ILogger<RugbyManagerController> logger, IPlayerManager playerManager, ITeamManager teamManager, ILeagueManager leagueManager)
        {
            _logger = logger;
            _playerManager = playerManager;
            _teamManager = teamManager;
            _leagueManager = leagueManager;
        }

        /// <summary>
        /// Creates new Rugby player in system
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        [Route("AddPlayer")]
        [HttpPost]
        public async Task<ActionResult> AddPlayerAsync([FromBody] PlayerModel player)
        {
            try
            {
                if (player != null)
                {
                    await _playerManager.AddPlayerAsync(player);
                    return Ok();
                }
                else
                {
                    return BadRequest("Player payload cannot be empty");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding player with message: {ex.Message}");
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Creates new Rugby team in system
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        [Route("AddTeam")]
        [HttpPost]
        public async Task<ActionResult> AddTeamAsync([FromBody] TeamModel team)
        {
            try
            {
                if (team != null)
                {
                    await _teamManager.AddTeamAsync(team);
                    return Ok();
                }
                else
                {
                    return BadRequest("Team payload cannot be empty");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding team with message: {ex.Message}");
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Creates new Rugby Union league in system
        /// </summary>
        /// <param name="league"></param>
        /// <returns></returns>
        [Route("AddLeague")]
        [HttpPost]
        public async Task<ActionResult> AddLeagueAsync([FromBody] LeagueModel league)
        {
            try
            {
                //Todo
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error adding league with message: {ex.Message}");
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Delete Rugby Player from system if not in active Team
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        [Route("DeletePlayer/{playerId}")]
        [HttpDelete]
        public async Task<ActionResult> DeletePlayerAsync(int playerId)
        {
            try
            {
                //Todo
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error removing player with message: {ex.Message}");
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Delete Team from system if not in active League
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        [Route("DeleteTeam/{teamId}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteTeamAsync(int teamId)
        {
            try
            {
                //Todo
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error removing team with message: {ex.Message}");
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Delete League from system if not in active Tournament
        /// </summary>
        /// <param name="leagueId"></param>
        /// <returns></returns>
        [Route("DeleteLeague/{leagueId}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteLeagueAsync(int leagueId)
        {
            try
            {
                //Todo
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error removing league with message: {ex.Message}");
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Get Rugby Player by unique Id
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        [Route("GetPlayer/{playerId}")]
        [HttpGet]
        public async Task<ActionResult> GetPlayerAsync(int playerId)
        {
            try
            {
                //Todo
                return Ok(new PlayerModel());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving player with message: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get Players for User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("GetPlayers/{userId}")]
        [HttpGet]
        public async Task<ActionResult> GetPlayersAsync(int userId)
        {
            try
            {
                //Todo
                return Ok(new List<PlayerModel>());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving players with message: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get Team by unique Id
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns></returns>
        [Route("GetTeam/{teamId}")]
        [HttpGet]
        public async Task<ActionResult> GetTeamAsync(int teamId)
        {
            try
            {
                //Todo
                return Ok(new TeamModel());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving team with message: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get all Teams created by User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("GetTeams/{userId}")]
        [HttpGet]
        public async Task<ActionResult> GetTeamsForUserAsync(int userId)
        {
            try
            {
                //Todo
                return Ok(new List<TeamModel>());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving teams for user Id: {userId}, with message: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get League by unique Id
        /// </summary>
        /// <param name="leagueId"></param>
        /// <returns></returns>
        [Route("GetLeague/{leagueId}")]
        [HttpGet]
        public async Task<ActionResult> GetLeagueAsync(int leagueId)
        {
            try
            {
                //Todo
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving league with message: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get Leagues create by User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("GetLeagues/{userId}")]
        [HttpGet]
        public async Task<ActionResult> GetLeaguesForUserAsync(int userId)
        {
            try
            {
                //Todo
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving leagues for user Id: {userId}, with message: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get all Leagues
        /// </summary>
        /// <returns></returns>
        [Route("GetLeagues")]
        [HttpGet]
        public async Task<ActionResult> GetLeaguesAsync()
        {
            try
            {
                //Todo
                return Ok(new List<LeagueModel>());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving leagues with message: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get Tournament information for specified League
        /// </summary>
        /// <param name="leagueId"></param>
        /// <returns></returns>
        [Route("GetTournamentDraw/{leagueId}")]
        [HttpGet]
        public async Task<ActionResult> GetTournamentDrawForLeagueAsync(int leagueId)
        {
            try
            {
                var result = await _leagueManager.GetTournamentDrawForLeagueAsync(leagueId);
                //Todo - business logic
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving Tournament Draw for League Id: {leagueId}, with message: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get all Tournaments Information
        /// </summary>
        /// <returns></returns>
        [Route("GetTournamentDraws")]
        [HttpGet]
        public async Task<ActionResult> GetTournamentDrawsAsync()
        {
            try
            {
                //Todo
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving Tournament Draws with message: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Return a list of Stadiums
        /// </summary>
        /// <returns></returns>
        [Route("GetStadiums")]
        [HttpGet]
        public async Task<ActionResult> GetStadiumsAsync()
        {
            try
            {
                //Todo
                return Ok(new List<StadiumModel>());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving Stadiums with message: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get Stadium by unique Id
        /// </summary>
        /// <param name="stadiumId"></param>
        /// <returns></returns>
        [Route("GetStadium/{stadiumId}")]
        [HttpGet]
        public async Task<ActionResult> GetStadiumAsync(int stadiumId)
        {
            try
            {
                //Todo
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving Stadium Id: {stadiumId} with message: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Transfer Player from one Team to another
        /// </summary>
        /// <param name="playerTeamUpdate"></param>
        /// <returns></returns>
        [Route("UpdatePlayerTeam")]
        [HttpPut]
        public async Task<ActionResult> UpdatePlayerTeamAsync([FromBody] PlayerTeamUpdateModel playerTeamUpdate)
        {
            try
            {
                //Todo
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating player team with message: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Change Stadium for Team
        /// </summary>
        /// <param name="teamStadiumUpdate"></param>
        /// <returns></returns>
        [Route("UpdateTeamStadium")]
        [HttpPut]
        public async Task<ActionResult> UpdateTeamStadiumAsync([FromBody] TeamStadiumUpdateModel teamStadiumUpdate)
        {
            try
            {
                //Todo
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating team stadium with message: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Kick off random League tournament genration 
        /// </summary>
        /// <param name="leagueId"></param>
        /// <returns></returns>
        [Route("GenerateTournamentForLeague/{leagueId}")]
        [HttpGet]
        public async Task<ActionResult> GenerateTournamentForLeagueAsync(int leagueId)
        {
            try
            {
                //Todo
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error creating Tournament with message: {ex.Message}");
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Start generated Tournament
        /// </summary>
        /// <param name="leagueId"></param>
        /// <returns></returns>
        [Route("StartTournamentForLeague/{leagueId}")]
        [HttpGet]
        public async Task<ActionResult> StartTournamentForLeagueAsync(int leagueId)
        {
            try
            {
                //Todo
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error starting tournament for league Id: {leagueId} with message: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

    }
}
