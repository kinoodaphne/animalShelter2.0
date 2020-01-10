using System;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Shelter.MVC;
using System.Net.Http;
using System.Text;
using Shelter.Shared;

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
        /*
        [Fact]
        public async void IsCreated()
        {
            var content = new StringContent("{name: \"test\",animals:[]}", Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{BASE}/create", content);
            response.EnsureSuccessStatusCode();
            Assert.Equal("201", response.StatusCode.ToString());
        }

        [Fact]
        public async void IsDeleted()
        {
            var response = await _client.DeleteAsync($"{BASE}/1/animals/1");
            response.EnsureSuccessStatusCode();
            var responsestring = await response.Content.ReadAsStringAsync();
        }
        */
        [Fact]

        public async void CreatedCat()
        {
            //kat maken 
            var sendCat = new Cat() { Name = "kitty", IsChecked = true, Declawed = false, Race = "street", ShelterId = 1 };
            //newtonsoft = convert de kat van object naar string 
            var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(sendCat), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{BASE}/1/cat", content);
            response.EnsureSuccessStatusCode();
            //json leest als eerste string terug
            var json = await response.Content.ReadAsStringAsync();
            //word nieuw object gemaakt vanuit json bestand
            var cat = Newtonsoft.Json.JsonConvert.DeserializeObject<Cat>(json);
            //
            Assert.Equal(sendCat.Name , cat.Name);
        }

        [Fact]

        public async void CreatedDog()
        {
            //hond maken 
            var sendDog = new Dog() { Name = "doggy", IsChecked = true, Barker = false, Race = "street", ShelterId = 1 };
            //newtonsoft = convert de hond van object naar string 
            var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(sendDog), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{BASE}/1/dog", content);
            response.EnsureSuccessStatusCode();
            //json leest als eerste string terug
            var json = await response.Content.ReadAsStringAsync();
            //word nieuw object gemaakt vanuit json bestand
            var dog = Newtonsoft.Json.JsonConvert.DeserializeObject<Dog>(json);
            //
            Assert.Equal(sendDog.Name, dog.Name);
        }

        [Fact]

        public async void CreatedOther()
        {
            //kat maken 
            var sendOther = new Other() { Name = "maxxy", IsChecked = true, Description = "descriptiontest", Race = "street", KidFriendly=true, ShelterId = 1 };
            //newtonsoft = convert de kat van object naar string 
            var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(sendOther), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{BASE}/1/other", content);
            response.EnsureSuccessStatusCode();
            //json leest als eerste string terug
            var json = await response.Content.ReadAsStringAsync();
            //word nieuw object gemaakt vanuit json bestand
            var other = Newtonsoft.Json.JsonConvert.DeserializeObject<Other>(json);
            //
            Assert.Equal(sendOther.Name, other.Name);
        }

    }
}
