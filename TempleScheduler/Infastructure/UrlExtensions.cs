using System;
using Microsoft.AspNetCore.Http;

namespace TempleScheduler.Infrastructure
{
    public static class UrlExtensions
    {
        //allows us to pass URLs
        //generates a URL that the browser will be returned to after the cart has been updated
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue ? $"{request.Path }{request.QueryString}" : request.Path.ToString();
    }
}
