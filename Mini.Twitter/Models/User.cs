using System;
using System.Collections.Generic;

#nullable disable

namespace Mini.Twitter.Models
{
    public partial class User
    {
        public User()
        {
            FollowersNavigation = new HashSet<Follower>();
            Followings = new HashSet<Following>();
            Twitts = new HashSet<Twitt>();
        }

        public int IdUser { get; set; }
        public string Username { get; set; }
        public int Followers { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public int Following { get; set; }
        public DateTime JoinDate { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Follower> FollowersNavigation { get; set; }
        public virtual ICollection<Following> Followings { get; set; }
        public virtual ICollection<Twitt> Twitts { get; set; }
    }
}
