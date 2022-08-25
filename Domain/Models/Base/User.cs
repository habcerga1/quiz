using Domain.Interfaces.Base;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models.Base;

/// <summary>
/// Base class for ms sql entity
/// </summary>
public class User : IdentityUser,IEntity
{
    public Guid Guid { get; set; }
    public string FullName { get; set; }
}