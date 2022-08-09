using AutoMapper;
using Core.Interfaces;
using Domain.Common;
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

    public async Task<ServiceResult> AddUserAsync(RegistrationDto user, CancellationToken cancellationToken)
    {
        try
        {
            var item = user.Adapt<User>();
            var result = await db.AddUserAsync(item, user.Password, cancellationToken);
            logger.LogInformation(result.Message.Text);
            return result;
        }
        catch (Exception ex)
        {
            logger.LogDebug(ex.Message);
            throw ex;
        }
    }
}