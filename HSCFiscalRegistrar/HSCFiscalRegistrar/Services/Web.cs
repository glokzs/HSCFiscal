using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.Services
{
    public static class Web
    {
        public static async Task<object> PostCallAPI(string url, object jsonObject)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                                 {
                                     var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
                                     var response = await client.PostAsync(url, content);
                                     if (response != null)
                                     {
                                         var jsonString = await response.Content.ReadAsStringAsync();
                                         return JsonConvert.DeserializeObject<object>(jsonString);
                                     }
                                 }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

    }
}