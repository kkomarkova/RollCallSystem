using Newtonsoft.Json;
using RollCallSystem.Shared;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace RollCallSystem.Client.Controllers
{
	public class QuotesController
	{
        private const string Url = "https://type.fit/api/quotes";
        private HttpClient client;

        public QuotesController()
        {
            client = new HttpClient();
        }

        public async Task<List<Quote>> GetQuotes()
        {
            List<Quote> quotes = new List<Quote>();

            HttpResponseMessage response;

            using (var requestMessage =
            new HttpRequestMessage(HttpMethod.Get, Url))
            {
                response = await client.SendAsync(requestMessage);
            }

            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            quotes = JsonConvert.DeserializeObject<List<Quote>>(content);
            

            return quotes;
        }
    }
}

