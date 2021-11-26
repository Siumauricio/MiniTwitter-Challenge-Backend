using System;
using System.Collections.Generic;

#nullable disable

namespace Mini.Twitter.Models
{
    public partial class Like
    {
        public int IdLike { get; set; }
        public int IdTweetLike { get; set; }
        public int IdUser { get; set; }

        public virtual Twitt IdTweetLikeNavigation { get; set; }
    }
}
