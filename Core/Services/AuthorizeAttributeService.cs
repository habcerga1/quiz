using Domain.Common;
using Microsoft.AspNetCore.Authorization;

namespace Core.Services;

public class AuthorizeAttributeService : AuthorizeAttribute
{
    private Roles roleEnum;
    public Roles RoleEnum
    {
        get { return roleEnum; }
        set { roleEnum = value; base.Roles = value.ToString(); }
    }
}