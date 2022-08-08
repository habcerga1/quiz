using System.Net;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class ServerController : ControllerBase
{
    /// <summary>
    /// Check server status
    /// </summary>
    /// <remarks>
    /// Simple request: GET http://localhost:5038/api/v1/server
    /// </remarks>>
    /// <returns>Return date time</returns>
    [HttpGet()]
    [SwaggerResponse(HttpStatusCode.OK, typeof(DateTime), Description = "Valid request")]
    [SwaggerResponse(HttpStatusCode.BadRequest, null, Description = "Badrequest Found")]
    public async Task<IActionResult> Get()
    {
        return await Task.Run(()=> Ok(DateTime.Now));
    }
}