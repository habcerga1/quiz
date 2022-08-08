using System.Net;
using Domain.Models.Base;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Base;
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

    public ServerController(BaseMsSqlContext context,UserManager<User> userManager)
    {
        _userDb = new UserRepository(context, userManager);
    }


    /// <summary>
    /// Check server status
    /// </summary>
    /// <remarks>
    /// Simple request: GET http://localhost:5038/api/v1/server
    /// </remarks>
    /// <returns>Return date time</returns>
    [HttpGet()]
    [SwaggerResponse(HttpStatusCode.OK, typeof(DateTime), Description = "Valid request")]
    [SwaggerResponse(HttpStatusCode.BadRequest, null, Description = "Badrequest Found")]
    public async Task<IActionResult> Get()
    {
        User user = new User()
        {
            UserName = "asdassd",
            Email = "asdasd@gmail.com",
            FullName = "asdasdasdasd"
        };
        await _userDb.AddUserAsync(user, "a4byn!!fdBADiad", new CancellationToken());
        return await Task.Run(()=> Ok(DateTime.Now));
    }
}