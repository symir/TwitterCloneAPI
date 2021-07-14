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
        public int UserId { get; set; }
        public UserDTO User { get; set; }
    }
}
