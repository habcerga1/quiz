using AutoMapper;
using Core.Interfaces;
using Domain.Common;
using Domain.Dto;
using Domain.Models.Base;
using Domain.Models.Excaptions;
using Domain.Token;
using Infrastructure.Repositories;
using Mapster;
using Microsoft.Extensions.Logging;

namespace Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userDb;
    private readonly ITokenRepository _tokenDb;
    private readonly ILogger<UserService> _logger;
    private readonly ITokenService _tokenService;
    
    public UserService(IUserRepository db,ILogger<UserService> logger,ITokenService tokenService,ITokenRepository tokenDb)
    {
        _userDb = db;
        _logger = logger;
        _tokenService = tokenService;
        _tokenDb = tokenDb;
    }

    public async Task<ServiceResult> AddUserAsync(RegistrationDto user, CancellationToken cancellationToken)
    {
        try
        {
            var item = user.Adapt<User>();
            var result = await _userDb.AddUserAsync(item, user.Password, cancellationToken);
            _logger.LogInformation(result.Message.Text);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogDebug(ex.Message);
            throw;
        }
    }

    public async Task<ServiceResult<Token>> LoginAsync(LoginDto user, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _userDb.CheckUserPasswordAsync(user, user.Password, cancellationToken);
            if (result.Succeeded)
            {
                _logger.LogInformation(result.Message.Text);
                var role = await _userDb.GetUserRole(result.Data.User.Email,cancellationToken);
                ServiceResult<Token> token = _tokenService.CreateJwtSecurityTokenInstance(result.Data.User,role);
                _tokenDb.AddRefreshToken(new RefreshToken(token.Data.Refresh_Token, user.Email));
                _logger.LogInformation($"[Login] Success login for user: {user.Email} {DateTime.Now}");
                return token;
            }
            else
            {
                _logger.LogInformation(result.Message.Text);
            }
        }
        catch (Exception e)
        {
            _logger.LogCritical(e.Message);
            throw;
        }

        return null;
    }

    public async Task<ServiceResult<Token>> RefreshTokenAsync(Token token, CancellationToken cancellationToken)
    {
        var principal = _tokenService.GetPrincipalFromExpiredToken(token.Access_Token);
        var email = principal.Data.Claims.FirstOrDefault().Value;
        var savedRefreshToken = _tokenDb.GetRefreshToken(email, token.Refresh_Token);
        
        if (savedRefreshToken.Refresh_Token != token.Refresh_Token)
        {
            return null;
        }

        ServiceResult<Token> result;
        try
        {
            var user = await _userDb.GetUserAsync(email, cancellationToken);
            var role = await _userDb.GetUserRole(email,cancellationToken);
            result = _tokenService.GenerateRefreshToken(user.Data, role);
        }
        catch (Exception e)
        {
            _logger.LogCritical(e.Message);
            throw;
        }

        if (result == null)
        {
            return ServiceResult.Failed(Result.DefaultError) as ServiceResult<Token>;
        }

        try
        {
            _tokenDb.DeleteUserRefreshTokens(email,token.Refresh_Token);
            _tokenDb.AddRefreshToken(new RefreshToken(result.Data.Refresh_Token, email));
            _logger.LogInformation($"[Token Refresh] success toking refreshing for user: {email} {DateTime.Now}");
        }
        catch (Exception e)
        {
            _logger.LogCritical(e.Message);
            throw;
        }
        return result;
    }
}