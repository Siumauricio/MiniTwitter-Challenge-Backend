using Mini.Twitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini.Twitter.Repository {
    public class TwittRepository : ITwittRepository {
        private readonly MiniTwitterContext _twitterDbContext;
        public TwittRepository(MiniTwitterContext context) {
            this._twitterDbContext = context;
        }
        public async Task AddTweetAsync(Twitt twitt) {
            await _twitterDbContext.Twitts.AddAsync(twitt);
            await _twitterDbContext.SaveChangesAsync();
        }
    }
}
