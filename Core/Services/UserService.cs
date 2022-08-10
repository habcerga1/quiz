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
    private readonly ITokenService tokenService;
    
    public UserService(IUserRepository _db,ILogger<UserService> _logger,ITokenService _tokenService)
    {
        db = _db;
        logger = _logger;
        tokenService = _tokenService;
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

    public async Task<string> LoginAsync(LoginDto user, CancellationToken cancellationToken)
    {
        try
        {
            var result = await db.CheckUserPassword(user, user.Password, cancellationToken);
            logger.LogInformation(result.Message.Text);
                
            if (result.Succeeded)
            {
                var token = tokenService.CreateJwtSecurityToken(result.Data.User);
                logger.LogInformation($"[Login] success login for user: {user.Email} {DateTime.Now}");
                return token;
            }
        }
        catch (Exception e)
        {
            logger.LogInformation(e.Message);
            throw;
        }
        return "Bad email or password";
    }
}