using Filters.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{
    [ClientLanguageResourceFilter]

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index([FromHeader(Name="Langs")]string ?langs)
        {
            var result = "Hello world!";
            var valueLang = langs;

            var ukLang = "Ukr";
            var ruLang = "Ukrainian";

            if (!string.IsNullOrEmpty(valueLang))
            {
                if (valueLang.Equals(ukLang))
                {
                    result = "Привіт, світ!";
                }
                else if (valueLang.Equals(ruLang))
                {
                    result = "Привет, мир!";
                }
            }

            return Content(result);
        }
    }
}