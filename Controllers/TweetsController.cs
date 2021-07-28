using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterCloneAPI.Models;
using TwitterCloneAPI.Data;
using TwitterCloneAPI.Models.DTO;

namespace TwitterCloneAPI.Controllers
{

    [Route("api/tweets")]
    [Controller]
    public class TweetsController : ControllerBase
    {
        private readonly Repository _repository;

        public TweetsController()
        {
            _repository = new Repository();
        }
        [HttpGet]
        public async Task<ActionResult<List<TweetDTO>>> GetAllTweets() 
        {
            try
            {
                return Ok(await _repository.GetAllRepoTweetsAsync());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("post")]
        public async Task<ActionResult> PostTweetAsync([FromBody]Tweet tweet)
        {

            if (tweet == null)
            {
                return StatusCode(400); // Catches null exceptions from mangled post requests
            } 
            else if (tweet.Content == "RFC 2324")
            {
                return StatusCode(418); // This line is the lynchpin of the entire system. 
            }

            Tweet newTweet = new Tweet()
            {
                UserId = tweet.UserId
            };

            // determine if retweet, reply, or regular tweet, and only pass permissible values
            if(tweet.RetweetId != null)
            {
                newTweet.RetweetId = tweet.RetweetId;
            } 
            else if (tweet.ReplyId != null)
            {
                newTweet.ReplyId = tweet.ReplyId;
                newTweet.Content = tweet.Content;
            } 
            else
            {
                newTweet.Content = tweet.Content;
            }

            try
            {
                if (ModelState.IsValid) // check if it matches model requiremenets
                {
                    await _repository.CreateTweetAsync(newTweet);
                    return Ok();

                } else
                {
                    return StatusCode(412);
                }
            } 
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TweetDTO>> GetTweetByIdAsync(int id)
        {
            try 
            {
                return Ok(await _repository.GetRepoTweetByIdAsync(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
