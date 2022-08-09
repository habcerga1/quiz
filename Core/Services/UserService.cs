using AutoMapper;
using Core.Interfaces;
using Domain.Dto;
using Domain.Models.Base;
using Infrastructure.Repositories;
using Mapster;
using Microsoft.Extensions.Logging;

namespace Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository db;
    private readonly ILogger<UserService> logger;
    
    public UserService(IUserRepository _db,ILogger<UserService> _logger)
    {
        db = _db;
        logger = _logger;
    }

    public async Task<bool> AddUserAsync(RegistrationDto user, CancellationToken cancellationToken)
    {
        var employeeEntity = user.Adapt<User>();
        return true;
    }
}