using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewApiTest.Context;
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
    public class RoleController : ControllerBase
    {
        private readonly FarmAppContext _farmAppContext;
        public RoleController(FarmAppContext farmAppContext)
        {
            _farmAppContext = farmAppContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            List<Role> roles = await _farmAppContext.Roles.Where(x => x.IsDeleted == false).ToListAsync(cancellationToken);

            if (!roles.Any())
                return BadRequest("Users not found!");

            if (!roles.Any())
                return BadRequest("Users not found!");

            return Ok(roles);
        }

        [HttpPost]
        public async Task<ActionResult<Role>> PostRoleAsync(Role role, CancellationToken cancellationToken = default)
        {
            if (role == null)
                return BadRequest("Тут пусто");
            /// Здесь костыль
            _farmAppContext.Roles.Add(role);
            await _farmAppContext.SaveChangesAsync(cancellationToken);

            return Ok(role);
        }
    }
}
