using Xunit;
using Api;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;

namespace Test
{
    public class WeatherForecastControllerTests : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        public HttpClient Client { get; }

        public WeatherForecastControllerTests(WebApplicationFactory<Api.Startup> fixture)
        {
            Client = fixture.CreateClient();
        }

        [Fact]
        public async Task Get_Should_Retrieve_Forecast()
        {
            var response = await Client.GetAsync("api/weatherforecast/get");
            Assert.True(response.StatusCode == HttpStatusCode.OK);
            var forecast = JsonConvert.DeserializeObject<WeatherForecast[]>(await response.Content.ReadAsStringAsync());
            Assert.True(forecast.Length == 5);
        }
    }
}
