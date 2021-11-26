using Mini.Twitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Mini.Twitter.Repository {
    public class LoginRepository : ILoginRepository {

        private readonly MiniTwitterContext _twitterDbContext;
        public LoginRepository(MiniTwitterContext context) {
            this._twitterDbContext = context;
        }
        public async Task<User> Login(LoginModel loginModel) {
            string passEncrypted = GetSHA256(loginModel.password);
            var result = await _twitterDbContext.Users.FirstOrDefaultAsync(user => (user.Email == loginModel.Username || user.Username == loginModel.Username) && user.Password == passEncrypted);
            if (result != null) {
                return result;
            }
            return null;
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


    }
}
