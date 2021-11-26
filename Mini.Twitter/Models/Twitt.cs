using System;
using System.Collections.Generic;

#nullable disable

namespace Mini.Twitter.Models
{
    public partial class Twitt
    {
        public Twitt()
        {
            Likes = new HashSet<Like>();
            Retweets = new HashSet<Retweet>();
        }

        public int IdTweet { get; set; }
        public int IdUser { get; set; }
        public string Twitt1 { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Retweet> Retweets { get; set; }
    }
}
