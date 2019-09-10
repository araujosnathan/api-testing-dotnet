//Autor: Nathanael Silva

namespace Rest.API.Testing.Tests
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Rest.API.Testing.FluentObjetcs;
    using Xunit;

    public class UpdateSerieTests : Context
    {
        [Fact]
        public async Task ShouldBePossibleToUpdateAnSerie()
        {
            SerieBuilder serieDataExpected = new SerieBuilder().CreateSerieForTest();

            var httpResponse = await this.restApi
                                         .PostAsJsonAsync(this.baseUrl, serieDataExpected.Build());

            Serie response = JsonConvert.DeserializeObject<Serie>(await httpResponse.Content.ReadAsStringAsync());

            serieDataExpected = serieDataExpected.WithName("New Serie")
                                                 .WithYear("New Year")
                                                 .WithSeason("New Season")
                                                 .WithGenre("New Genre");

           
            httpResponse = await this.restApi
                                    .PutAsJsonAsync($"{this.baseUrl}/{response._Id}", serieDataExpected.Build());

            _ = httpResponse.StatusCode
                .Should()
                .Be(HttpStatusCode.NoContent);

            _ = await this.restApi.DeleteAsync($"{this.baseUrl}/{response._Id}");


        }

        [Fact]
        public async Task ShouldNotBePossibleToUpdateAnSerie()
        {
            SerieBuilder serieData = new SerieBuilder().CreateSerieForTest()
                                                       .WithName("New Serie")
                                                       .WithYear("New Year")
                                                       .WithSeason("New Season")
                                                       .WithGenre("New Genre");


            var httpResponse = await this.restApi
                                    .PutAsJsonAsync($"{this.baseUrl}/WrongID", serieData.Build());

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
