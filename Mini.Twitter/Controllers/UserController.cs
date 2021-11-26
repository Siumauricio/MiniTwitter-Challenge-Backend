using Microsoft.AspNetCore.Mvc;
using Mini.Twitter.ModelDto;
using Mini.Twitter.Models;
using Mini.Twitter.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini.Twitter.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class UserController :Controller {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) {
            this._userRepository = userRepository;
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Post([FromBody] User userForCreation) {

            await _userRepository.AddUserAsync(userForCreation);
            return Ok(new UserDto {
                IdUser = userForCreation.IdUser,
                Username = userForCreation.Username
            });
        }

        [HttpGet]
        public async Task<ActionResult<User>> Get([FromQuery] int id) {
            var result = await _userRepository.GetUserByIdAsync(id);
            if (result == null) {
                return Ok();
            }
            return Ok(result);
        }
    }
}
