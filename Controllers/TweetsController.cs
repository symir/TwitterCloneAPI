using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterCloneAPI.Models;
using TwitterCloneAPI.Data;

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
        public async Task< List<Tweet>> GetAllTweets() 
        {
            return await  _repository.GetAllRepoTweets(true).ConfigureAwait(false);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Tweet> GetTweetById(int id)
        {
            return await _repository.GetRepoTweetById(id).ConfigureAwait(false);
        }
    }
}
