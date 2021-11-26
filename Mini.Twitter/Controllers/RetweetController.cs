using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini.Twitter.Models;
using Mini.Twitter.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini.Twitter.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class RetweetController : Controller {
        private readonly IRetweetRepository _retweetRepository;

        public RetweetController(IRetweetRepository retweetRepository) {
            this._retweetRepository = retweetRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Retweet retweet) {
            await _retweetRepository.SetRetweetFromUser(retweet);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult<IEnumerable<Twitt>>> Delete([FromBody] Retweet retweet) {
            await _retweetRepository.RemoveRetweetFromUser(retweet);
            return Ok();
        }
    }
}
