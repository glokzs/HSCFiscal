using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HSCFiscalRegistrar.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestKkm : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "dsd", "value2" };
        }
        
        [HttpPost]
        public async Task<string> Post([FromBody] СashRegister register)
        {
            WebRequest request = WebRequest.Create("http://52.38.152.232:8082");
            
            request.Method = "POST"; 
            
            string data = JsonConvert.SerializeObject(register, Formatting.Indented);

            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(data);
            
            request.ContentType = "application/x-www-form-urlencoded";
            
            request.ContentLength = byteArray.Length;
             
            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
 
            WebResponse response = await request.GetResponseAsync();

            string readerData = "";
            
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream ?? throw new Exception()))
                {
                    readerData += reader.ReadToEnd();
                }
            }
            response.Close();

            return readerData;
        }
    }
}