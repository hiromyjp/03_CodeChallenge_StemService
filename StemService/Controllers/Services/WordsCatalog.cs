using StemService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StemService.Controllers.Services
{
    public class WordsCatalog : IWordsCatalog
    {
        private HttpClient _httpClient = new HttpClient();
        private const string uri = "https://raw.githubusercontent.com/dwyl/english-words/master/words_alpha.txt";

        public WordsCatalog()
        {
            var task = LoadWords();
            task.Wait();
        }


        private async Task LoadWords()
        {
            var result = await _httpClient.GetAsync(uri);
            if (result.IsSuccessStatusCode)
            {
                
                var wordsAsString = await result.Content.ReadAsStringAsync();
                Words = wordsAsString.Split(
                    Environment.NewLine.ToCharArray(),
                    StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public string[] Words { get; private set; }

        public IList<string> Find(string prefix)
        {
            if (string.IsNullOrEmpty(prefix))
                return Words.ToList();
            return Words.Where(w => w.StartsWith(prefix)).OrderBy(w => w).ToList();
        }
    }
}
