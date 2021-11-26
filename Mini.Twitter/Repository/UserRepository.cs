using Mini.Twitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini.Twitter.Repository {
    public class UserRepository : IUserRepository {
        private readonly MiniTwitterContext _twitterDbContext;
        public UserRepository(MiniTwitterContext context) {
            this._twitterDbContext = context;
        }
        public async Task AddUserAsync(User user) {
            var result = _twitterDbContext.Users.FirstOrDefault(u => u.Username == user.Username);
            if (result!=null) {
                return;
            }
            user.Followers = 0;
            user.Following = 0;
            user.JoinDate = DateTime.Now;
            await _twitterDbContext.Users.AddAsync(user);
            await _twitterDbContext.SaveChangesAsync();
        }
    }
}
