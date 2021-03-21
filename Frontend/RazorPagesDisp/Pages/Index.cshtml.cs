using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RazorPagesDisp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient client;

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
            client = _clientFactory.CreateClient("Api");
        }

        public IActionResult OnGet()
        {
            var responsetask = client.GetAsync("api/HaandvaerkerController/GetallHandvaerker");
            //responsetask.Wait();
            //https://improveandrepeat.com/2021/01/a-simple-way-to-fix-ssl_error_rx_record_too_long-in-iis-express/

            var result = responsetask.Result;
            IList haandvaerkers = null;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsStringAsync();
                readTask.Wait();

                haandvaerkers = readTask.Result.ToList();
            }
            return Page(haandvaerkers);
        }

        private IActionResult Page(IList haandvaerkers)
        {
            throw new NotImplementedException();
        }
    }
}
