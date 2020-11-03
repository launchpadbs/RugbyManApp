using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using RugbyManager.API;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace RugbyManager.XUnitTest
{
    public class UnitTest
    {
        private TestServer _server;
        private HttpClient _client;

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

        }
    }
}
