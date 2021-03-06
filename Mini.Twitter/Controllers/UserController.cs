using Microsoft.AspNetCore.Authorization;
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

            var result = await _userRepository.AddUserAsync(userForCreation);
            if (!result) {
                return null;
            }
            return Ok(new UserDto {
                IdUser = userForCreation.IdUser,
                Username = userForCreation.Username
            });
        }

        [HttpGet]
        //[Authorize(Roles ="GetUser")]
        public async Task<ActionResult<User>> Get([FromQuery] int id) {
            var result = await _userRepository.GetUserByIdAsync(id);
            if (result == null) {
                return Ok();
            }
            return Ok(new User {
                Username = result.Username,
                IdUser=result.IdUser,
                Followers =  result.Followers, 
                Following=result.Following, 
                Description=result.Description, 
                JoinDate = result.JoinDate,
                Email = result.Email,
            });
        }
    }
}
