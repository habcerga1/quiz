using AutoMapper;
using Core.Interfaces;
using Domain.Dto;
using Infrastructure.Repositories;

namespace Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository db;
    private readonly IMapper _mapper;

    public UserService(IUserRepository _db)
    {
        db = _db;
    }

    public async Task<bool> AddUserAsync(RegistrationDto user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}