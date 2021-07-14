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
