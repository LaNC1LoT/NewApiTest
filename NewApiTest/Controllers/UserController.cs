using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewApiTest.Context;
using NewApiTest.Dto;
using NewApiTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NewApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly FarmAppContext _farmAppContext;
        public UserController(FarmAppContext farmAppContext)
        {
            _farmAppContext = farmAppContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRole>>> GetAll(CancellationToken cancellationToken = default)
        {
            List<UserRole> users = await _farmAppContext.Users.Include(i => i.Role)
                .Select(s => new UserRole 
                {
                    Id = s.Id,
                    Login = s.Login,
                    RoleName = s.Role.RoleName
                   
                }).ToListAsync(cancellationToken);

            if (!users.Any())
                return BadRequest("Users not found!");

            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetAll(int id)
        {
            User user = _farmAppContext.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return BadRequest($"Пользователь не найден с таким id = {id}");

            return Ok(user);
        }
    }
}
