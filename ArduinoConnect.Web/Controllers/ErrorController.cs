using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ArduinoConnect.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArduinoConnect.Web.Controllers
{
    public class ErrorController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(short errorCode)
        {
            var model = new ErrorViewModel { ErrorCode = errorCode, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            switch (errorCode)
            {
                case 404:
                    return View("Error404", model);
                default:
                    return View(model);
            }
        }
    }
}
