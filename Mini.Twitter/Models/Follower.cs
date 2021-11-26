using System;
using System.Collections.Generic;

#nullable disable

namespace Mini.Twitter.Models
{
    public partial class Follower
    {
        public int IdFollower { get; set; }
        public int FromUser { get; set; }
        public int ToUser { get; set; }

        public virtual User ToUserNavigation { get; set; }
    }
}
