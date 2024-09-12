using Data.Entities.UserManagement;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Models;
using UserManagement.Models.User;
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


        [HttpGet]
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _userService.GetAll();
        }

        [HttpGet("{userId}")]
        public async Task<GetUserByIdResponse> GetById(Guid userId)
        {
            return await _userService.GetById(userId);
        }

        [HttpPost()]
        public async Task<ActionResult<CreateUserResponse>> Create(CreateUserRequest userRequest)
        {
            var isUserCreated = await _userService.IsUserCreated(userRequest);

            if (isUserCreated)
            {
                return BadRequest("E-mail already exist : " + userRequest.Email);
            }
            return await _userService.Create(userRequest);
        }


        // PUT api/user/{userId}
        [HttpPut()]
        public async Task<IActionResult> Update(UpdateUserRequest request)
        {
            //if (userId == Guid.Empty)
            //{
            //    return BadRequest("Invalid user ID.");
            //}

            if (request == null)
            {
                return BadRequest("Request body cannot be null.");
            }

            var isUpdated = await _userService.Update(request);

            if (!isUpdated)
            {
                return NotFound("User not found.");
            }

            return NoContent(); // Indicates that the update was successful but there is no content to return
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<bool> DeleteById(Guid id)
        {
             return await _userService.DeleteById(id);
        }
    }
}
