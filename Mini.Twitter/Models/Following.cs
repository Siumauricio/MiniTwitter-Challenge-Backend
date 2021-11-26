using System;
using System.Collections.Generic;

#nullable disable

namespace Mini.Twitter.Models
{
    public partial class Following
    {
        public int IdFollowing { get; set; }
        public int FromUser { get; set; }
        public int ToUser { get; set; }

        public virtual User FromUserNavigation { get; set; }
    }
}
