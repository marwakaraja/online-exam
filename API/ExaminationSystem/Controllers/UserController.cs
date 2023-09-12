using McqExaminationSystem.DataTransferObjectsManagers.UserDtosManager;
using McqExaminationSystem.DataTransferObjectsManagers.UserDtosManager.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace McqExaminationSystem.Controllers
{
    [Route("api/user")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserDtosManager userDtosManager;

        public UserController(IUserDtosManager userDtosManager)
        {
            this.userDtosManager = userDtosManager;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var users = userDtosManager.GetAllDtos();
            return users.IsNullOrEmpty() ? NotFound() : Ok(users);
        }

        [HttpGet("{userId}")]
        public IActionResult GetById(int userId)
        {
            var user = userDtosManager.GetDtoById(userId);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost("insert")]
        public IActionResult Insert(UserDto userDto)
        {
            return userDtosManager.InsertEntityUsingDto(userDto) ? Ok() : BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(UserDto userDto)
        {
            return userDtosManager.UpdateEntityUsingDto(userDto) ? Ok() : BadRequest();
        }

        [HttpDelete("delete/{userId}")]
        public IActionResult Delete(int userId)
        {
            return userDtosManager.DeleteEntity(userId) ? Ok() : BadRequest();    
        }
    }
}
