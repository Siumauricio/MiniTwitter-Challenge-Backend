using Microsoft.AspNetCore.Mvc;
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
    }
}
