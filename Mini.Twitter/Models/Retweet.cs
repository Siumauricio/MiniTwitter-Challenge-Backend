using System;
using System.Collections.Generic;

#nullable disable

namespace Mini.Twitter.Models
{
    public partial class Retweet
    {
        public int IdRetweet { get; set; }
        public int IdTweetRetweet { get; set; }
        public int IdUser { get; set; }

        public virtual Twitt IdTweetRetweetNavigation { get; set; }
    }
}
