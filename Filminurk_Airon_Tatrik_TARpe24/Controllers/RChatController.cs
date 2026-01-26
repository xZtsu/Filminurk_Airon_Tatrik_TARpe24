using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Filminurk.Controllers
{
    [Authorize]
    public class RChatController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}