using RollCallSystem.Client.Controllers;
using RollCallSystem.Shared;

namespace RollCallSystem.Client.Services
{
    public class QuoteService
    {
        private QuotesController quotesController = new QuotesController();
        private List<Quote> quotes = new List<Quote>();

        private async Task<List<Quote>> GetQuotes()
        {
            if(quotes!= default)
            {
                return quotes;
            }

    
            quotes = await quotesController.GetQuotes();

            if (quotes != null)
            {
                return quotes;
            }

            return default;

        }

        public async Task<Quote> GetRandomQuote()
        {
            if (quotes == default)
            {
                await GetQuotes();
            }
            Random random = new Random();
            return quotes[random.Next(quotes.Count)];

        }
    }
}
