using System;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;

namespace Models.Services
{
    public static class HttpService
    {
        private const string Url = "http://52.38.152.232:8082";

        [HttpPost]
        public static async Task<dynamic> Post([FromBody] object anyObject)
        {
            var x = await Url.PostJsonAsync(anyObject).ReceiveJson();
            return x;
        }

        [HttpGet]
        public static async Task<dynamic> Get()
        {
            return await Url.GetJsonAsync();
        }
    }
}