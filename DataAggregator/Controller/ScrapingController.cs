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
            //default link: https://www.scrapingcourse.com/ecommerce/
            var web = new HtmlWeb();
            var document = await web.LoadFromWebAsync(url);

            var ImageNode = document.DocumentNode.SelectNodes("//img");
            if (ImageNode != null)
            {
                var random = new Random();
                int ImageCounter = 0;
                foreach (var node in ImageNode)
                {
                    string newImageUrl;
                    if (ImageCounter < 20)
                    {
                        newImageUrl = $"https://picsum.photos/300?random={random.Next(1000, 9999)}";
                        ImageCounter++;
                    }
                    else
                    {
                        newImageUrl = "https://picsum.photos/300";
                    }

                    node.SetAttributeValue("src", newImageUrl);
                    node.Attributes.Remove("srcset");
                    node.Attributes.Remove("sizes");
                }
            }

            var h1Nodes = document.DocumentNode.SelectNodes("//a[@class='site-branding site-title']");
            if (h1Nodes != null)
            {
                foreach (var node in h1Nodes)
                {
                    node.InnerHtml = "No, i didnt make this webpage!";
                }
            }

            string FullHtml = document.DocumentNode.OuterHtml;

            return Content(FullHtml);
        }
    }
}