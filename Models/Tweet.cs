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
        public string Content { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
