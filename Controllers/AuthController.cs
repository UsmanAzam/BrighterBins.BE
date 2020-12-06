using BrighterBins.BE.Models;
using BrighterBins.BE.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrighterBins.BE.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IUserRepository _userRepository;
        public AuthController(ILogger<AuthController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        [HttpGet("users/check")]
        public async Task<bool> FindByNameAsync([FromQuery] string username)
        {
            return await _userRepository.FindByName(username) != null;
        }

        [HttpPost("signup")]
        public async Task<bool> CreateUserAsync([FromBody] User user)
        {
            bool userAdded = false;
            try
            {
                userAdded = await _userRepository.CreateAsync(user);
            } catch(Exception c)
            {
                _logger.LogError(c.Message);
                userAdded = false;
            }

            return userAdded;
        }
    }
}
