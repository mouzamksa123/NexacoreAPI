using App.ApplicationLayer.Interface;
using App.CommonLayer.DTOModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NexaComAPI.Helpers.APIResponse;


namespace NexaComAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private   APIResponseModel apiResponse;
        private readonly IPasswordHasher _passwordHasher;


        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
            apiResponse = new();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userBusiness.GetAllAsync();
            if (users.Any()) {
                apiResponse.Status = true;
                apiResponse.Data = users;
                apiResponse.StatusCode=System.Net.HttpStatusCode.OK;
            }
            else
            {
                apiResponse.Status = false;
                apiResponse.StatusCode = System.Net.HttpStatusCode.NoContent;
            }
            return Ok(apiResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userBusiness.GetByIdAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<UserRegistrationModel>> CreateProduct([FromBody]UserRegistrationModel createUserDto)
        {
            var result = await _userBusiness.CreateAsync(createUserDto);
            if (result!=null)
                return CreatedAtAction(nameof(GetUserById), new { id = createUserDto.UserId }, createUserDto);
            return BadRequest("Product creation failed.");
        }
    }
}
