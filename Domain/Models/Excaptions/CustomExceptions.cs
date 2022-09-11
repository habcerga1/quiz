using System.Runtime.Serialization;
using Domain.Dto;

namespace Domain.Models.Excaptions;

[Serializable]
public abstract class BaseCustomException<T> : Exception
{
    public virtual T Item { get; private set; }
    
    protected BaseCustomException(string exceptionMessage,T item) : base(exceptionMessage)
    {
        Item = item;
    }
}

public class CustomException<T> : BaseCustomException<T>
{
    private T _item;
    public override T Item => _item;

    public CustomException(string exceptionMessage, T item) : base(exceptionMessage, item)
    {
    }
    
}

public class UserNotFoundException : CustomException<LoginDto>
{
    public UserNotFoundException(string exceptionMessage, LoginDto item) : base(exceptionMessage, item)
    {
    }
}

public class WrongEmailOrPasswordException : CustomException<LoginDto>
{
    public WrongEmailOrPasswordException(string exceptionMessage, LoginDto item) : base(exceptionMessage, item)
    {
    }
}


public class UserRolePermitException : CustomException<LoginDto>
{
    public UserRolePermitException(string exceptionMessage, LoginDto item) : base(exceptionMessage, item)
    {
    }
}

