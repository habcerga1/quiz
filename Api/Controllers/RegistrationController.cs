using System.Net;
using AutoMapper;
using Core.Interfaces;
using Core.Services;
using Domain.Dto;
using Domain.Models.Base;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class RegistrationController : ControllerBase
{
    private readonly IUserService _service;
    public RegistrationController(IUserService service)
    {
        _service = service;
    }
    
    [HttpPost]
    [SwaggerResponse(HttpStatusCode.OK, typeof(DateTime), Description = "Valid request")]
    [SwaggerResponse(HttpStatusCode.BadRequest, null, Description = "Bad Request Found")]
    public async Task<IActionResult> Post(RegistrationDto user,CancellationToken cancellationToken)
    {
        return Ok(await _service.AddUserAsync(user,cancellationToken));
    }
}