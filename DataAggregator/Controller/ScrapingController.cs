using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;

namespace DataAggregator.Controllers
{
    public class ScrapingController : Controller
    {
        [HttpGet("/")]
        public async Task<IActionResult> Index()
        {
            string url = "https://www.scrapethissite.com/pages/forms/";

            var web = new HtmlWeb();
            var document = await web.LoadFromWebAsync(url);

            string FullHtml = document.DocumentNode.OuterHtml;
            string EncodedHtml = System.Web.HttpUtility.HtmlEncode(FullHtml);

            return View(EncodedHtml);
        }
    }
}