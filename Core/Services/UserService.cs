using AutoMapper;
using Core.Interfaces;
using Domain.Common;
using Domain.Dto;
using Domain.Models.Base;
using Domain.Token;
using Infrastructure.Repositories;
using Mapster;
using Microsoft.Extensions.Logging;

namespace Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository db;
    private readonly ITokenRepository tokenDb;
    private readonly ILogger<UserService> logger;
    private readonly ITokenService tokenService;
    
    public UserService(IUserRepository _db,ILogger<UserService> _logger,ITokenService _tokenService,ITokenRepository _tokenDb)
    {
        db = _db;
        logger = _logger;
        tokenService = _tokenService;
        tokenDb = _tokenDb;
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

    public async Task<Token> LoginAsync(LoginDto user, CancellationToken cancellationToken)
    {
        try
        {
            var result = await db.CheckUserPassword(user, user.Password, cancellationToken);
            logger.LogInformation(result.Message.Text);
                
            if (result.Succeeded)
            {
                Token token = tokenService.CreateJwtSecurityTokenInstance(result.Data.User);
                tokenDb.AddRefreshToken(new RefreshToken(token.Refresh_Token, user.Email));
                logger.LogInformation($"[Login] success login for user: {user.Email} {DateTime.Now}");
                return token;
            }
        }
        catch (Exception e)
        {
            logger.LogInformation(e.Message);
            throw;
        }

        return null;
    }

    public async Task<Token> RefreshTokenAsync(Token token, CancellationToken cancellationToken)
    {
        var principal = tokenService.GetPrincipalFromExpiredToken(token.Access_Token);
        var email = principal.Identity?.Name;
        var savedRefreshToken = tokenDb.GetRefreshToken(email, token.Refresh_Token);
        
        if (savedRefreshToken.Refresh_Token != token.Refresh_Token)
        {
            return null;
        }
        
        var result = tokenService.GenerateRefreshToken(await db.GetUserAsync(email,cancellationToken));

        if (result == null)
        {
            return null;
        }
        tokenDb.DeleteUserRefreshTokens(email,token.Refresh_Token);
        tokenDb.AddRefreshToken(new RefreshToken(token.Refresh_Token, email));
        return result;
    }
}