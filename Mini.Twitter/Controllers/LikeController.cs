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
    public class LikeController :Controller{
        private readonly ILikeRepository _likeRepository;
        public LikeController(ILikeRepository likeRepository) {
            this._likeRepository = likeRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Like like) {
            await _likeRepository.SetLikeFromUser(like);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult<IEnumerable<Twitt>>> Delete([FromBody] Like like) {
            await _likeRepository.RemoveLikeFromUser(like);
            return Ok();
        }
    }
}
