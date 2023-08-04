using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Filters
{
    public class ClientLanguageResourceFilter : Attribute, IAsyncResourceFilter
    {
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            var browserLang = context.HttpContext.Request.Headers["Accept-Language"].
                ToString().
                Split(";").FirstOrDefault()?.
                Split(",").FirstOrDefault();

            var ukLang = "uk-UA";
            var ruLang = "ru-RU";
            var key = "Langs";

            string defoultLang = "Eng";

            if (!string.IsNullOrEmpty(browserLang))
            {
                if (browserLang.Contains(ukLang))
                {
                    defoultLang = "Ukr";
                }
                else if (browserLang.Contains(ruLang))
                {
                    defoultLang = "Ukrainian";
                }
            }

            context.HttpContext.Request.Headers.Add(key, defoultLang);

            await next();
        }
    }
}
