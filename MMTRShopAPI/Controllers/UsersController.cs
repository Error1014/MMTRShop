using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;
using MMTRShop.Service.Interface;

namespace MMTRShopAPI.Controllers
{

    public class UsersController : BaseApiController
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetUsersPage([FromQuery] BaseFilter filter)
        {
            var users = await _userService.GetPageUser(filter);
            return users;
        }
        [HttpGet("{id}")]
        public async Task<UserDTO> GetUser(Guid id)
        {
            var user = await _userService.GetUser(id);
            return user;
        }

        [HttpPost]
        public async Task<IActionResult> PostUser(UserDTO userDTO)
        {
            await _userService.AddUser(userDTO);
            return Ok(userDTO);
        }

        [HttpPut]
        public async Task<IActionResult> PutUser(UserDTO userDTO)
        {
            await _userService.Update(userDTO);
            return Ok(userDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userService.RemoveUser(id);
            return Ok($"Пользователь с id={id} успешно удалён"); ;
        }
    }
}
