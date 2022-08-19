using System.Net;
using Core.Services;
using Domain.Common;
using Domain.Models.Base;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class ServerController : ControllerBase
{
    private readonly IUserRepository _userDb;

    public ServerController(BaseMsSqlContext context,UserManager<User> userManager,RoleManager<IdentityRole> roleManager)
    {
        _userDb = new UserRepository(context, userManager,roleManager);
    }


    /// <summary>
    /// Check server status
    /// </summary>
    /// <remarks>
    /// Simple request: GET http://localhost:5038/api/v1/server
    /// </remarks>
    /// <returns>Return date time</returns>
    
    [AuthorizeAttributeService(RoleEnum = Roles.User | Roles.Subscriber | Roles.Admin)]
    [HttpGet()]
    [SwaggerResponse(HttpStatusCode.OK, typeof(DateTime), Description = "Valid request")]
    [SwaggerResponse(HttpStatusCode.BadRequest, null, Description = "Bad request Found")]
    public async Task<IActionResult> Get()
    {
        return await Task.Run(()=> Ok(DateTime.Now));
    }
}