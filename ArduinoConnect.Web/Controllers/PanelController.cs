using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ArduinoConnect.Web.Managers;
using AutoMapper.Configuration.Conventions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ArduinoConnect.Web.Controllers
{
    [Authorize]
    public class PanelController : Controller
    {
        private readonly IApiManager _apiManager;

        public PanelController(IApiManager apiManager)
        {
            _apiManager = apiManager;
        }

        [Route("[controller]/[action]")]
        [Route("[controller]/Info")]
        [Route("[controller]")]
        public async Task<IActionResult> Index()
        {
            var t = HttpContext.User.FindFirst(ClaimTypes.Authentication)?.Value;

            if (t == null)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });

            var userTables = await _apiManager.UserTableGet(t);
            if(userTables == null)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });
            

            ViewData["Token"] = t;
            ViewData["UserTables"] = userTables;
            ViewData["ExchangeWeb"] = await WaitingExchanges(t, 1, null);
            ViewData["ExchangeOther"] = await WaitingExchanges(t, null, null) - ((int)ViewData["ExchangeWeb"]);

            return View();
        }

        public async Task<IActionResult> UserTables()
        {
            var t = HttpContext.User.FindFirst(ClaimTypes.Authentication)?.Value;

            if (t == null)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });

            var table = await _apiManager.UserTableGet(t);
            if (table == null)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });

            ViewData["Token"] = t;
            ViewData["UserTables"] = table;

            return View();
        }


        [Route("[controller]/[action]/{id}/{raw?}/{displayData?}/{order?}/{orderCol?}/{parse?}")]
        public async Task<IActionResult> DataTable(int id, bool raw = false, int displayData = 25, string order = "ASC", string orderCol = "ID", bool parse = true)
        {
            var t = HttpContext.User.FindFirst(ClaimTypes.Authentication)?.Value;

            if (t == null)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });

            var table = await _apiManager.UserTableGet(t, id);
            if(table == null || table.Count == 0)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });

            var data = await _apiManager.DataTableGet(t, id);
            if (data == null)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });

            ViewData["Token"] = t;
            ViewData["UserTables"] = table[0];
            ViewData["Data"] = data;

            ViewData["displayData"] = displayData;
            ViewData["order"] = order;
            ViewData["orderCol"] = orderCol;
            ViewData["parse"] = parse;

            if (raw == false)
                return View();
            else
                return Json(data);
        }

        [Route("[action]")]
        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteUserTable(int id)
        {
            var t = HttpContext.User.FindFirst(ClaimTypes.Authentication)?.Value;

            if (t == null)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });

            var output = await _apiManager.UserTableDelete(t, id);

            if(output)
                return RedirectToAction("UserTables");
            else
                return RedirectToAction("Error", "Error", new { errorCode = 400 });
        }

        [Route("[action]")]
        [HttpPost("{tableId}/{id}")]
        public async Task<bool> DeleteData([FromQuery]int tableId, [FromQuery]int id)
        {
            var t = HttpContext.User.FindFirst(ClaimTypes.Authentication)?.Value;

            if (t == null)
                return false;

            var output = await _apiManager.DataTableDelete(t,tableId, id);

            return output;
        }

        public async Task<int> WaitingExchanges(string token, int? receiverId = null, string receiverDevice = null)
        {
            var output = await _apiManager.ExchangeTableNoOf(token, receiverId, receiverDevice);

            return output;
        }
    }
}
