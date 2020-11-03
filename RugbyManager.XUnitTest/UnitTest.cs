using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using RugbyManager.API;
using RugbyManager.ClassLibrary.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace RugbyManager.XUnitTest
{
    public class UnitTest
    {
        private TestServer _server;
        private HttpClient _client;
        private static Uri apiUri = new Uri("api/v1/RugbyManager/");

        public UnitTest()
        {
            _server = new TestServer(new WebHostBuilder()
                                        .UseEnvironment("Development")
                                        .UseContentRoot(Directory.GetCurrentDirectory())
                                        .UseConfiguration(new ConfigurationBuilder()
                                                       .SetBasePath(Directory.GetCurrentDirectory())
                                                       .AddJsonFile("appsettings.json")
                                                       .Build()
                                     )
                                     .UseStartup<Startup>());

            _client = _server.CreateClient();
            _client.BaseAddress = new Uri("http://localhost:5000");
        }

        [Fact]
        public async Task ServiceUpCheck()
        {
            var response = await _client.GetAsync("/Ping");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var responeJson = await response.Content.ReadAsStringAsync();
            responeJson.Should().Contain("Healthy");
        }

        [Fact]
        public async Task AddRugbyPlayers()
        {
            for (int i = 1; i <= 16; i++)
            {
                PlayerModel playerModel = new PlayerModel 
                { 
                    Age = 20 + i, 
                    Height = 180 + i, 
                    Name = $"John{i}", 
                    Position = i, 
                    Surname = $"Jones{i}", 
                    UserId = 1
                };

                var response = await _client.PostAsync($"api/v1/RugbyManager/AddPlayer", new StringContent(JsonSerializer.Serialize(playerModel), Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task AddTeams()
        {
            for (int i = 1; i <= 3; i++)
            {
                TeamModel teamModel = new TeamModel
                {
                    StadiumId = 1,
                    Name = $"Team{i}",
                    Location = "Cape Town",
                    Colour = "Black/Blue",
                    UserId = 1
                };

                var response = await _client.PostAsync($"api/v1/RugbyManager/AddTeam", new StringContent(JsonSerializer.Serialize(teamModel), Encoding.UTF8, "application/json"));
                response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task AddLeague()
        {
            var payload = new LeagueModel { UserId = 1, Name = "Super 12", Location = "ZA" };
            var response = await _client.PostAsync($"api/v1/RugbyManager/AddLeague", new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task AddPlayerToTeam()
        {
            var payload = new PlayerTeamUpdateModel { UserId = 1, NewTeamId = 1, PlayerId = 1 };
            var response = await _client.PutAsync($"api/v1/RugbyManager/UpdatePlayerTeam", new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task RemovePlayerFromTeam()
        {
            var response = await _client.DeleteAsync($"api/v1/RugbyManager/DeletePlayerFromTeam/1/1");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task PlayerTransferTeams()
        {
            var payload = new PlayerTeamUpdateModel { UserId = 1, OldTeamId = 1, NewTeamId = 2, PlayerId = 1 };
            var response = await _client.PutAsync($"api/v1/RugbyManager/UpdatePlayerTeam", new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task RemovePlayerFromTeamNotFound()
        {
            var response = await _client.DeleteAsync($"api/v1/RugbyManager/DeletePlayerFromTeam/9955/1");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task AddPlayerToTeamExists()
        {
            var payload = new PlayerTeamUpdateModel { UserId = 1, NewTeamId = 1, PlayerId = 1 };
            var response = await _client.PutAsync($"api/v1/RugbyManager/UpdatePlayerTeam", new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task AddTeamToLeagueNotExists()
        {
            var response = await _client.PostAsync($"api/v1/RugbyManager/AddTeamToLeague/1/1", null);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task AddTeamToLeagueExists()
        {
            var response = await _client.PostAsync($"api/v1/RugbyManager/AddTeamToLeague/1/1", null);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task RemoveTeamFromLeagueExists()
        {
            var response = await _client.DeleteAsync($"api/v1/RugbyManager/DeleteTeamFromLeague/1/1");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task RemoveTeamFromLeagueNotExists()
        {
            var response = await _client.DeleteAsync($"api/v1/RugbyManager/DeleteTeamFromLeague/1/1");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task UpdateTeamStadium()
        {
            var payload = new TeamStadiumUpdateModel { UserId = 1, OldStadiumId = 1, NewStadiumId = 2, TeamId = 1 };
            var response = await _client.PutAsync($"api/v1/RugbyManager/UpdateTeamStadium", new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json"));
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task GenerateTournamentForMultipleTeams()
        {
            //Pick League with 2 teams or more
            var response = await _client.GetAsync($"api/v1/RugbyManager/GenerateTournamentForLeague/1");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task GenerateTournamentForSingleTeam()
        {
            //Pick League with 1 team
            var response = await _client.GetAsync($"api/v1/RugbyManager/GenerateTournamentForLeague/2");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task GetUpcomingTournamentGames()
        {
            var response = await _client.GetAsync($"api/v1/RugbyManager/GetTournamentDraw/1");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var responeJson = await response.Content.ReadAsStringAsync();
            responeJson.Should().Contain("TournamentDrawGuid");
        }

        [Fact]
        public async Task StartTournament()
        {
            var response = await _client.GetAsync($"api/v1/RugbyManager/StartTournamentForLeague/1");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetTournamentResultsForLeague()
        {
            var response = await _client.GetAsync($"api/v1/RugbyManager/GetTournamentResultsForLeague/1");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var responeJson = await response.Content.ReadAsStringAsync();
            responeJson.Should().Contain("ResultA");
        }

        [Fact]
        public async Task GetTeamDetails()
        {
            var response = await _client.GetAsync($"api/v1/RugbyManager/GetTeam/1");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var responeJson = await response.Content.ReadAsStringAsync();
            responeJson.Should().Contain("Colour");
        }

        [Fact]
        public async Task GetPlayerDetails()
        {
            var response = await _client.GetAsync($"api/v1/RugbyManager/GetPlayer/1");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var responeJson = await response.Content.ReadAsStringAsync();
            responeJson.Should().Contain("Surname");
        }

        [Fact]
        public async Task GetLeagueDetails()
        {
            var response = await _client.GetAsync($"api/v1/RugbyManager/GetLeague/1");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var responeJson = await response.Content.ReadAsStringAsync();
            responeJson.Should().Contain("Location");
        }

    }
}
