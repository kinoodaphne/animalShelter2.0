using System;
using System.Collections.Generic;
using System.Text;

namespace Shelter.integration.tests.Fixtures
{
    class TestContext{

        public HTTPClient Client { get; set;}
        private TestServer _server;

        public TestContext(){
            SetupClient();
        }   

        private void SetupClient(){
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            Client = _server.CreateClient(); 
        }
    }
}