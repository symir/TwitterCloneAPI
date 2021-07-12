using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterCloneAPI.Models;
using TwitterCloneAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace TwitterCloneAPI.Data
{
    public class Repository
    {
        public async Task<List<Tweet>> GetAllRepoTweetsAsync()
        {
            using (var db = new TwitterContext())
            {
                var tws = await db.Tweets.ToListAsync();
                return tws;
            }
        }

        public async Task<Tweet> GetRepoTweetByIdAsync(int id)
        {
            using (var db = new TwitterContext())
            {
                var tw = await db.Tweets
                    .FirstOrDefaultAsync(x => x.Id == id);
                return tw;
            }
        }
    }
}
