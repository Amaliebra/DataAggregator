using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;

namespace DataAggregator.Controllers
{
    [ApiController]
    [Route("api/scrape")]
    public class ScrapingController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetScrapedContent()
        {
            string url = "https://www.scrapingcourse.com/ecommerce/";

            var web = new HtmlWeb();
            var document = await web.LoadFromWebAsync(url);

            string FullHtml = document.DocumentNode.OuterHtml;

            return Content(FullHtml);
        }
    }
}