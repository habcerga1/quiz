using System.ComponentModel.DataAnnotations;

namespace Domain.Dto;

/// <summary>
/// Login Dto entity
/// </summary>
public class LoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}