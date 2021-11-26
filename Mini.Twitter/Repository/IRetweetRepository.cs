using Mini.Twitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini.Twitter.Repository {
    public interface IRetweetRepository {
        Task SetRetweetFromUser(Retweet retweet);
        Task RemoveRetweetFromUser(Retweet retweet);
    }
}
