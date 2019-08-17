using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HSCFiscalRegistrar.DTO.RequestForHSC.Initialization;
using HSCFiscalRegistrar.RequestModels;
using HSCFiscalRegistrar.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using MediaTypeHeaderValue = System.Net.Http.Headers.MediaTypeHeaderValue;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestKkm : Controller
    {
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            string url = "https://restcountries.eu/rest/v2";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            string json = JsonConvert.SerializeObject(responseBody, Formatting.Indented);

            return Json(json);
        }

        [HttpPost]
        public async Task<string> Post([FromBody] InitializationOperationRequest kkm)
        {
            try
            {
                var client = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(kkm));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync("http://52.38.152.232:8082", content);
            
                var value = await response.Content.ReadAsStringAsync();

                return value;
            }
            catch (Exception e)
            {
                return e.Message;
            }
    
        }
    }
}