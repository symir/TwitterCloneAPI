using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterCloneAPI.Models;
using TwitterCloneAPI.Data;
using Microsoft.EntityFrameworkCore;
using TwitterCloneAPI.Models.DTO;

namespace TwitterCloneAPI.Data
{
    public class Repository
    {
        public async Task<List<TweetDTO>> GetAllRepoTweetsAsync()
        {
            List<Tweet> tweets;

            using (var db = new TwitterContext())
            {
                tweets = await db.Tweets
                    .Include(u => u.User) // fetch related User info
                    .ToListAsync();
            }

            List<TweetDTO> tweetsReturn = new List<TweetDTO>();

            foreach (Tweet tw in tweets)
            {
                UserDTO userOb = new UserDTO()
                {
                    UserId = tw.User.UserId,
                    UserName = tw.User.UserName,
                    Tweets = null // Includes User object without Tweet list to avoid recursion
                };

                TweetDTO tweetOb = new TweetDTO();

                if (tw.RetweetId != null) // checks if tweet is a reply or a retweet
                {
                    int referenceId = tw.RetweetId ?? default;
                    Tweet rTw = new Tweet();

                    using (var db = new TwitterContext())
                    {
                        rTw = await db.Tweets
                            .Include(u => u.User) // fetch related User info
                            .FirstOrDefaultAsync(x => x.TweetId == referenceId);
                    }

                    if (rTw == null) { return null; } // if tweet id doesn't exist, return null

                    UserDTO refUserOb = new UserDTO()
                    {
                        UserId = rTw.User.UserId,
                        UserName = rTw.User.UserName,
                        Tweets = null // Includes User object without Tweet list to avoid recursion
                    };

                    TweetDTO refTweetOb = new TweetDTO() {
                        TweetId = rTw.TweetId,
                        Content = rTw.Content,
                        UserId = rTw.UserId,
                        User = refUserOb
                    };

                    tweetOb.TweetId = tw.TweetId;
                    tweetOb.RetweetId = tw.RetweetId;
                    tweetOb.UserId = tw.UserId;
                    tweetOb.User = userOb;
                    tweetOb.ReferenceTweet = refTweetOb;
                    //tweetOb.ReferenceUser = refUserOb;

                }
                else
                {
                    tweetOb.TweetId = tw.TweetId;
                    tweetOb.Content = tw.Content;
                    tweetOb.UserId = tw.UserId;
                    tweetOb.User = userOb;
                };
                tweetsReturn.Add(tweetOb);
            }


            return tweetsReturn;
        }

        public async Task<TweetDTO> GetRepoTweetByIdAsync(int id)
        {
            Tweet tweet = new Tweet();
            using (var db = new TwitterContext())
            {
                tweet = await db.Tweets
                    .Include(u => u.User) // fetch related User info
                    .FirstOrDefaultAsync(x => x.TweetId == id);
            }

            if (tweet == null){return null;} // if tweet id doesn't exist, return null to controller

            UserDTO userOb = new UserDTO()
            {
                UserId = tweet.User.UserId,
                UserName = tweet.User.UserName,
                Tweets = null // Includes User object without Tweet list to avoid recursion
            };

            TweetDTO tweetOb = new TweetDTO() {
                TweetId = tweet.TweetId,
                Content = tweet.Content,
                UserId = tweet.UserId,
                User = userOb
            };

            return tweetOb;
        }
    }
}
