namespace Domain.Common;


/// <summary>
/// Entity for result and response from services
/// </summary>
public class ServiceResult
{
    public bool Succeeded { get; }

    public Result Message { get; set; }

    public ServiceResult(Result message,bool succeeded)
    {
        Succeeded = succeeded;
        Message = message;
    }

    #region Helper Methods

    public static ServiceResult Failed(Result message)
    {
        return new ServiceResult(message,false);
    }
    
    public static ServiceResult Success(Result message)
    {
        return new ServiceResult(message,true);
    }
    
    public static ServiceResult Failed<T>(Result message)
    {
        return new ServiceResult<T>(message,false);
    }
    
    public static ServiceResult Failed<T>(T data,Result message)
    {
        return new ServiceResult<T>(data,message,false);
    }
    
    public static ServiceResult Success<T>(T data,Result message)
    {
        return new ServiceResult<T>(data,message,true);
    }
    
    #endregion
}

public class ServiceResult<T> : ServiceResult
{
    public T Data { get; set; }
    
    public ServiceResult(Result message,bool succeeded) : base(message,succeeded)
    {
        
    }

    public ServiceResult(T data,Result message,bool succeeded) : base(message,succeeded)
    {
        Data = data;
    }
    
}