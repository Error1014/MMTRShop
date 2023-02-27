using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace MMTRShopAPI.Controllers
{
[Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        public Guid UserId
        {
            get {
                var claimsIdentity = this.User.Identity as ClaimsIdentity;
                var userId = claimsIdentity.FindFirst(ClaimTypes.Name)?.Value;
                return Guid.Parse(userId);
            }
        }
    }
}
