using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZigitHub.Application.Interfaces;
using ZigitHub.Application.ViewModels;
using ZigitHub.Domain.Core.Commands;

namespace ZigitHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            //inject the IUserService
            _userService = userService;
        }
        [HttpGet]
        //public Task <IActionResult> Get()
        //{
        //    //command to get all users

        //}
        [HttpPost]
        public IActionResult Post([FromBody] UserViewModel userViewModel)
        {
            _userService.Create(userViewModel);
            return Ok(userViewModel);

        }
        
    }
}
