namespace Rest.API.Testing
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Rest.API.Testing.FluentObjetcs;
    using Xunit;

    public class CreateSerieTests
    {
        readonly HttpClient restApi = new HttpClient();
        readonly string baseUrl = "http://localhost:3000/api/series";


        [Theory]
        [MemberData(nameof(SerieData))]
        public async Task ShouldNotBePossibleToCreateSerieWithoutRequiredInformations(SerieBuilder serieData)
        {
            
            var httpResponse = await this.restApi
                                    .PostAsJsonAsync(this.baseUrl, serieData.Build());

            var response = JObject.Parse(await httpResponse.Content.ReadAsStringAsync());

            _ = httpResponse.StatusCode
                .Should()
                .Be(HttpStatusCode.BadRequest);
                
            ((string)response.SelectToken("message"))
                .Should()
                .Be("Missing required property: name/year/season or genre");

        }

        [Fact]
        public async Task ShouldBePossibleToCreateSerie()
        {

            SerieBuilder serieData = new SerieBuilder().CreateSerieForTest();

            var httpResponse = await this.restApi
                                    .PostAsJsonAsync(this.baseUrl, serieData.Build());

            _ = httpResponse.StatusCode
                .Should()
                .Be(HttpStatusCode.Created);

            Serie response = JsonConvert.DeserializeObject<Serie>(await httpResponse.Content.ReadAsStringAsync());

            response
                .Should()
                .BeEquivalentTo(serieData.Build());
          

        }

        public static IEnumerable<object[]> SerieData()
        {
           
            yield return new object[]
            {
                new SerieBuilder().CreateSerieForTest()
                                  .WithoutName()

            };
            yield return new object[]
            {
                new SerieBuilder().CreateSerieForTest()
                                  .WithoutYear()
            };
            yield return new object[]
            {
                new SerieBuilder().CreateSerieForTest()
                                  .WithoutSeason()
            };
            yield return new object[]
            {
                new SerieBuilder().CreateSerieForTest()
                                  .WithoutGenre()
            };
        }


    }
}
