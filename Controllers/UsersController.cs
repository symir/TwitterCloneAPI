using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterCloneAPI.Data;
using TwitterCloneAPI.Models.DTO;

namespace TwitterCloneAPI.Controllers
{
    [Route("api/user")]
    [Controller]
    public class UserController : ControllerBase
    {
        private readonly Repository _repository;

        public UserController()
        {
            _repository = new Repository();
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetAllUsersAsync()
        {
            try
            {
                return Ok(await _repository.GetAllRepoUsersAsync());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TweetDTO>> GetUserByIdAsync(int id)
        {
            try
            {
                return Ok(await _repository.GetRepoUserByIdAsync(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}