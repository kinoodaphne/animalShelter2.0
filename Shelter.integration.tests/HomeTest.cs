using System;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Shelter.MVC;
using System.Net.Http;

namespace Shelter.integration.tests
{
    public class HomeTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public HomeTest()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async void DoesIndexExist()
        {
            var response = await _client.GetAsync("/index.html");
            response.EnsureSuccessStatusCode();
            
            var responsestring = await response.Content.ReadAsStringAsync();

        }
    }
}
