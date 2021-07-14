using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterCloneAPI.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string UserName { get; set; }

        public List<Tweet> Tweets { get; set; }
    }
}
