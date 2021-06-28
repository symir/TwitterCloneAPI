using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterCloneAPI.Models;
using TwitterCloneAPI.Data;

namespace TwitterCloneAPI.Data
{
    public class Repository
    {
        public List<Tweet> GetAllRepoTweets()
        {
            using (var db = new TwitterContext())
            {
                var tws = db.Tweets.ToList();
                return tws;
            }
        }

        public Tweet GetRepoTweetById(int id)
        {
            using (var db = new TwitterContext())
            {
                var tw = db.Tweets
                    .FirstOrDefault(x => x.Id == id);
                return tw;
            }
        }
    }
}
