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
        public async Task<List<Tweet>> GetAllRepoTweets(bool includeUser,int i = 0)
        {
            using (var db = new TwitterContext())
            {
                 var tws = (includeUser) ? await db.Tweets.Include(e => e.User).ToListAsync().ConfigureAwait(false)
                    : await db.Tweets.ToListAsync().ConfigureAwait(false);
                return tws;
            }
        }

        public async Task<Tweet> GetRepoTweetById(int id)
        {
            using (var db = new TwitterContext())
            {
                var tw = await db.Tweets
                    .FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
                return tw;
            }
        }
    }
}
