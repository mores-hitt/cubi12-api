using Microsoft.AspNetCore.Authorization;

namespace Cubitwelve.Src.Controllers
{
    [Authorize]
    public class BaseAuthApiController : BaseApiController { }
}