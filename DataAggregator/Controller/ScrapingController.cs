using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;

namespace DataAggregator.Controllers
{
    public class ScrapingController : Controller
    {
        [HttpGet("/")]
        public async Task<IActionResult> Index()
        {
            string url = "https://www.scrapingcourse.com/ecommerce/";

            var web = new HtmlWeb();
            var document = await web.LoadFromWebAsync(url);

            string FullHtml = document.DocumentNode.OuterHtml;

            return Content(FullHtml, "text/html");
        }
    }
}