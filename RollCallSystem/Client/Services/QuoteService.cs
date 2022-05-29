using RollCallSystem.Client.Controllers;
using RollCallSystem.Shared;

namespace RollCallSystem.Client.Services
{
    public class QuoteService
    {
        public static Action<List<Quote>> OnQuotesUpdated;

        private QuotesController quotesController = new QuotesController();
        private List<Quote> quotes = new List<Quote>();

        private async Task<List<Quote>> GetQuotes()
        {
            if(quotes!= default)
            {
                OnQuotesUpdated?.Invoke(quotes);
                return quotes;
            }

    
            quotes = await quotesController.GetQuotes();

            if (quotes != null)
            {
                OnQuotesUpdated?.Invoke(quotes);
                return true;
            }

            return false;

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
