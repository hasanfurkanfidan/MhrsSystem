using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetResponseOnlyResult(Core.Utilities.Results.IResult result)
        {
            return result.Success ? Ok() : BadRequest(result.Message);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult GetResponseOnlyResultData<T>(IDataResult<T> result)
        {
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }
    }
}
