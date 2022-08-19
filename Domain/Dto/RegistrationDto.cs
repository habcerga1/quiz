using System.ComponentModel.DataAnnotations;

namespace Domain.Dto;

/// <summary>
/// Registration Dto entity
/// </summary>
public class RegistrationDto
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
}