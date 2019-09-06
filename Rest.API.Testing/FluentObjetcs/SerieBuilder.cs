using System;
namespace Rest.API.Testing.FluentObjetcs
{
    public class SerieBuilder
    {
        Serie SerieData;

        public SerieBuilder CreateSerieForTest()
        {
            this.SerieData = new Serie
            {
                name = "Dark",
                year = "2018",
                season = "2",
                genre = "Drama"

            };
            return this;
        }

        public Serie Build()
        {
            return this.SerieData;
        }

        public SerieBuilder WithoutName()
        {
            this.SerieData.name = null;
            return this;
        }

        public SerieBuilder WithoutYear()
        {
            this.SerieData.year = null;
            return this;
        }

        public SerieBuilder WithoutSeason()
        {
            this.SerieData.season = null;
            return this;
        }

        public SerieBuilder WithoutGenre()
        {
            this.SerieData.genre = null;
            return this;
        }

    }
}
