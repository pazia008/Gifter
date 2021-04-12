using System;
using Microsoft.AspNetCore.Mvc;
using Gifter.Repositories;
using Gifter.Models;



namespace Gifter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {

        private readonly IUserProfileRepository _userProfileRepository;
        public UserProfileController(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userProfileRepository.GetAllUsers());
        }

    }
}
