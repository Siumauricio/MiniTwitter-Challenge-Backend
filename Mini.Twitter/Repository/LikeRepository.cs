using Mini.Twitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mini.Twitter.Repository {
    public class LikeRepository : ILikeRepository {
        private readonly MiniTwitterContext _twitterDbContext;
        public LikeRepository(MiniTwitterContext context) {
            this._twitterDbContext = context;
        }
        public async Task SetLikeFromUser(Like like) {
            var result = await _twitterDbContext.Likes.FirstOrDefaultAsync(response => response.IdTweetLike == like.IdTweetLike && response.IdUser == like.IdUser);
            if (result !=null) {
                return;
            }
            await _twitterDbContext.Likes.AddAsync(like);
            await _twitterDbContext.SaveChangesAsync();
        }

        public async Task RemoveLikeFromUser(Like like) {
            var result = await _twitterDbContext.Likes.FirstOrDefaultAsync(response => response.IdTweetLike == like.IdTweetLike && response.IdUser == like.IdUser);
            if (result == null) {
                return;
            }
             _twitterDbContext.Likes.Remove(result);
            await _twitterDbContext.SaveChangesAsync();
        }
    }
}
