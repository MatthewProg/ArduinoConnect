using ArduinoConnect.DataAccess.DataAccess;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ArduinoConnect.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiversController : ControllerBase
    {
        private readonly ArduinoConnect.DataAccess.BusinessLogic.ReceiverProcessor _receiverProcessor;
        private readonly IMapper _mapper;
        public ReceiversController(ISqlDataAccess sqlDataAccess, IMapper mapper)
        {
            _receiverProcessor = new DataAccess.BusinessLogic.ReceiverProcessor(sqlDataAccess);
            _mapper = mapper;
        }

        // GET: api/Receivers/GetReceivers?receiverId=X&description=XXX
        [Route("[action]")]
        [HttpGet("{receiverId?}/{description?}")]
        public IActionResult GetReceivers([FromQuery] int? receiverId = null, [FromQuery] string description = null)
        {
            var list = _receiverProcessor.GetReceivers(receiverId, description);
            var output = _mapper.Map<List<ResponseModels.ReceiverModel>>(list);

            return Ok(output);
        }
    }
}
