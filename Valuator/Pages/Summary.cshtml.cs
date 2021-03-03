using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Valuator.Pages
{
    public class SummaryModel : PageModel
    {
        private readonly ILogger<SummaryModel> _logger;
        private readonly IStorage _storage;

        public SummaryModel(ILogger<SummaryModel> logger, IStorage storage)
        {
            _logger = logger;
            _storage = storage;
        }

        public double Rank { get; set; }
        public double Similarity { get; set; }

        public void OnGet(string id)
        {
            _logger.LogDebug(id);

            //TODO: проинициализировать свойства Rank и Similarity сохранёнными в БД значениями
            Rank = Convert.ToDouble(_storage.GetDataByKey($"RANK-{id}"));
            Similarity = Convert.ToDouble(_storage.GetDataByKey($"SIMILARITY-{id}"));
        }
    }
}
