using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuoteGeneratorCore
{
    public class Simon
    {
        private List<Quote> quotes = new List<Quote>();

        //https://blog.stephencleary.com/2013/01/async-oop-2-constructors.html
        private Simon() { }

        private async Task<Simon> Initialize()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://type.fit/api/quotes");
            quotes = JsonConvert.DeserializeObject<List<Quote>>(json);
            return this;
        }

        public static Task<Simon> CreateAsync()
        {
            var simon = new Simon();
            return simon.Initialize();
        }

        public Quote Says()
        {
            var max = quotes.Count - 1;
            var idx = new Random().Next(0, Math.Max(0, max));
            var quote = quotes.DefaultIfEmpty(Quote.Empty()).ElementAt(idx);
            return quote;
        }
    }
}
