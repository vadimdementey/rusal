using Microsoft.AspNet.Mvc;
using Rusal.Dto;
using Rusal.Interfaces;
using Rusal.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Route("users")]
    public class UserController : Controller
    {
        private IUserContext     userContext;
        private IUserRepository repositoryContext;

        public UserController(IUserContext userContext, IUserRepository repositoryContext)
        {
            this.userContext       = userContext;
            this.repositoryContext = repositoryContext;
        }



        [HttpGet]
        public UserDto[] GetUsers()
        {
            return repositoryContext.GetUsers().Select(x => new UserDto(x)).ToArray();
        }

        [HttpGet("logged")]
        public UserDto GetLogged()
        {
            return new UserDto(userContext.Logged);
        }
    }
}
