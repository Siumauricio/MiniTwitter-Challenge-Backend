using Mini.Twitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mini.Twitter.Repository {
    public class UserRepository : IUserRepository {

        private readonly MiniTwitterContext _twitterDbContext;
        public UserRepository(MiniTwitterContext context) {
            this._twitterDbContext = context;
        }
        public async Task<bool> AddUserAsync(User user) {
            var result = _twitterDbContext.Users.FirstOrDefault(u => u.Username == user.Username);
            if (result!=null) {
                return false;
            }
            user.Followers = 0;
            user.Following = 0;
            user.JoinDate = DateTime.Now;
            user.Password = GetSHA256(user.Password);
            await _twitterDbContext.Users.AddAsync(user);
            await _twitterDbContext.SaveChangesAsync();
            return true;
        }
        public static string GetSHA256(string str) {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public async Task<User> GetUserByIdAsync(int id) {
            return await _twitterDbContext.Users.FirstOrDefaultAsync(u => u.IdUser == id);
        }
    }
}
