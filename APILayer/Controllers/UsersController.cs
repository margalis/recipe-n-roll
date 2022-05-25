using APILayer.Models;
using AutoMapper;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        private readonly IMapper mapper;
        public UsersController(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }


        [HttpGet("{ID}")]
        public User_AccountDTO GetRecipe(int ID)
        {
            return mapper.Map<User_AccountDTO>(userRepository.GetUserInfo(ID));
        }

    }
}
