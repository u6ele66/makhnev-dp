using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Valuator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IStorage _storage;

        public IndexModel(ILogger<IndexModel> logger, IStorage storage)
        {
            _logger = logger;
            _storage = storage;
        }

        public void OnGet()
        {

        }

        private double RankCalculator(string text)
        {
            return ((double)text.Count(ch => !Char.IsLetter(ch)) / text.Length);
        }

        private int SimilarityCalculator(string text)
        {
            var keys = _storage.GetAllKeys();
            return keys.Any(item => item.Substring(0, 5) == "TEXT-" && _storage.GetDataByKey(item) == text) ? 1 : 0;
        }

        public IActionResult OnPost(string text)
        {
            _logger.LogDebug(text);

            string id = Guid.NewGuid().ToString();

            string rankKey = "RANK-" + id;
            var rank = RankCalculator(text);
            _storage.SaveData(rankKey, rank.ToString());

            string similarityKey = "SIMILARITY-" + id;
            var similarity = SimilarityCalculator(text);
            _storage.SaveData(similarityKey, similarity.ToString());

            string textKey = "TEXT-" + id;
            _storage.SaveData(textKey, text);

            return Redirect($"summary?id={id}");
        }
    }
}
