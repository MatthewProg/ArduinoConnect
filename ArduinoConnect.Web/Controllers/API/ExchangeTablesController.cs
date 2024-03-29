﻿using ArduinoConnect.DataAccess.DataAccess;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ArduinoConnect.Web.Controllers.API
{
    [Route("api/exchange")]
    [ApiController]
    public class ExchangeTablesController : ControllerBase
    {
        private readonly ArduinoConnect.DataAccess.BusinessLogic.ExchangeTablesProcessor _exchangeTablesProcessor;
        private readonly IMapper _mapper;

        public ExchangeTablesController(ISqlDataAccess sqlDataAccess, IMapper mapper)
        {
            _exchangeTablesProcessor = new DataAccess.BusinessLogic.ExchangeTablesProcessor(sqlDataAccess);
            _mapper = mapper;
        }

        // GET: api/exchange/GetAllExchange?token=XXX&receiverDevice=XXX&receiverID=X
        [Route("[action]")]
        [HttpGet("{token}/{receiverDevice?}/{receiverID?}")]
        public IActionResult GetAllExchange([FromQuery] string token, [FromQuery] string receiverDevice = null, [FromQuery] int? receiverID = null)
        {
            var list = _exchangeTablesProcessor.GetAllExchange(token, receiverDevice, receiverID);
            var output = _mapper.Map<List<ResponseModels.ExchangeTableModel>>(list);

            return Ok(output);
        }


        // GET: api/exchange/GetOldestExchange?token=XXX&receiverDevice=XXX&receiverID=X
        [Route("[action]")]
        [HttpGet("{token}/{receiverDevice?}/{receiverID?}")]
        public IActionResult GetOldestExchange([FromQuery] string token, [FromQuery] string receiverDevice = null, [FromQuery] int? receiverID = null)
        {
            var obj = _exchangeTablesProcessor.GetOldestExchange(token, receiverDevice, receiverID);
            var output = _mapper.Map<ResponseModels.ExchangeTableModel>(obj);

            return Ok(output);
        }


        // GET: api/exchange/GetNewestExchange?token=XXX&receiverDevice=XXX&receiverID=X
        [Route("[action]")]
        [HttpGet("{token}/{receiverDevice?}/{receiverID?}")]
        public IActionResult GetNewestExchange([FromQuery] string token, [FromQuery] string receiverDevice = null, [FromQuery] int? receiverID = null)
        {
            var obj = _exchangeTablesProcessor.GetNewestExchange(token, receiverDevice, receiverID);
            var output = _mapper.Map<ResponseModels.ExchangeTableModel>(obj);

            return Ok(output);
        }


        // GET: api/exchange/GetNoOfExchange?token=XXX&receiverDevice=XXX&receiverID=X
        [Route("[action]")]
        [HttpGet("{token}/{receiverDevice?}/{receiverID?}")]
        public IActionResult GetNoOfExchange([FromQuery] string token, [FromQuery] string receiverDevice = null, [FromQuery] int? receiverID = null)
        {
            var output = _exchangeTablesProcessor.GetNoOfExchange(token, receiverDevice, receiverID);

            if(output == -1)
                return BadRequest();
            else
                return Ok(output);
        }

        //DELETE: api/exchange/Delete?token=XXX&receiverDevice=XXX&receiverID=X
        [HttpDelete("{token}/{receiverDevice?}/{receiverID?}")]
        public IActionResult Delete([FromQuery] string token, [FromQuery] string receiverDevice = null, [FromQuery] int? receiverID = null)
        {
            var output = _exchangeTablesProcessor.ClearExchange(token, receiverDevice, receiverID);
            if(output == -1)
                return BadRequest();
            else
                return Ok(output);
        }

        // POST: api/exchange/Post?token=XXX
        [HttpPost("{token}")]
        public IActionResult Post([FromQuery] string token, [FromBody] RequestModels.ExchangeTableModel value)
        {
            if(ModelState.IsValid == false)
                return BadRequest();

            var obj = _mapper.Map<DataAccess.Models.ExchangeTableModel>(value);

            var action = _exchangeTablesProcessor.CreateExchange(token, obj);

            var output = _mapper.Map<ResponseModels.ExchangeTableModel>(action);
            if(output == null)
                return BadRequest();
            else
                return Created($"{Request.Scheme}://{Request.Host.Value}/api/exchange", output);
        }
    }
}
