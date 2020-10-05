using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArduinoConnect.Web.Controllers
{
    [Authorize]
    public class PanelController : Controller
    {
        [Route("[controller]/[action]")]
        [Route("[controller]/Info")]
        [Route("[controller]")]
        public IActionResult Index()
        {
            var t = HttpContext.User.FindFirst(ClaimTypes.Authentication)?.Value;

            if (t == null)
                return RedirectToAction("Error", "Error", new { errorCode = 404 });

            var obj = new RequestModels.TokenModel() { Token = t };

            return View(obj);
        }
    }
}
