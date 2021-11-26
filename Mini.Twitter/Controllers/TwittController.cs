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
    public class TwittController : Controller {
        private readonly ITwittRepository _twittRepository;
        public TwittController(ITwittRepository  twittRepository) {
            this._twittRepository = twittRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Twitt twittForCreation) {
            await _twittRepository.AddTweetAsync(twittForCreation);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Twitt>>> Get([FromQuery] int idUser) {
            var result = await _twittRepository.GetTweetsByUserAsync(idUser);
            if (result == null) {
                return Ok();
            }
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<TweetDto>>> GetAll() {
            var result = await _twittRepository.GetAllTweets();
            return Ok(result);
        }

    }
}
