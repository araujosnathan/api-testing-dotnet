//Autor: Nathanael Silva

namespace Rest.API.Testing.FluentObjetcs
{
    using System;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using Newtonsoft.Json;

    public class Serie
    {
        
        public String _Id { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("year")]
        public String Year { get; set; }

        [JsonProperty("season")]
        public String Season { get; set; }

        [JsonProperty("genre")]
        public String Genre { get; set; }
    }
}
