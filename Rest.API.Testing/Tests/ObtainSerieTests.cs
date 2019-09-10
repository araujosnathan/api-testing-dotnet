//Autor: Nathanael Silva

namespace Rest.API.Testing.Tests
{
    using System.Net;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Rest.API.Testing.FluentObjetcs;
    using Xunit;

    public class ObtainSerieTests : Context
    {
     
        [Fact]
        public async Task ShouldBePossibleToObtainAnSerie()
        {
            var id = "77e0373c6f35bd826f47e977";
            SerieBuilder serieData = new SerieBuilder().CreateSerieForTest()
                                                       .WithName("The Flash")
                                                       .WithYear("2014")
                                                       .WithSeason("4")
                                                       .WithGenre("action");

            var httpResponse = await this.restApi
                                    .GetAsync($"{this.baseUrl}/{id}");

            _ = httpResponse.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            Serie response = JsonConvert.DeserializeObject<Serie>(await httpResponse.Content.ReadAsStringAsync());

            response
                .Should()
                .BeEquivalentTo(serieData.Build(), options => options.Excluding(serie => serie._Id));

        }

        [Fact]
        public async Task ShouldNotBePossibleToObtainAnSerie()
        { 

            var httpResponse = await this.restApi
                                    .GetAsync($"{this.baseUrl}/WrongID");

            _ = httpResponse.StatusCode
                .Should()
                .Be(HttpStatusCode.NotFound);

            var response = JObject.Parse(await httpResponse.Content.ReadAsStringAsync());

            ((string)response.SelectToken("message"))
                .Should()
                .Be("Not Found");

        }



    }

    
}
