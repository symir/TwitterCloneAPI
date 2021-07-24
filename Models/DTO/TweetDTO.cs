using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterCloneAPI.Models.DTO
{
    public class TweetDTO
    {

        public int TweetId { get; set; }
        public string Content { get; set; }
        public int? RetweetId { get; set; }
        public int? ReplyId { get; set; }
        public int ReplyCounter { get; set; }
        public int RetweetCounter { get; set; }
        public int LikeCounter { get; set; }

        public TweetDTO ReferenceTweet { get; set; } // Container for referenced tweet if retweet or reply

        public int UserId { get; set; }
        public UserDTO User { get; set; }
    }
}
