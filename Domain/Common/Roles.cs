namespace Domain.Common;

[Flags]
public enum Roles
{
    User = 1,
    Subscriber = 1 << 1,
    Administrator = 1 << 2
}