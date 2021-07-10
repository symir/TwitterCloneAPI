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
        public List<Tweet> GetAllTweets() 
        {
            return _repository.GetAllRepoTweets();
        }

        [HttpGet]
        [Route("{id}")]
        public Tweet GetTweetById(int id)
        {
            return _repository.GetRepoTweetById(id);
        }
    }
}
