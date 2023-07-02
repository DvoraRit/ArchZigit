using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ZigitHub.Api.Handlers;

namespace ZigitHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BaseController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Ok("Test");
        }
        protected IActionResult SuccessfulResponse<T>(T data)
        {
            return Ok(ApiResponseHandler.Success(data));
        }

        protected IActionResult FailedResponse(HttpStatusCode status, string errorMessage = null)
        {
            switch(status)
            {
                case HttpStatusCode.NotFound:
                    return NotFound(ApiResponseHandler.Failure(status, errorMessage));
                default:
                    return BadRequest(ApiResponseHandler.Failure(HttpStatusCode.BadRequest, errorMessage));
            }

            
        }
    }
}
