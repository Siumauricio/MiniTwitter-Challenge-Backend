using Mini.Twitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mini.Twitter.Repository {
    public class RetweetRepository : IRetweetRepository {
        private readonly MiniTwitterContext _twitterDbContext;
        public RetweetRepository(MiniTwitterContext context) {
            this._twitterDbContext = context;
        }
        public async Task SetRetweetFromUser(Retweet retweet) {
            var result = await _twitterDbContext.Retweets.FirstOrDefaultAsync(response => response.IdTweetRetweet == retweet.IdTweetRetweet && response.IdUser == retweet.IdUser);
            if (result != null) {
                return;
            }
            await _twitterDbContext.Retweets.AddAsync(retweet);
            await _twitterDbContext.SaveChangesAsync();
        }

        public async Task RemoveRetweetFromUser(Retweet retweet) {
            var result = await _twitterDbContext.Retweets.FirstOrDefaultAsync(response => response.IdTweetRetweet == retweet.IdTweetRetweet && response.IdUser == retweet.IdUser);
            if (result == null) {
                return;
            }
            _twitterDbContext.Retweets.Remove(result);
            await _twitterDbContext.SaveChangesAsync();
        }
    }
}
