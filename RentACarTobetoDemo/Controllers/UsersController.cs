using Business.Abstract;
using Business.Dtos.User.Request;
using Business.Dtos.User.Response;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await userService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await userService.GetById(id));
        }

        [HttpPost]
        public async Task<AddUserResponse> Add(AddUserRequest addUser)
        {
            return await userService.Add(addUser);
        }

        [HttpDelete]
        public async Task<DeleteUserResponse> DeleteUserResponse(DeleteUserRequest deleteUser)
        {
            return await userService.Delete(deleteUser);
        }
        [HttpPut]
        public async Task<UpdateUserResponse> UpdateUserResponse(UpdateUserRequest updateUser)
        {
            return await userService.Update(updateUser);
        }
    }
}
