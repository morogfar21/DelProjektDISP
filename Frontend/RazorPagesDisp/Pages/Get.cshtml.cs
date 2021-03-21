using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RazorPagesDisp.Pages
{
    public class GetModel : PageModel
    {
        private readonly ILogger<GetModel> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient client;

        public GetModel(ILogger<GetModel> logger)
        {
            _logger = logger;

        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            //var responsetask = clie

            //if (Customer == null)
            //{
            //    return RedirectToPage("./Index");
            //}

            return Page();
        }
    }
}
