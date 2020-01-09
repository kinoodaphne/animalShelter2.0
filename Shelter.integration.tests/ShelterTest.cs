using System;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Shelter.MVC;
using System.Net.Http;
using System.Text;

namespace Shelter.integration.tests
{
    public class ShelterTest
    {
        private const string BASE = "v1/shelters";

        private readonly TestServer _server;
        private readonly HttpClient _client;

        public ShelterTest()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async void IndexExist()
        {
            var response = await _client.GetAsync($"{BASE}/");
            response.EnsureSuccessStatusCode();

            var responsestring = await response.Content.ReadAsStringAsync();

        }

        [Fact]
        public async void IsCreated()
        {
            var content = new StringContent("{name: \"test\"}", Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"{BASE}/create", content);
            response.EnsureSuccessStatusCode();
            Assert.Equal("201", response.StatusCode.ToString());
        }

        /*public async void IsDeletedExist()
        {
            var response = await _client.GetAsync($"{BASE}/DoDelete");
            response.EnsureSuccessStatusCode();

            var responsestring = await response.Content.ReadAsStringAsync();
        }

        public async void DeletedExist()
        {
            var response = await _client.GetAsync($"{BASE}/DoDelete");
            response.EnsureSuccessStatusCode();

            var responsestring = await response.Content.ReadAsStringAsync();
        }*/

    }
}
