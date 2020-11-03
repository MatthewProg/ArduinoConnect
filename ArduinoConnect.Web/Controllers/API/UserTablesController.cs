using ArduinoConnect.DataAccess.DataAccess;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ArduinoConnect.Web.Controllers.API
{
    [Route("api/tables")]
    [ApiController]
    public class UserTablesController : ControllerBase
    {
        private readonly ArduinoConnect.DataAccess.BusinessLogic.UserTablesProcessor _userTablesProcessor;
        private readonly IMapper _mapper;

        public UserTablesController(ISqlDataAccess sqlDataAccess, IMapper mapper)
        {
            _userTablesProcessor = new DataAccess.BusinessLogic.UserTablesProcessor(sqlDataAccess);
            _mapper = mapper;
        }

        // GET: api/tables/GetTables?token=XXX&tableId=X
        [Route("[action]")]
        [HttpGet("{token}/{tableId?}")]
        public IActionResult GetTables([FromQuery] string token, [FromQuery] int? tableId = null)
        {
            if (tableId == null || tableId == -1)
            {
                var list = _userTablesProcessor.GetTables(token);
                var output = _mapper.Map<List<ResponseModels.UserTableModel>>(list);

                return Ok(output);
            }
            else
            {
                var table = _userTablesProcessor.GetTable((int)tableId, token);
                var output = _mapper.Map<ResponseModels.UserTableModel>(table);

                if (output == null)
                    return BadRequest();
                else
                    return Ok(output);
            }
        }

        //POST: api/tables/Create?token=XXX
        [Route("[action]")]
        [HttpPost("{token}")]
        public IActionResult Create([FromQuery] string token, [FromBody] RequestModels.UserTableModel value)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            var mapped = _mapper.Map<DataAccess.Models.UserTableModel>(value);

            var created = _userTablesProcessor.CreateTable(mapped, token);

            var output = _mapper.Map<ResponseModels.UserTableModel>(created);
            if (output == null)
                return BadRequest();
            else
                return Created($"{Request.Scheme}://{Request.Host.Value}/api/tables/GetTables",output);
        }

        //PUT: api/tables/Update?token=XXX&tableId=X
        [Route("[action]")]
        [HttpPut("{token}/{tableId}")]
        public IActionResult Update([FromQuery] string token, [FromQuery] int tableId, [FromBody] RequestModels.UserTableModel value)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            var mapped = _mapper.Map<DataAccess.Models.UserTableModel>(value);

            var updated = _userTablesProcessor.UpdateTable(mapped, tableId, token);

            var response = _mapper.Map<ResponseModels.UserTableModel>(updated);
            if (response == null)
                return BadRequest();
            else
                return Ok(response);
        }

        //DELETE: api/tables/Delete?token=XXX&tableId=X
        [Route("[action]")]
        [HttpDelete("{token}/{tableId}")]
        public IActionResult Delete([FromQuery] string token, [FromQuery] int tableId)
        {
            if (_userTablesProcessor.DeleteTable(tableId, token))
                return Ok();
            else
                return BadRequest();
        }
    }
}
