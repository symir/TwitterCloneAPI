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
                    .OrderByDescending(t => t.TweetId) // deliver list in descending order based on id (newest first)
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

                // creates data transfer object for the tweet being iterated
                TweetDTO tweetOb = new TweetDTO() { 
                    TweetId = tw.TweetId,
                    Content = tw.Content,
                    RetweetId = tw.RetweetId,
                    ReplyId = tw.ReplyId,
                    UserId = tw.UserId,
                    User = userOb 
                };


                // checks if tweet contains a reference to another tweet (retweetId or replyId), and adds the referenced tweet as ReferenceTweet. If both fields are populated for some reason,
                // retweet takes precedence and replyid is ignored.

                if (tw.RetweetId != null || tw.ReplyId != null) 
                {

                    // checks whether this is a retweet or reply, and converts the referenced Id from nullable to regular int
                    int referenceId = (tw.RetweetId != null) ? tw.RetweetId ?? default : tw.ReplyId ?? default;

                    Tweet rTw = new Tweet();
                    using (var db = new TwitterContext()) // fetches the referenced tweet
                    {
                        rTw = await db.Tweets
                            .Include(u => u.User) // fetch related User info
                            .FirstOrDefaultAsync(x => x.TweetId == referenceId);
                    }

                    if (rTw == null) { return null; } // if referenced tweet id doesn't exist, return null

                    UserDTO refUserOb = new UserDTO()
                    {
                        UserId = rTw.User.UserId,
                        UserName = rTw.User.UserName,
                        Tweets = null // User tweet list nulled to avoid recursion
                    };

                    TweetDTO refTweetOb = new TweetDTO() // creates data transfer object for the referenced tweet
                    {
                        TweetId = rTw.TweetId,
                        Content = rTw.Content,
                        UserId = rTw.UserId,
                        User = refUserOb
                    };

                    tweetOb.ReferenceTweet = refTweetOb; // adds referenced tweet's DTO to parent tweet DTO

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
