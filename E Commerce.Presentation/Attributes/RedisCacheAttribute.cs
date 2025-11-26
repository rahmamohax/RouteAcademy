using E_Commerce.Service_Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Text;


namespace E_Commerce.Presentation.Attributes
{
    internal class RedisCacheAttribute : ActionFilterAttribute
    {
        private readonly int _durationInMin;

        public RedisCacheAttribute(int durationInMin =5)
        {
            _durationInMin = durationInMin;
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //Get Cache service fron DI(Dependency Injection) Container
            var cacheService = context.HttpContext.RequestServices.GetRequiredService<ICacheService>();

            //Create cache key
            var cacheKey = CreateCacheKey(context.HttpContext.Request);

            //Check if chace data exists
            var val = await cacheService.GetAsync(cacheKey);

            //if exist => return cached data
            if(val is not null)
            {
                context.Result = new ContentResult()
                {
                    Content = val,
                    ContentType = "application/Json",
                    StatusCode = StatusCodes.Status200OK
                };
                return;
            }

            //if not => execute endpoint and store it in cache
            var executedContext = await next.Invoke();
            if(executedContext.Result is OkObjectResult result)
            {
                await cacheService.SetAsync(cacheKey, result.Value!, TimeSpan.FromMinutes(_durationInMin));
            }

        }
        private string CreateCacheKey(HttpRequest request)
        {
            StringBuilder key = new StringBuilder();
            key.Append(request.Path); //api/Products
            foreach (var item in request.Query.OrderBy(x => x.Key))
                key.Append($"|{item.Key}-{item.Value}"); //api/Products|typeId-2|brandId-5
            return key.ToString();
        }
    }
}
