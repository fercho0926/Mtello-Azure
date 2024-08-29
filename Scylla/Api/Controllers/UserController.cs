using Data.Entities.UserManagement;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Models;
using UserManagement.Services;


namespace Api.Controllers
{

    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        //[Authorize]
        [HttpGet]
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userService.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<User> GetById(Guid id)
        {
            return await _userService.GetById(id);
        }

        //[Authorize]
        //[HttpPost("Create")]
        [HttpPost()]
        public async Task<ActionResult<UserDTO>> Create(CreateUserRequest userRequest)
        {

            var isUserCreated = await _userService.IsUserCreated(userRequest);

            if (isUserCreated)
            {
                return BadRequest("E-mail already exist : " + userRequest.Email);
            }


            return await _userService.Create(userRequest);

        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
