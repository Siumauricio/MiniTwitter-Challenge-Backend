using Mini.Twitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini.Twitter.Repository {
    public interface ITwittRepository {
        Task AddTweetAsync(Twitt twitt);
    }
}
