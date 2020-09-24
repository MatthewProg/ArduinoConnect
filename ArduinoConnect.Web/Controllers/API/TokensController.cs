using ArduinoConnect.DataAccess.DataAccess;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArduinoConnect.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        private readonly ArduinoConnect.DataAccess.BusinessLogic.TokenProcessor _tokenProcessor;
        private readonly IMapper _mapper;
        public TokensController(ISqlDataAccess sqlDataAccess, IMapper mapper)
        {
            _tokenProcessor = new DataAccess.BusinessLogic.TokenProcessor(sqlDataAccess);
            _mapper = mapper;
        }

        // GET: api/Tokens/GenerateNew
        [HttpGet("GenerateNew")]
        public IActionResult GenerateNew()
        {
            var generatedToken = _tokenProcessor.GenerateNewToken();
            var output = _mapper.Map<ResponseModels.TokenModel>(generatedToken);
            return Ok(output);
        }

        //DELETE: api/Tokens/Delete?token=XXX
        [HttpDelete("{token}")]
        public IActionResult Delete([FromQuery] string token)
        {
            var output = _tokenProcessor.DeleteToken(token);
            if (output == true)
                return Ok();
            else
                return BadRequest();
        }

    }
}
