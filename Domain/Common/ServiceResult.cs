namespace Domain.Common;



public class ServiceResult
{
    public bool Succeeded { get; }

    public Result Message { get; set; }

    public ServiceResult(Result message,bool succeeded)
    {
        Succeeded = succeeded;
        Message = message;
    }

    public ServiceResult() { }

    #region Helper Methods

    public static ServiceResult Failed(Result message)
    {
        return new ServiceResult(message,false);
    }
    
    public static ServiceResult Success(Result message)
    {
        return new ServiceResult(message,true);
    }

    #endregion
}