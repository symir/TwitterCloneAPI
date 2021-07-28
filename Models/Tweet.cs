using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterCloneAPI.Models
{
    public class Tweet
    {

        public int TweetId { get; set; }
        [MaxLength(280)]
        public string Content { get; set; }
        public int? ReplyId { get; set; } // reply and retweet Id are nullable rather than using 0 to denote empty fields to avoid (unlikely?) issues with db indexing tweets from 0
        public int? RetweetId { get; set; }
        public int LikeCounter { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
    }  
}
