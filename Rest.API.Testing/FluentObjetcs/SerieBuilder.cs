//Autor: Nathanael Silva

namespace Rest.API.Testing.FluentObjetcs
{
    public class SerieBuilder
    {
        Serie SerieData;

        public SerieBuilder CreateSerieForTest()
        {
            this.SerieData = new Serie
            {
                Name = "Dark",
                Year = "2018",
                Season = "2",
                Genre = "Drama"

            };
            return this;
        }

        public Serie Build()
        {
            return this.SerieData;
        }

        public SerieBuilder WithoutName()
        {
            this.SerieData.Name = null;
            return this;
        }

        public SerieBuilder WithName(string name)
        {
            this.SerieData.Name = name;
            return this;
        }

        public SerieBuilder WithYear(string year)
        {
            this.SerieData.Year = year;
            return this;
        }

        public SerieBuilder WithSeason(string season)
        {
            this.SerieData.Season = season;
            return this;
        }

        public SerieBuilder WithGenre(string genre)
        {
            this.SerieData.Genre = genre;
            return this;
        }

        public SerieBuilder WithoutYear()
        {
            this.SerieData.Year = null;
            return this;
        }

        public SerieBuilder WithoutSeason()
        {
            this.SerieData.Season = null;
            return this;
        }

        public SerieBuilder WithoutGenre()
        {
            this.SerieData.Genre = null;
            return this;
        }

    }
}
