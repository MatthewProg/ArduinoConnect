﻿using ArduinoConnect.Web.Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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


        //===========================================//
        // - - - - - - - - - INDEX - - - - - - - - - //
        //===========================================//
        [Route("[controller]/[action]")]
        [Route("[controller]/Info")]
        [Route("[controller]")]
        public async Task<IActionResult> Index()
        {
            var t = HttpContext.User.FindFirst(ClaimTypes.Authentication)?.Value;

            if(t == null)
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


        //===========================================//
        // - - - - - - - USER TABLES - - - - - - - - //
        //===========================================//
        [Route("[controller]/Tables")]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> UserTables()
        {
            var t = HttpContext.User.FindFirst(ClaimTypes.Authentication)?.Value;

            if(t == null)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });

            var table = await _apiManager.UserTableGet(t);
            if(table == null)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });

            ViewData["Token"] = t;
            ViewData["UserTables"] = table;

            return View();
        }

        [Route("[controller]/[action]")]
        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteUserTable([FromForm] int id)
        {
            var t = HttpContext.User.FindFirst(ClaimTypes.Authentication)?.Value;

            if(t == null)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });

            var output = await _apiManager.UserTableDelete(t, id);

            if(output)
                return RedirectToAction("UserTables");
            else
                return RedirectToAction("Error", "Error", new { errorCode = 400 });
        }

        [Route("[controller]/[action]")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> UserTableUpdate([FromForm] RequestModels.UserTableModel model)
        {
            if(ModelState.IsValid == false)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });

            var t = HttpContext.User.FindFirst(ClaimTypes.Authentication)?.Value;

            if(t == null)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });

            var output = await _apiManager.UserTableUpdate(t, model);

            if(output == null)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });
            else
                return RedirectToAction("UserTables");
        }

        [Route("[controller]/[action]")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> UserTableAdd([FromForm] RequestModels.UserTableModel model)
        {
            if(ModelState.IsValid == false)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });

            try
            {
                var obj = JToken.Parse(model.TableSchema);
            }
            catch
            {
                return RedirectToAction("Error", "Error", new { errorCode = 400 });
            }

            var t = HttpContext.User.FindFirst(ClaimTypes.Authentication)?.Value;

            if(t == null)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });

            var result = await _apiManager.UserTableCreate(t, model);
            if(result == null)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });
            else
                return RedirectToAction("UserTables");
        }

        [Route("[controller]/Table/{act}/{id?}")]
        [HttpGet("{act}/{id?}")]
        public async Task<IActionResult> AddEditUserTable(string act, int? id = null)
        {
            switch (act.ToUpper())
            {
                case "ADD":
                    return View("UserTableEditAdd", null);
                case "EDIT":
                    if(id == null)
                        return RedirectToAction("Error", "Error", new { errorCode = 400 });

                    var t = HttpContext.User.FindFirst(ClaimTypes.Authentication)?.Value;
                    if(t == null)
                        return RedirectToAction("Error", "Error", new { errorCode = 400 });

                    var modelList = await _apiManager.UserTableGet(t, id);
                    if(modelList == null || modelList.Count == 0)
                        return RedirectToAction("Error", "Error", new { errorCode = 400 });

                    var model = new RequestModels.UserTableModel()
                    {
                        TableID = modelList[0].TableID,
                        TableName = modelList[0].TableName,
                        TableDescription = modelList[0].TableDescription,
                        TableSchema = modelList[0].TableSchema
                    };
                    return View("UserTableEditAdd", model);
                default:
                    return RedirectToAction("Error", "Error", new { errorCode = 404 });
            }
        }


        //===========================================//
        //- - - - - - - - DATA TABLE - - - - - - - - //
        //===========================================//
        [Route("[controller]/[action]/{id}")]
        public async Task<IActionResult> DataTable(int id)
        {
            var t = HttpContext.User.FindFirst(ClaimTypes.Authentication)?.Value;

            if(t == null)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });

            var table = await _apiManager.UserTableGet(t, id);
            if(table == null || table.Count == 0)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });

            ViewData["UserTables"] = table[0];

            return View();
        }

        [Route("[controller]/[action]")]
        [HttpGet("{id}/{raw?}/{displayData?}/{page?}/{order?}/{orderCol?}/{parse?}")]
        public async Task<IActionResult> DataTableTable(int id, bool raw = false, int displayData = 25, int page = 0, string order = "DESC", string orderCol = "ID", bool parse = true)
        {
            var t = HttpContext.User.FindFirst(ClaimTypes.Authentication)?.Value;

            if(t == null)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });

            var data = await _apiManager.DataTableOffsetGet(t, id, page * displayData, displayData);
            if(data == null)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });

            var table = await _apiManager.UserTableGet(t, id);
            if(table == null || table.Count == 0)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });

            var lastPage = await _apiManager.DataTableGetNoOf(t, table[0].TableID);

            if(order == "ASC")
                data.Reverse();

            ViewData["UserTables"] = table[0];
            ViewData["Data"] = data;

            ViewData["displayData"] = displayData;
            ViewData["order"] = order;
            ViewData["orderCol"] = orderCol;
            ViewData["parse"] = parse;
            ViewData["page"] = page;
            ViewData["lastPage"] = (lastPage ?? 0) / displayData;

            if(raw == false)
                return PartialView("_DataTableTablePartial", this.ViewData);
            else
                return Json(data);
        }

        [Route("[controller]/[action]")]
        [HttpPost("{tableId}/{id}")]
        public async Task<bool> DeleteData([FromQuery] int tableId, [FromQuery] int id)
        {
            var t = HttpContext.User.FindFirst(ClaimTypes.Authentication)?.Value;

            if(t == null)
                return false;

            var output = await _apiManager.DataTableDelete(t, tableId, id);

            return output;
        }

        [Route("[controller]/[action]/{id}")]
        public async Task<IActionResult> DataTableDownload(int id)
        {
            var t = HttpContext.User.FindFirst(ClaimTypes.Authentication)?.Value;
            if(t == null)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });

            var data = await _apiManager.DataTableGet(t, id);
            if(data == null)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });

            string json = JsonConvert.SerializeObject(data);
            return File(Encoding.UTF8.GetBytes(json), "application/json", "data.json");
        }


        //===========================================//
        //  - - - - - - - - EXCHANGE - - - - - - - - //
        //===========================================//
        [Route("[controller]/[action]")]
        public IActionResult Exchange()
        {
            if(TempData["MessageSent"] != null)
                ViewData["MessageSent"] = TempData["MessageSent"];
            else
                ViewData["MessageSent"] = false;

            return View();
        }

        [Route("[controller]/[action]")]
        [HttpPost("{action}/{receiverId?}/{receiverDevice?}")]
        public async Task<IActionResult> ExchangeProcess([FromQuery] string action, [FromQuery] int? receiverID = null, [FromQuery] string receiverDevice = null)
        {
            var errorReturn = PartialView("_ExchangeTablePartial", new List<ResponseModels.ExchangeTableModel>() { new ResponseModels.ExchangeTableModel() { ID = -1, ReceiverDevice = "ERROR", ReceiverID = -1, Command = "ERROR", AddTime = new DateTime(1, 1, 1, 0, 0, 0) } });

            var t = HttpContext.User.FindFirst(ClaimTypes.Authentication)?.Value;

            if(t == null || string.IsNullOrWhiteSpace(action))
                return errorReturn;

            switch (action)
            {
                case "get-newest":
                    var o1 = await _apiManager.ExchangeTableNewest(t, receiverID, receiverDevice);
                    if(o1 == null)
                        return PartialView("_ExchangeTablePartial", new List<ResponseModels.ExchangeTableModel>());
                    else
                        return PartialView("_ExchangeTablePartial", new List<ResponseModels.ExchangeTableModel>() { o1 });
                case "get-oldest":
                    var o2 = await _apiManager.ExchangeTableOldest(t, receiverID, receiverDevice);
                    if(o2 == null)
                        return PartialView("_ExchangeTablePartial", new List<ResponseModels.ExchangeTableModel>());
                    else
                        return PartialView("_ExchangeTablePartial", new List<ResponseModels.ExchangeTableModel>() { o2 });
                case "get-all":
                    var o3 = await _apiManager.ExchangeTableAll(t, receiverID, receiverDevice);
                    if(o3 == null)
                        return PartialView("_ExchangeTablePartial", new List<ResponseModels.ExchangeTableModel>());
                    else
                        return PartialView("_ExchangeTablePartial", o3);
                case "del-all":
                    var o4 = await _apiManager.ExchangeTableDelete(t, receiverID, receiverDevice);
                    return Json(o4);
                default:
                    return errorReturn;
            }
        }

        [Route("[controller]/[action]")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExchangeNew([FromForm] RequestModels.ExchangeTableModel model)
        {
            if(ModelState.IsValid == false)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });

            var t = HttpContext.User.FindFirst(ClaimTypes.Authentication)?.Value;

            if(t == null)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });

            var response = await _apiManager.ExchangeTableNew(t, model);

            if(response)
            {
                TempData["MessageSent"] = true;
                return RedirectToAction("Exchange");
            }
            else
                return RedirectToAction("Error", "Error", new { errorCode = 400 });
        }

        [Route("[controller]/[action]")]
        public async Task<IActionResult> ExchangeInfo()
        {
            var t = HttpContext.User.FindFirst(ClaimTypes.Authentication)?.Value;

            if(t == null)
                return RedirectToAction("Error", "Error", new { errorCode = 400 });

            ViewData["ExchangeWeb"] = await WaitingExchanges(t, 1, null);
            ViewData["ExchangeOther"] = await WaitingExchanges(t, null, null) - ((int)ViewData["ExchangeWeb"]);

            return PartialView("_ExchangeInfoPartial", this.ViewData);
        }

        [Route("[controller]/[action]/{token?}/{receiverId?}/{receiverDevice?}")]
        public async Task<int?> WaitingExchanges(string token = null, int? receiverId = null, string receiverDevice = null)
        {
            if(string.IsNullOrWhiteSpace(token))
            {
                token = HttpContext.User.FindFirst(ClaimTypes.Authentication)?.Value;

                if(token == null)
                    return -1;
            }

            var output = await _apiManager.ExchangeTableNoOf(token, receiverId, receiverDevice);

            return output;
        }
    }
}
