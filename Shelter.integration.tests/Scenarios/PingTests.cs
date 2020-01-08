using Shelter.integration.tests.Fixtures;

namespace Shelter.integration.tests.Scenarios{

    public class PingTests{
        private readonly TestContext _sut;

        public PingTests(){

            _sut = new TestContext();
        }

        [Fact]
        public async Task PingReturnsOkResponse()
        {
            var response = await _sut.Client.GetAsync("/Ping");

            response.Statuscode.Should().Be(HttpStatusCode.OK);
        //Given
        
        //When
        
        //Then
        }
    }
}