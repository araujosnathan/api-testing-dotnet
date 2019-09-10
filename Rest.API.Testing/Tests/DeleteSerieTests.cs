//Autor: Nathanael Silva

namespace Rest.API.Testing.Tests
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Rest.API.Testing.FluentObjetcs;
    using Xunit;

    public class DeleteSerieTests : Context
    {
        [Fact]
        public async Task ShouldBePossibleToDeleteAnSerie()
        {
            SerieBuilder serieDataExpected = new SerieBuilder().CreateSerieForTest();

            var httpResponse = await this.restApi
                                         .PostAsJsonAsync(this.baseUrl, serieDataExpected.Build());

            Serie response = JsonConvert.DeserializeObject<Serie>(await httpResponse.Content.ReadAsStringAsync());


            httpResponse = await this.restApi
                                    .DeleteAsync($"{this.baseUrl}/{response._Id}");

            _ = httpResponse.StatusCode
                .Should()
                .Be(HttpStatusCode.NoContent);

        }

        [Fact]
        public async Task ShouldNotBePossibleToDeleteAnSerie()
        {
           

            var httpResponse = await this.restApi
                                    .DeleteAsync($"{this.baseUrl}/WrongID");

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
