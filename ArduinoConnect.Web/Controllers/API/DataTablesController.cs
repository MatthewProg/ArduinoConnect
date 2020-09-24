using ArduinoConnect.DataAccess.DataAccess;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ArduinoConnect.Web.Controllers.API
{
    [Route("api/data")]
    [ApiController]
    public class DataTablesController : ControllerBase
    {
        private readonly ArduinoConnect.DataAccess.BusinessLogic.DataTablesProcessor _dataTablesProcessor;
        private readonly IMapper _mapper;

        public DataTablesController(ISqlDataAccess sqlDataAccess, IMapper mapper)
        {
            _dataTablesProcessor = new DataAccess.BusinessLogic.DataTablesProcessor(sqlDataAccess);
            _mapper = mapper;
        }

        // GET: api/data/GetTables?token=XXX&tableId=X
        [Route("[action]")]
        [HttpGet("{token}/{tableId?}")]
        public IActionResult GetTables([FromQuery] string token, [FromQuery] int? tableId = null)
        {
            var got = _dataTablesProcessor.GetDataTables(token, tableId);

            var output = _mapper.Map<List<ResponseModels.DataTableModel>>(got);

            return Ok(output);
        }

        //POST: api/data/Add?token=XXX&tableId=X
        [Route("[action]")]
        [HttpDelete("{token}")]
        public IActionResult Add([FromQuery] string token, [FromBody] RequestModels.DataTableModel value)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            var mapped = _mapper.Map<DataAccess.Models.DataTableModel>(value);

            var added = _dataTablesProcessor.CreateDataTable(token, mapped);

            var output = _mapper.Map<ResponseModels.DataTableModel>(added);

            if (output == null)
                return BadRequest();
            else
                return Ok(output);
        }

        //DELETE: api/data/Delete?token=XXX&tableId=X&id=X
        [Route("[action]")]
        [HttpDelete("{token}/{tableId}/{id?}")]
        public IActionResult Delete([FromQuery] string token, [FromQuery] int tableId, [FromQuery] int? id = null)
        {
            var deleted = _dataTablesProcessor.DeleteDataTables(token, tableId, id);

            if (deleted >= 0)
                return Ok(deleted);
            else
                return BadRequest();
        }
    }
}
