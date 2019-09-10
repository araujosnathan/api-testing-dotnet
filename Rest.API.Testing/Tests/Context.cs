//Autor: Nathanael Silva

namespace Rest.API.Testing.Tests
{
    using System;
    using System.Net.Http;

    public class Context
    {
        public HttpClient restApi = new HttpClient();
        public string baseUrl = "http://localhost:3000/api/series";

    }
}
