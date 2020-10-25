using ArduinoConnect.DataAccess.DataAccess;
using ArduinoConnect.Web.Managers;
using ArduinoConnect.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ArduinoConnect.Web.Controllers
{
    public class StartController : Controller
    {
        private readonly ILogger<StartController> _logger;
        private readonly string _apiUrl;
        private readonly IApiManager _apiManager;

        public StartController(ILogger<StartController> logger, IConfiguration configuration, IApiManager apiManager)
        {
            _logger = logger;
            _apiUrl = configuration.GetValue<string>("ApiUrl");
            _apiManager = apiManager;
        }

        public async Task<IActionResult> Index()
        {
            var t = HttpContext.User.FindFirst(ClaimTypes.Authentication)?.Value;

            if(t != null)
            {
                var res = await VerifyToken(t) as JsonResult;
                bool good = false;
                bool ok = bool.TryParse(res.Value.ToString(), out good);
                if (good && ok)
                    return RedirectToAction("Index", "Panel");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GenerateToken()
        {
            var obj = await _apiManager.TokenGenerateNew();

            if (obj == null)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });

            return await Login(obj.Token);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string token)
        {
            var res = await VerifyToken(token) as JsonResult;
            bool good = false;
            bool ok = bool.TryParse(res.Value.ToString(), out good);
            if (ok && good)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Authentication, token)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                return RedirectToAction("Index", "Panel");
            }
            else
                return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Start");
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> VerifyToken(string token)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(_apiUrl + "exchange/GetNoOfExchange");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(_apiUrl + $"exchange/GetNoOfExchange?token={token}");
                if (response.IsSuccessStatusCode)
                    return Json(true);
                else
                    return Json("Token doesn't exist!");
            }
        }
    }
}
