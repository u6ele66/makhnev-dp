using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Valuator.Pages
{
    public class SummaryModel : PageModel
    {
        private readonly ILogger<SummaryModel> _logger;

        public SummaryModel(ILogger<SummaryModel> logger)
        {
            _logger = logger;
        }

        public double Rank { get; set; }

        public void OnGet(string id)
        {
            _logger.LogDebug(id);

            //TODO: получить из БД оценку и записать в свойство Rank
        }
    }
}
