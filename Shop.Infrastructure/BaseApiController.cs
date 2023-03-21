using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data;
using System.Net.Http.Json;
using System.Security.Claims;

namespace Shop.Infrastructure
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : Controller
    {
        protected readonly HttpClient client = new HttpClient();
        
        public override void OnActionExecuting(ActionExecutingContext ctx)
        {
            base.OnActionExecuting(ctx);
            ViewData["Authorization"] = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last(); ;
        }
    }
}
